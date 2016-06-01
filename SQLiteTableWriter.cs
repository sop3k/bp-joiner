using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Transactions;
using System.Data.Linq.Mapping;
using System.Text.RegularExpressions;

using System.Globalization;
using System.Threading;

using Linq = System.Data.Linq;

namespace baseprotect
{
    class SQLiteTableWriter<TEntity>
        where TEntity : class
    {
        object[] parameters;

        public SQLiteTableWriter(BaseprotectDB _db, params object[] _parameters )
        {
            parameters = _parameters;
        }

        public int WriteTable(Linq.Table<TEntity> sqltable, Table table, Action progressReporter)
        {
            int WrittenCount = 0;
            foreach (Row row in table.Rows)
            {
                ++WrittenCount;
                TEntity entity;
                TEntity found;

                Linq.Table<TEntity> sqlTable;
                ITableToEntity<TEntity> factory;

                sqlTable = Config.DB.GetTable<TEntity>();
                factory = Converter<TEntity>.Get(parameters);
                
                entity = factory.Create(row, false);
                found = factory.Find(sqlTable, entity);

                while (true)
                {
                    try
                    {
                        if (entity != null)
                        {
                            if (entity == found)
                                sqlTable.InsertOnSubmit(entity);
                            Config.DB.SubmitChanges();
                        }
                        break;
                    }
                    catch (System.Data.SqlServerCe.SqlCeException e)
                    {
                        --WrittenCount;
                        Config.RefreshConnection();

                        Regex regex = new Regex(@"\[.*\]");
                        MatchCollection matches = regex.Matches(e.Message);

                        if (matches.Count != 1)
                            throw;

                        string[] parts = matches[0].Value.Trim('[', ']').Split(',');
                        string TableName = parts[0].Split('=')[1].Trim();
                        string ErrorConstraintName = String.Empty;

                        try{
                            ErrorConstraintName = parts[1].Split('=')[1].Trim();
                        }catch (Exception ex){
                            continue;
                        }

                        if (ErrorConstraintName == "Unique_ISP_Name")
                        {
                            sqlTable = Config.DB.GetTable<TEntity>();
                            entity = factory.OnFail(entity, row, Config.DB, e);
                        }
                        else break;
                    }
                }

                if (progressReporter != null)
                    progressReporter.Invoke();
            }
            return WrittenCount;
        }
    }
}

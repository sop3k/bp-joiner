using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace baseprotect
{
    class StatsParameters
    {
        DateTime start;
        DateTime end;
    }

    class StatsGenerator
    {
        private BaseprotectDB db;

        private IQueryable<ExportProcess> exports;
        private IQueryable<JoinProcess> joins;

        public StatsGenerator(BaseprotectDB db)
        {
            this.db = db;
        }

        public void RetreiveData()
        {
            exports = db.Exports.AsQueryable<ExportProcess>();
            joins = db.JoinProcess.AsQueryable<JoinProcess>();
        }

        public void Generate(StatsParameters config, String filename)
        {

        }
    }
}

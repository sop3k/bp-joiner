using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace baseprotect
{
    public class Reminders
    {
        public List<Reminder> Check(Project prj)
        {
            List<Reminder> r = new List<Reminder>();

            foreach (Reminder rem in prj.Reminders)
            {
                if (ShouldPost(rem, DateTime.Now))
                   r.Add(rem);
            }

            return r;
        }

        bool ShouldPost(Reminder r, DateTime dt)
        {
            DateTime postDate = r.PostDate;

            if (r.Cyclic != 0)
                postDate = r.LastPost.AddDays(r.Peroid);

            return dt <= postDate;
        }

        public void Post(IEnumerable<Reminder> reminders)
        {
            if (reminders.Count() == 0)
                return;

            var handled = ShowReminders(reminders);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.Zero))
            {
                foreach (Reminder rem in handled)
                    rem.Post();

                Config.DB.SubmitChanges();
                scope.Complete();
            }
        }

        IEnumerable<Reminder> ShowReminders(IEnumerable<Reminder> reminders)
        {
            RemindersList dlg = new RemindersList(reminders);
            dlg.ShowDialog();
            return dlg.Handled;
        }
    }

}

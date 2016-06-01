using System;
using System.Transactions;
using System.Collections.Generic;

namespace baseprotect
{
    class StateChanger
    {
        private TimeSpan duration;
        private List<State> baseStates = new List<State>();

        public StateChanger(TimeSpan duration, State[] baseStates )
        {
            this.duration = duration;
            this.baseStates.AddRange(baseStates);
        }

        public bool CheckStateTime(Person person)
        {
            PersonState state = person.CurrentState;
            return state.Date + duration <= DateTime.Now && baseStates.Contains(state.State); 
        }

        public void ChangePersonState(Person person)
        {
            person.ChangeState(State.Ignoring, String.Format("state change to IGNORING after {0} elapsed.", duration.TotalDays), null, Config.ActiveProject);
            Config.DB.SubmitChanges();
        }

        public void BatchChange(IEnumerable<Person> data)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.Zero))
            {
                foreach (Person p in data)
                {
                    if (CheckStateTime(p))
                        ChangePersonState(p);
                }
                scope.Complete();
            }
        }
    }
}
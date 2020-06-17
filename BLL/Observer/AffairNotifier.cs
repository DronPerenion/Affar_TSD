using System.Collections.Generic;
using BLL.Observer.Interfaces;

namespace BLL.Observer
{
    public class AffairNotifier : IObservable
    {
        readonly List<IObserver> _affairNotifiers;
        private Report _report;

        public AffairNotifier()
        {
            _affairNotifiers = new List<IObserver>();
        }

        public void AddReport(Report report)
        {
            _report = report;
            NotifyObservers();
        }

        public void RegisterObserver(IObserver o)
        {
            _affairNotifiers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            _affairNotifiers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (var o in _affairNotifiers)
            {
                o.Update(_report);
            }
        }
    }
}
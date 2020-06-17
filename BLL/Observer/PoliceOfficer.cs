using System;
using BLL.Observer.Interfaces;

namespace BLL.Observer
{

    public class PoliceOfficer : IObserver
    {
        private readonly string _name;
        private IObservable _notifiers;

        public PoliceOfficer(string name, IObservable notifiers)
        {
            _name = name;
            _notifiers = notifiers;
            _notifiers.RegisterObserver(this);
        }

        public void Update(object ob)
        {
            var report = (Report)ob;

            Console.WriteLine($"Police officer {_name} receive new report {report}");
        }
    }
}
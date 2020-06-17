using BLL.Adapter.Models;
using BLL.Factory.Model;

namespace BLL.Adapter
{
    public class AffairToInfoAdapter : IInfo
    {
        private readonly IAffair _affair;

        public AffairToInfoAdapter(IAffair affair)
        {
            _affair = affair;
        }

        public string GetInfo()
        {
            return _affair.GetAffairInfo();
        }
    }
}
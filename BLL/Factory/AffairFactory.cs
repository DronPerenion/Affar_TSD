using BLL.Factory.Model;

namespace BLL.Factory
{
    public class AffairFactory
    {
        public AffairFactory()
        {

        }

        public IAffair CreateInstance(string name, int section, int paragraph)
        {
            if (section > 0 && section < 100)
            {
                return new AdministrativeAffair(section, paragraph);
            }
            else 
            {
                return new CriminalAffair(section, paragraph);
            }
        }
    }
}
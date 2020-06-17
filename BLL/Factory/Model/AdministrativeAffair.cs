namespace BLL.Factory.Model
{
    public class AdministrativeAffair : IAffair
    {
        private int _section;
        private int _paragraph;

        public AdministrativeAffair(int section, int paragraph)
        {
            _section = section;
            _paragraph = paragraph;
        }

        public string GetAffairInfo()
        {
            return $"Administrative affair {_section} : {_paragraph}";
        }
    }
}
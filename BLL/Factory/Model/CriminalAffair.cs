namespace BLL.Factory.Model
{
    public class CriminalAffair : IAffair
    {
        private int _section;
        private int _paragraph;

        public CriminalAffair(int section, int paragraph)
        {
            _section = section;
            _paragraph = paragraph;
        }

        public string GetAffairInfo()
        {
            return $"Criminal affair {_section} : {_paragraph}";
        }
    }
}
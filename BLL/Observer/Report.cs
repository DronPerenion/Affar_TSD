namespace BLL.Observer
{
    public class Report
    {
        private string _description;

        public Report(string description)
        {
            _description = description;
        }

        public override string ToString()
        {
            return _description;
        }
    }
}
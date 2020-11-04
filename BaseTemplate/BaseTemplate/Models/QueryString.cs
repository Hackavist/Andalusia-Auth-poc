using System.Text;

namespace BaseTemplate.Models
{
    public class QueryString
    {
        public string count { get; set; }
        public int top { get; set; }
        public int skip { get; set; }
        public string orderby{ get; set; }
        public string format { get;set;}
    }
}

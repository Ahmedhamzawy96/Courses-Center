using Courses_Center.Models;

namespace Courses_Center.ViewModels
{
    public class CollageDepts
    {
       
        public Dictionary<College, List<Department>> collegdpts=new Dictionary<College, List<Department>>();
        
        public string uniName { get; set; }
    }
}

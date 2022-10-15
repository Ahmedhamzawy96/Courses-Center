using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Courses_Center.ViewModels
{
    public class FilterDepartViewModel
    {
        [Required(ErrorMessage = "يجب اختيار الجامعة")]
        [RegularExpression("^[1-9]+\\d*$", ErrorMessage = "يجب اختيار الجامعة")]
        public int? UniverstyID{ get; set; }
        [Required(ErrorMessage = "يجب اختيار الكلية")]
        [RegularExpression("^[1-9]+\\d*$", ErrorMessage = "يجب اختيار الكلية")]
        public int? CollageID { get; set; }
    }
}

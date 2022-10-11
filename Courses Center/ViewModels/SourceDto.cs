using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Courses_Center.ViewModels
{
    public class SourceDto
    {

        public int Id { get; set; }

        [Display(Name = "الجامعة")]
        [Required(ErrorMessage = "يجب اختيار الكلية")]
        [RegularExpression("[1-9]{1,}", ErrorMessage = "يجب اختيار الجامعة")]
        public int uniId { get; set; }

        [Display(Name = "الكلية")]
        [Required(ErrorMessage = "يجب اختيار الكلية")]
        [RegularExpression("[1-9]{1,}", ErrorMessage = "يجب اختيار الكلية")]
        public int colliId { get; set; }

        [Display(Name = "القسم")]
        [Required]
        [RegularExpression("[1-9]{1,}", ErrorMessage = "يجب اختيار القسم")]
        public int deptId { get; set; }

        [Display(Name = "المادة")]
        [Required]
        [RegularExpression("[1-9]{1,}", ErrorMessage = "يجب اختيار المادة")]
        public int CrsID { get; set; }

        [Display(Name = "المحاضر")]
        [Required]
        [RegularExpression("[1-9]{1,}", ErrorMessage = "يجب اختيار المحاضر")]
        public int ProfID { get; set; }

        public string ImageName { get; set; }
        public string uniName { get; set; }
        public string collName { get; set; }
        public string deptName { get; set; }


        [Display(Name ="نوع المصدر")]
        [Required(ErrorMessage ="يجب اختيار نوع المصدر")]
        public string Type { get; set; }

        [Display(Name ="عنوان الملخص")]
        [Required(ErrorMessage ="يجب تحديد عنوان الملخص")]
        public string Title { get; set; }

        [Display(Name = "الوصف")]
        public string Description { get; set; }

        [Display(Name ="السعر")]
        [Required(ErrorMessage ="يجب تحديد سعر الملخص")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage ="يجب تحميل الملف")]
        public string Url { get; set; }

        [Display(Name ="الملاحظات")]
        public string Notes { get; set; }





     



    }
}

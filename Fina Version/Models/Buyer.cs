using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courses_Center.Models
{
    public class Buyer
    {
        [Key]
        [Required(ErrorMessage = "يجب ادخال اسم المستخدم")]
        [Remote("checkUsername", "Registeration", ErrorMessage = "هناك مستخدم بهذا الاسم")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "يجب ادخال البريد الالكترونى")]
        [DataType(DataType.EmailAddress, ErrorMessage = "اليريدالالكترونى الذى ادخلته غير صالح")]
        public string Email { get; set; }

        [Required(ErrorMessage = "يجب ادخال الرقم السرى")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "يجب ادخال الاسم الاول")]
        [RegularExpression("^[^0-9]{3,}$", ErrorMessage = "لايجب ان يحوى الاسم على ارقام")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "يجب ادخال الاسم الثانى")]
        [RegularExpression("^[^0-9]{3,}$", ErrorMessage = "لايجب ان يحوى الاسم على ارقام")]
        public string Lname { get; set; }

        public bool ISDeleted { get; set; }


        public virtual ICollection<BuyingCart> BuyingCarts { get; set; } = new HashSet<BuyingCart>();
    }
}

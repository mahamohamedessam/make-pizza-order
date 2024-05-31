using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ITI_ITI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [DisplayName("Full Name")]
        [Required(ErrorMessage = "You have to provide a valid full name. ")]
        [MinLength(9, ErrorMessage = "Full name mustn't be less than 9 characters. ")]
        [MaxLength(50, ErrorMessage = "Full name mustn't exceed 50 characters. ")]
        public string FullName { get; set; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "You have to provide your address ")]
        [MinLength(15, ErrorMessage = "Address mustn't be less than 15 characters. ")]
        [MaxLength(85, ErrorMessage = "Address mustn't exceed 70 characters. ")]
        public string Description { get; set; }

        [DisplayName("Phone Number")]
        [MinLength(11, ErrorMessage = " Phone number number mustn't be less than 11 digits ")]
        [MaxLength(11, ErrorMessage = " Phone number number mustn't be more than 11 digits ")]
        [RegularExpression("[0-9]{11}", ErrorMessage = "The Phone number must be 11 digits. ")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Your Choice")]

        public int MyRestaurantId { get; set; }

        [ValidateNever]
        public MyRestaurant MyRestaurant { get; set; }
    }
}

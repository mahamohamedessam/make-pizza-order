using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ITI_ITI.Models
{
    public class MyRestaurant
    {
        public int Id { get; set; }
        [DisplayName("Name of dish")]
        [Required(ErrorMessage = "You have to provide a valid full name. ")]
        [MinLength(9, ErrorMessage = "Full name mustn't be less than 9 characters. ")]
        [MaxLength(50, ErrorMessage = "Full name mustn't exceed 50 characters. ")]
        public string FullName { get; set; }

        [DisplayName("Ingredients")]
        [Required(ErrorMessage = "This field is required ")]
        [MinLength(15, ErrorMessage = "This feild mustn't be less than 15 characters. ")]
        [MaxLength(85, ErrorMessage = "This feild mustn't exceed 85 characters. ")]
        public string Description { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "This field is required ")]
        public int Price { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace BookStore.Data.ViewModels
{
    public class CheckoutVM
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your province.")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Please enter your country.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter your ZIP code.")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$", ErrorMessage = "Please enter a valid Canadian postal code.")]
        public string ZipCode { get; set; }

    }
}

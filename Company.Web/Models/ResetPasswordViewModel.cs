using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class ResetPasswordViewModel
    {
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm Is Required")]
        [Compare(nameof(Password), ErrorMessage = "Confirm Password does not Match Password")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }

    }
}

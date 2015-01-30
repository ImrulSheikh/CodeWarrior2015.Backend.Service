using System.ComponentModel.DataAnnotations;

namespace CW.Backend.DAL.CRUD.Entities {
    // Models used as parameters to AccountController actions.

    public class AddExternalLoginBindingModel {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }

    public class ChangePasswordBindingModel {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterBindingModel {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Full Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at best {2} characters long.", MinimumLength = 6)]
        public string FullName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Sex")]
        [StringLength(4)]
        public string Sex { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Address")]
        [StringLength(100, ErrorMessage = "The {0} must be at best {2} characters long.", MinimumLength = 6)]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "PhoneNumber")]
        [StringLength(30, ErrorMessage = "The {0} must be at best {2} characters long.", MinimumLength = 6)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "EmailAddress")]
        [StringLength(100, ErrorMessage = "The {0} must be at best {2} characters long.", MinimumLength = 6)]
        public string EmailAddress { get; set; }
    }

    public class RegisterExternalBindingModel {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }

    public class RemoveLoginBindingModel {
        [Required]
        [Display(Name = "Login provider")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Provider key")]
        public string ProviderKey { get; set; }
    }

    public class SetPasswordBindingModel {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}

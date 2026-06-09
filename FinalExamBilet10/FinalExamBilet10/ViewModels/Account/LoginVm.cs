using System.ComponentModel.DataAnnotations;

namespace FinalExamBilet10.ViewModels.Account;

public class LoginVm
{
    [Required]
    [MinLength(3)]
    public string UserNameOrEmail { get; set; }
    [Required]
    public string Password { get; set; }
}

public class RegisterVm
{
    [Required]
    [MinLength(5)]
    public string Email { get; set; }
    [Required]
    [MinLength(5)]
    public string UserName { get; set; }
    [Required]
    [MinLength(6)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [MinLength(6)]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}
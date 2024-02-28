using System.ComponentModel.DataAnnotations;

namespace UserManagement.Web.Models.Users;

public class UserListViewModel
{
    public List<UserListItemViewModel> Items { get; set; } = new();
}

public class UserListItemViewModel
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Please add a Forename")]
    [RegularExpression(@"^[a-zA-Z\-]+$", ErrorMessage = "Invalid characters in Forename.")]
    public string? Forename { get; set; }

    [Required(ErrorMessage = "Please add a Surname")]
    [RegularExpression(@"^[a-zA-Z\-]+$", ErrorMessage = "Invalid characters in Surname.")]
    public string? Surname { get; set; }

    [Required(ErrorMessage = "Please add an email address")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Please add a date of birth in the format yyyy-MM-dd")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public string? DateOfBirth { get; set; }

    [Required(ErrorMessage = "Please select the account status")]
    public bool IsActive { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace UserManagement.Web.Models.Users;

public class UserListViewModel
{
    public List<UserListItemViewModel> Items { get; set; } = new();
}

public class UserListItemViewModel
{
    public long Id { get; set; }
    public string? Forename { get; set; }
    public string? Surname { get; set; }
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string? Email { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public string? DateOfBirth { get; set; }
    [Required(ErrorMessage = "Please select the account status")]
    public bool IsActive { get; set; }
}

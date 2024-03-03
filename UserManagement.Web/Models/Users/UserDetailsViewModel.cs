using UserManagement.Web.Models.Logs;
using UserManagement.Web.Models.Users;

namespace UserManagement.Web.Models;

public class UserDetailsViewModel
{
    public required UserListItemViewModel User { get; set; }
    public IEnumerable<LoggerListItemViewModel>? LogDetails { get; set; }
}

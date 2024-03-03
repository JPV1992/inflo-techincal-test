using System;
using System.Linq;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models;
using UserManagement.Web.Models.Users;
using UserManagement.Web.Models.Logs;

namespace UserManagement.WebMS.Controllers;

[Route("users")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly ILoggerService _loggerService;
    public static readonly string CreateAction = "Create";
    public static readonly string UpdateAction = "Update";
    public static readonly string DeleteAction = "Delete";


    public UsersController(IUserService userService, ILoggerService loggingService)
    {
        _userService = userService;
        _loggerService = loggingService;
    }

    #region Actions
    [HttpGet]
    public ViewResult List()
    {
        var items = _userService.GetAll().Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            DateOfBirth = p.DateOfBirth.ToString("dd/MM/yyyy"),
            Email = p.Email,
            IsActive = p.IsActive
        });

        var model = new UserListViewModel
        {
            Items = items.ToList()
        };

        return View(model);
    }

    [HttpGet("FilterActiveUsers")]
    public ViewResult FilterActiveUsers(bool isActive)
    {
        var items = _userService.FilterByActive(isActive).Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            DateOfBirth = p.DateOfBirth.ToString("dd/MM/yyyy"),
            Email = p.Email,
            IsActive = p.IsActive
        });

        var model = new UserListViewModel { Items = items.ToList() };

        return View(model);
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("Create")]
    public IActionResult Create([Bind("Forename,Surname,DateOfBirth,Email,IsActive")] User userDetails)
    {
        _userService.Create(userDetails);
        LogAction(CreateAction, userDetails.Id);
        
        return RedirectToAction("List");
    }

    [HttpGet("Delete")]
    public IActionResult Delete(int id)
    {
        var userToDelete = GetUserById(id);
        if (userToDelete == null)
        {
            return NotFound();
        }

        return View(userToDelete);
    }

    [HttpDelete, ActionName("DeleteConfirmed")]
    public IActionResult DeleteConfirmed(int id)
    {
        var users = _userService.GetAll();

        var userToDelete = users.FirstOrDefault(User => User.Id == id);
        if (userToDelete == null)
        {
            return NotFound();
        }

        _userService.Delete(userToDelete);
        LogAction(DeleteAction, id);

        return Json(new { success = true });
    }

    [HttpGet("ViewDetails")]
    public IActionResult ViewDetails(int id)
    {
        var userToView = GetUserById(id);
        if (userToView == null)
        {
            return NotFound();
        }

        var userLogs = GetUserLogs(id);
        var userDetails = new UserDetailsViewModel
        {
            User = userToView,
            LogDetails = userLogs
        };

        return View(userDetails);
    }

    [HttpGet("EditUser")]
    public IActionResult EditUser(int id)
    {
        var userToEdit = GetUserById(id);
        if (userToEdit == null)
        {
            return NotFound();
        }

        return View(userToEdit);
    }

    [HttpPost("ConfirmEdit")]
    public IActionResult ConfirmEdit(int id, [Bind("Id,Forename,Surname,DateOfBirth,Email,IsActive")] UserListItemViewModel model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var user = new User
            {
                Id = model.Id,
                Forename = model.Forename ?? string.Empty,
                Surname = model.Surname ?? string.Empty,
                DateOfBirth = DateTime.TryParse(model.DateOfBirth, out DateTime date) ? date : DateTime.MinValue,
                Email = model.Email ?? string.Empty,
                IsActive = model.IsActive
            };

            _userService.Update(user);
            LogAction(UpdateAction, id);
        }

        return RedirectToAction("List");
    }
    #endregion

    #region Private Methods
    private UserListItemViewModel? GetUserById(int id)
    {
        var users = _userService.GetAll();

       var userToView = users.Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            DateOfBirth = p.DateOfBirth.ToString("dd/MM/yyyy"),
            Email = p.Email,
            IsActive = p.IsActive
        }).FirstOrDefault(User => User.Id == id);

        return userToView;
    }

    private IEnumerable<LoggerListItemViewModel> GetUserLogs(int id)
    {
        var logs = _loggerService.GetAll();
        var userLogs = logs.Where(p => p.UserId == id).Select(p => new LoggerListItemViewModel
        {
            Id = p.Id,
            UserId = p.UserId,
            Action = p.Action,
            Timestamp = p.Timestamp.ToString("dd/MM/yyyy H:mm:ss")
        });

        return userLogs;
    }

    private void LogAction(string action, long userId)
    {
        var log = new Logger
        {
            UserId = userId,
            Action = action,
            Timestamp = DateTime.Now
        };

        _loggerService.Create(log);
    }
    #endregion
}

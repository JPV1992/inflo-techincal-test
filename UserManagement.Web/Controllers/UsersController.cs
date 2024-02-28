using System.Linq;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

[Route("users")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService) => _userService = userService;

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
    public ViewResult Create()
    {
        return View();
    }

    [HttpPost("Create")]
    public IActionResult Create([Bind("Forename,Surname,DateOfBirth,Email,IsActive")] User l)
    {
        _userService.Create(l);
        return RedirectToAction("List");
    }

    [HttpGet("Delete")]
    public ViewResult Delete(int id)
    {
        var users = _userService.GetAll();

       var userToDelete = users.Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            DateOfBirth = p.DateOfBirth.ToString("dd/MM/yyyy"),
            Email = p.Email,
            IsActive = p.IsActive
        }).FirstOrDefault(User => User.Id == id);

        // Redirect to the list view
        return View(userToDelete);
    }

    [HttpPost, ActionName("DeleteConfirmed")]
    public IActionResult DeleteConfirmed(int id)
    {
        var users = _userService.GetAll();

        var userToDelete = users.FirstOrDefault(User => User.Id == id);
        if (userToDelete == null)
        {
            return NotFound();
        }

        _userService.Delete(userToDelete);

        // Redirect to the list view
        return RedirectToAction("List");
    }
}

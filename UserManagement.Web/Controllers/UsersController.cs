using System;
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
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("Create")]
    public IActionResult Create([Bind("Forename,Surname,DateOfBirth,Email,IsActive")] User userDetails)
    {
        _userService.Create(userDetails);
        return RedirectToAction("List");
    }

    [HttpGet("Delete")]
    public IActionResult Delete(int id)
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

        // Redirect to the list view
        return Json(new { success = true });
    }

    [HttpGet("ViewDetails")]
    public IActionResult ViewDetails(int id)
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

        if (userToView == null)
        {
            return NotFound();
        }

        return View(userToView);
    }

    [HttpGet("EditUser")]
    public IActionResult EditUser(int id)
    {
        var users = _userService.GetAll();

        var userToEdit = users.Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            DateOfBirth = p.DateOfBirth.ToString("dd/MM/yyyy"),
            Email = p.Email,
            IsActive = p.IsActive
        }).FirstOrDefault(User => User.Id == id);

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
        }

        return RedirectToAction("List");
    }


}

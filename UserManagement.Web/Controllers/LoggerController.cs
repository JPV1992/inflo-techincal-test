using System.Linq;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Logs;

namespace UserManagement.WebMS.Controllers;

[Route("logger")]
public class LoggerController : Controller
{
    private readonly ILoggerService _loggerService;
    public LoggerController(ILoggerService loggerService) => _loggerService = loggerService;

    [HttpGet]
    public ViewResult Logs()
    {
        var logs = _loggerService.GetAll().Select(p => new LoggerListItemViewModel()
        {
            Id = p.Id,
            UserId = p.UserId,
            Action = p.Action,
            Timestamp = p.Timestamp.ToString("dd/MM/yyyy H:mm:ss")
        });

        var model = new LoggerListViewModel
        {
            Logs = logs.ToList()
        };

        return View(model);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var logs = _loggerService.GetAll();

        var logToDelete = logs.FirstOrDefault(Logs => Logs.Id == id);
        if (logToDelete == null)
        {
            return NotFound();
        }

        _loggerService.Delete(logToDelete);
        return Json(new { success = true });
    }


}

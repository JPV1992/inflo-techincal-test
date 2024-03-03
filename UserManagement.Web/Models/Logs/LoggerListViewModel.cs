using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Web.Models.Logs;

public class LoggerListViewModel
{
    public List<LoggerListItemViewModel> Logs { get; set; } = new();
}


public class LoggerListItemViewModel
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string Action { get; set; } = default!;
    [Required(ErrorMessage = "Please add a timestamp")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm:ss}", ApplyFormatInEditMode = true)]
    public string Timestamp { get; set; } = DateTime.Now.ToString("dd/MM/yyyy H:mm:ss");
}


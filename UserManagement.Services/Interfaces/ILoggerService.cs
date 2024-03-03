using System.Collections.Generic;
using UserManagement.Models;

namespace UserManagement.Services.Domain.Interfaces;

public interface ILoggerService
{
    IEnumerable<Logger> GetAll();
    void Create(Logger log);
    void Delete(Logger log);
    void Update(Logger log);
}

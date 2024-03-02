using System;
using System.Collections.Generic;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.Services.Domain.Implementations;

public class LoggerService : ILoggerService
{
    private readonly IDataContext _dataAccess;
    public LoggerService(IDataContext dataAccess) => _dataAccess = dataAccess;

    public IEnumerable<Logger> GetAll() => _dataAccess.GetAll<Logger>();

    public void Create(Logger log)
    {
        _dataAccess.Create(log);
    }

    public void Delete(Logger log)
    {
        _dataAccess.Delete(log);
    }

    public void Update(Logger log)
    {
        _dataAccess.Update(log);
    }

}

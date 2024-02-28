using System;
using System.Collections.Generic;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.Services.Domain.Implementations;

public class UserService : IUserService
{
    private readonly IDataContext _dataAccess;
    public UserService(IDataContext dataAccess) => _dataAccess = dataAccess;

    /// <summary>
    /// Return users by active state
    /// </summary>
    /// <param name="isActive"></param>
    /// <returns></returns>
    public IEnumerable<User> FilterByActive(bool isActive)
    {
        if (isActive)
        {
            return _dataAccess.GetActiveUsers<User>();
        }
        else if (!isActive)
        {
            return _dataAccess.GetInactiveUsers<User>();
        }

        // Throw error on event where isActive is null
        throw new ArgumentNullException();
    }

    public IEnumerable<User> GetAll() => _dataAccess.GetAll<User>();

    public IEnumerable<User> GetUserById(int id)
    {
        return _dataAccess.GetUserById<User>(id);
    }

    public void Create(User user)
    {
        _dataAccess.Create(user);
}

    public void Delete(User users)
    {
        _dataAccess.Delete(users);
    }

}

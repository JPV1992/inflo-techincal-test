using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserManagement.Models;

namespace UserManagement.Data;

public class DataContext : DbContext, IDataContext
{
    public DataContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseInMemoryDatabase("UserManagement.Data.DataContext");

    protected override void OnModelCreating(ModelBuilder model)
        => model.Entity<User>().HasData(new[]
        {
            new User { Id = 1, Forename = "Peter", Surname = "Loew", DateOfBirth = DateTime.Parse("1992-07-16"), Email = "ploew@example.com", IsActive = true },
            new User { Id = 2, Forename = "Benjamin Franklin", Surname = "Gates",  DateOfBirth = DateTime.Parse("1989-01-23"),Email = "bfgates@example.com", IsActive = true },
            new User { Id = 3, Forename = "Castor", Surname = "Troy",  DateOfBirth = DateTime.Parse("2001-12-03"),Email = "ctroy@example.com", IsActive = false },
            new User { Id = 4, Forename = "Memphis", Surname = "Raines", DateOfBirth = DateTime.Parse("1997-07-07"),Email = "mraines@example.com", IsActive = true },
            new User { Id = 5, Forename = "Stanley", Surname = "Goodspeed",  DateOfBirth = DateTime.Parse("1964-12-13"), Email = "sgodspeed@example.com", IsActive = true },
            new User { Id = 6, Forename = "H.I.", Surname = "McDunnough",  DateOfBirth = DateTime.Parse("1990-09-11"),Email = "himcdunnough@example.com", IsActive = true },
            new User { Id = 7, Forename = "Cameron", Surname = "Poe",  DateOfBirth = DateTime.Parse("1984-10-30"),Email = "cpoe@example.com", IsActive = false },
            new User { Id = 8, Forename = "Edward", Surname = "Malus",  DateOfBirth = DateTime.Parse("1995-05-02"),Email = "emalus@example.com", IsActive = false },
            new User { Id = 9, Forename = "Damon", Surname = "Macready",  DateOfBirth = DateTime.Parse("1953-02-28"), Email = "dmacready@example.com", IsActive = false },
            new User { Id = 10, Forename = "Johnny", Surname = "Blaze",  DateOfBirth = DateTime.Parse("2004-02-20"), Email = "jblaze@example.com", IsActive = true },
            new User { Id = 11, Forename = "Robin", Surname = "Feld",  DateOfBirth = DateTime.Parse("1999-12-30"), Email = "rfeld@example.com", IsActive = true },
        });

    public DbSet<User>? Users { get; set; }

    public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        => base.Set<TEntity>();

    public IQueryable<TEntity> GetUserById<TEntity>(int id) where TEntity : class
    {
        if(Users != null)
        {
            return Users.FirstOrDefault(User => User.Id == id) as IQueryable<TEntity> ?? throw new InvalidOperationException();
        }

        return base.Set<TEntity>();
    }

    public IQueryable<TEntity> GetActiveUsers<TEntity>() where TEntity : class
    {
        if (Users != null)
        {
            return Users.Where(User => User.IsActive.Equals(true)) as IQueryable<TEntity> ?? throw new InvalidOperationException();
        }

        return base.Set<TEntity>();
    }

    public IQueryable<TEntity> GetInactiveUsers<TEntity>() where TEntity : class
    {
        if (Users != null)
        {
            return Users.Where(User => User.IsActive.Equals(false)) as IQueryable<TEntity> ?? throw new InvalidOperationException();
        }

        return base.Set<TEntity>();
    }

    public void Create<TEntity>(TEntity entity) where TEntity : class
    {
        base.Add(entity);
        SaveChanges();
    }

    public new void Update<TEntity>(TEntity entity) where TEntity : class
    {
        base.Update(entity);
        SaveChanges();
    }

    public void Delete<TEntity>(TEntity entity) where TEntity : class
    {
        base.Remove(entity);
        SaveChanges();
    }
}

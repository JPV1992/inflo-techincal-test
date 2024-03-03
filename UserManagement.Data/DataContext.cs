using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserManagement.Models;

namespace UserManagement.Data;

public class DataContext : DbContext, IDataContext
{
    public DataContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseInMemoryDatabase("UserManagement.Data.DataContext");

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<User>().HasData(new[]
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
        new User { Id = 12, Forename = "Ethan", Surname = "Anderson", DateOfBirth = DateTime.Parse("1987-06-11"), Email = "eanderson@example.com", IsActive = false},
        new User { Id = 13, Forename = "Sophia", Surname = "Taylor", DateOfBirth = DateTime.Parse("1995-03-18"), Email = "staylor@example.com", IsActive = true},
        new User { Id = 14, Forename = "Alexander", Surname = "Thomas", DateOfBirth = DateTime.Parse("1983-11-04"), Email = "athomas@example.com", IsActive = true},
        new User { Id = 15, Forename = "Ava", Surname = "Jackson", DateOfBirth = DateTime.Parse("1988-09-07"), Email = "ajackson@example.com", IsActive = false},
        new User { Id = 16, Forename = "Mason", Surname = "White", DateOfBirth = DateTime.Parse("1990-07-15"), Email = "mwhite@example.com", IsActive = true},
        new User { Id = 17, Forename = "Charlotte", Surname = "Harris", DateOfBirth = DateTime.Parse("1986-04-29"), Email = "charris@example.com", IsActive = true},
        new User { Id = 18, Forename = "Liam", Surname = "Martin", DateOfBirth = DateTime.Parse("1982-02-03"), Email = "lmartin@example.com", IsActive = false},
        new User { Id = 19, Forename = "Amelia", Surname = "Thompson", DateOfBirth = DateTime.Parse("1993-01-20"), Email = "athompson@example.com", IsActive = true},
        new User { Id = 20, Forename = "Benjamin", Surname = "Garcia", DateOfBirth = DateTime.Parse("1989-10-27"), Email = "bgarcia@example.com", IsActive = false},
        new User { Id = 21, Forename = "Harper", Surname = "Miller", DateOfBirth = DateTime.Parse("1984-08-12"), Email = "hmiller@example.com", IsActive = true},
        new User { Id = 22, Forename = "Lucas", Surname = "Clark", DateOfBirth = DateTime.Parse("1981-06-26"), Email = "lclark@example.com", IsActive = false},
        new User { Id = 23, Forename = "Evelyn", Surname = "Lewis", DateOfBirth = DateTime.Parse("1994-04-10"), Email = "elewis@example.com", IsActive = true},
        new User { Id = 24, Forename = "Oliver", Surname = "Lee", DateOfBirth = DateTime.Parse("1980-12-24"), Email = "olee@example.com", IsActive = true},
        new User { Id = 25, Forename = "Avery", Surname = "Walker", DateOfBirth = DateTime.Parse("1985-11-08"), Email = "awalker@example.com", IsActive = true},
        new User { Id = 26, Forename = "Ella", Surname = "Hall", DateOfBirth = DateTime.Parse("1991-09-22"), Email = "ehall@example.com", IsActive = true},
        new User { Id = 27, Forename = "Jackson", Surname = "Allen", DateOfBirth = DateTime.Parse("1986-07-06"), Email = "jallen@example.com", IsActive = false},
        new User { Id = 28, Forename = "Scarlett", Surname = "Young", DateOfBirth = DateTime.Parse("1982-05-20"), Email = "syoung@example.com", IsActive = true},
        new User { Id = 29, Forename = "Carter", Surname = "Wright", DateOfBirth = DateTime.Parse("1990-03-04"), Email = "cwright@example.com", IsActive = false},
        new User { Id = 30, Forename = "Luna", Surname = "King", DateOfBirth = DateTime.Parse("1987-01-18"), Email = "lking@example.com", IsActive = true},
        new User { Id = 31, Forename = "Henry", Surname = "Hill", DateOfBirth = DateTime.Parse("1992-10-02"), Email = "hhill@example.com", IsActive = true},
        new User { Id = 32, Forename = "Grace", Surname = "Green", DateOfBirth = DateTime.Parse("1984-08-17"), Email = "ggreen@example.com", IsActive = false},
        new User { Id = 33, Forename = "Grayson", Surname = "Baker", DateOfBirth = DateTime.Parse("1981-06-01"), Email = "gbaker@example.com", IsActive = true},
        new User { Id = 34, Forename = "Zoe", Surname = "Adams", DateOfBirth = DateTime.Parse("1995-04-15"), Email = "zadams@example.com", IsActive = true},
        new User { Id = 35, Forename = "Sebastian", Surname = "Nelson", DateOfBirth = DateTime.Parse("1989-02-28"), Email = "snelson@example.com", IsActive = true},
        new User { Id = 36, Forename = "Stella", Surname = "Hill", DateOfBirth = DateTime.Parse("1986-01-12"), Email = "shill@example.com", IsActive = false},
        new User { Id = 37, Forename = "Gabriel", Surname = "Rivera", DateOfBirth = DateTime.Parse("1991-11-26"), Email = "grivera@example.com", IsActive = true},
        new User { Id = 38, Forename = "Aria", Surname = "Cook", DateOfBirth = DateTime.Parse("1985-10-10"), Email = "acook@example.com", IsActive = true},
        new User { Id = 39, Forename = "Logan", Surname = "Roberts", DateOfBirth = DateTime.Parse("1983-08-24"), Email = "lroberts@example.com", IsActive = false},
        new User { Id = 40, Forename = "Aubrey", Surname = "Long", DateOfBirth = DateTime.Parse("1994-07-08"), Email = "along@example.com", IsActive = true},
        new User { Id = 41, Forename = "Elijah", Surname = "Mitchell", DateOfBirth = DateTime.Parse("1988-05-23"), Email = "emitchell@example.com", IsActive = true},
        new User { Id = 42, Forename = "Nora", Surname = "Carter", DateOfBirth = DateTime.Parse("1981-04-06"), Email = "ncarter@example.com", IsActive = false},
        new User { Id = 43, Forename = "Lincoln", Surname = "Perez", DateOfBirth = DateTime.Parse("1995-02-19"), Email = "lperez@example.com", IsActive = true},
        new User { Id = 44, Forename = "Penelope", Surname = "Evans", DateOfBirth = DateTime.Parse("1989-12-04"), Email = "pevans@example.com", IsActive = true},
        new User { Id = 45, Forename = "Mateo", Surname = "Collins", DateOfBirth = DateTime.Parse("1986-10-18"), Email = "mcollins@example.com", IsActive = false},
        new User { Id = 46, Forename = "Madison", Surname = "Morales", DateOfBirth = DateTime.Parse("1991-08-02"), Email = "mmorales@example.com", IsActive = true},
        new User { Id = 47, Forename = "Lincoln", Surname = "Simmons", DateOfBirth = DateTime.Parse("1984-06-16"), Email = "lsimmons@example.com", IsActive = true},
        new User { Id = 48, Forename = "Chloe", Surname = "Foster", DateOfBirth = DateTime.Parse("1980-04-01"), Email = "cfoster@example.com", IsActive = true},
        new User { Id = 49, Forename = "Liam", Surname = "Griffin", DateOfBirth = DateTime.Parse("1993-02-14"), Email = "lgriffin@example.com", IsActive = true},
        new User { Id = 50, Forename = "Zoey", Surname = "Russell", DateOfBirth = DateTime.Parse("1988-12-29"), Email = "zrussell@example.com", IsActive = false},
        new User { Id = 51, Forename = "Ezra", Surname = "Gonzalez", DateOfBirth = DateTime.Parse("1983-11-12"), Email = "egonzalez@example.com", IsActive = true},
        new User { Id = 52, Forename = "Sophie", Surname = "Barnes", DateOfBirth = DateTime.Parse("1992-09-26"), Email = "sbarnes@example.com", IsActive = true},
        new User { Id = 53, Forename = "Nathan", Surname = "Perry", DateOfBirth = DateTime.Parse("1986-08-10"), Email = "nperry@example.com", IsActive = true},
        new User { Id = 54, Forename = "Hannah", Surname = "Harrison", DateOfBirth = DateTime.Parse("1990-06-24"), Email = "hharrison@example.com", IsActive = true},
        new User { Id = 55, Forename = "Owen", Surname = "Alexander", DateOfBirth = DateTime.Parse("1984-05-08"), Email = "oalexander@example.com", IsActive = true},
        new User { Id = 56, Forename = "Mia", Surname = "Diaz", DateOfBirth = DateTime.Parse("1995-03-22"), Email = "mdiaz@example.com", IsActive = false},
        new User { Id = 57, Forename = "Landon", Surname = "Myers", DateOfBirth = DateTime.Parse("1989-01-05"), Email = "lmyers@example.com", IsActive = true},
        new User { Id = 58, Forename = "Aurora", Surname = "Gutierrez", DateOfBirth = DateTime.Parse("1983-11-19"), Email = "agutierrez@example.com", IsActive = true},
        new User { Id = 59, Forename = "Wyatt", Surname = "Sullivan", DateOfBirth = DateTime.Parse("1994-09-03"), Email = "wsullivan@example.com", IsActive = true},
        new User { Id = 60, Forename = "Mila", Surname = "Bennett", DateOfBirth = DateTime.Parse("1988-07-18"), Email = "mbennett@example.com", IsActive = true},
        new User { Id = 61, Forename = "Eli", Surname = "Powell", DateOfBirth = DateTime.Parse("1991-05-11"), Email = "epowell@example.com", IsActive = true}
       });

        model.Entity<Logger>().HasData(new[]
        {
            new Logger{ Id = 1, UserId = 1, Action = "Create", Timestamp = DateTime.Parse("2022-01-01 12:00:00")},
            new Logger{ Id = 2, UserId = 2, Action = "Create", Timestamp = DateTime.Parse("2022-01-01 13:00:00")},
            new Logger{ Id = 3, UserId = 3, Action = "Create", Timestamp = DateTime.Parse("2022-01-01 14:00:00")},
            new Logger{ Id = 4, UserId = 4, Action = "Create", Timestamp = DateTime.Parse("2022-01-01 15:00:00")},
            new Logger{ Id = 5, UserId = 5, Action = "Create", Timestamp = DateTime.Parse("2022-01-01 16:00:00")},
            new Logger{ Id = 6, UserId = 6, Action = "Create", Timestamp = DateTime.Parse("2022-01-01 17:00:00")},
            new Logger{ Id = 7, UserId = 7, Action = "Create", Timestamp = DateTime.Parse("2022-01-01 18:00:00")},
            new Logger{ Id = 8, UserId = 8, Action = "Create", Timestamp = DateTime.Parse("2022-01-01 19:00:00")},
            new Logger{ Id = 9, UserId = 9, Action = "Create", Timestamp = DateTime.Parse("2022-01-01 20:00:00")},
            new Logger{ Id = 10, UserId = 10, Action = "Create", Timestamp = DateTime.Parse("2022-01-01 21:00:00")},
            new Logger{ Id = 11, UserId = 11, Action = "Create", Timestamp = DateTime.Parse("2022-01-01 22:00:00")},
            new Logger{ Id = 12, UserId = 12, Action = "Create", Timestamp = DateTime.Parse("2016-04-23 12:56:00")},
            new Logger{ Id = 13, UserId = 13, Action = "Create", Timestamp = DateTime.Parse("2016-06-08 15:18:00")},
            new Logger{ Id = 14, UserId = 14, Action = "Create", Timestamp = DateTime.Parse("2016-07-24 17:40:00")},
            new Logger{ Id = 15, UserId = 15, Action = "Create", Timestamp = DateTime.Parse("2016-09-08 20:02:00")},
            new Logger{ Id = 16, UserId = 16, Action = "Create", Timestamp = DateTime.Parse("2016-10-24 22:24:00")},
            new Logger{ Id = 17, UserId = 17, Action = "Create", Timestamp = DateTime.Parse("2016-12-09 00:46:00")},
            new Logger{ Id = 18, UserId = 18, Action = "Create", Timestamp = DateTime.Parse("2017-01-24 03:08:00")},
            new Logger{ Id = 19, UserId = 19, Action = "Create", Timestamp = DateTime.Parse("2017-03-11 05:30:00")},
            new Logger{ Id = 20, UserId = 20, Action = "Create", Timestamp = DateTime.Parse("2017-04-26 07:52:00")},
            new Logger{ Id = 21, UserId = 21, Action = "Create", Timestamp = DateTime.Parse("2017-06-11 10:14:00")},
            new Logger{ Id = 22, UserId = 22, Action = "Create", Timestamp = DateTime.Parse("2017-07-27 12:36:00")},
            new Logger{ Id = 23, UserId = 23, Action = "Create", Timestamp = DateTime.Parse("2017-09-11 14:58:00")},
            new Logger{ Id = 24, UserId = 24, Action = "Create", Timestamp = DateTime.Parse("2017-10-27 17:20:00")},
            new Logger{ Id = 25, UserId = 25, Action = "Create", Timestamp = DateTime.Parse("2017-12-12 19:42:00")},
            new Logger{ Id = 26, UserId = 26, Action = "Create", Timestamp = DateTime.Parse("2018-01-27 22:04:00")},
            new Logger{ Id = 27, UserId = 27, Action = "Create", Timestamp = DateTime.Parse("2018-03-14 00:26:00")},
            new Logger{ Id = 28, UserId = 28, Action = "Create", Timestamp = DateTime.Parse("2018-04-29 02:48:00")},
            new Logger{ Id = 29, UserId = 29, Action = "Create", Timestamp = DateTime.Parse("2018-06-14 05:10:00")},
            new Logger{ Id = 30, UserId = 30, Action = "Create", Timestamp = DateTime.Parse("2018-07-29 07:32:00")},
            new Logger{ Id = 31, UserId = 31, Action = "Create", Timestamp = DateTime.Parse("2018-09-13 09:54:00")},
            new Logger{ Id = 32, UserId = 32, Action = "Create", Timestamp = DateTime.Parse("2018-10-28 12:16:00")},
            new Logger{ Id = 33, UserId = 33, Action = "Create", Timestamp = DateTime.Parse("2018-12-12 14:38:00")},
            new Logger{ Id = 34, UserId = 34, Action = "Create", Timestamp = DateTime.Parse("2019-01-27 17:00:00")},
            new Logger{ Id = 35, UserId = 35, Action = "Create", Timestamp = DateTime.Parse("2019-03-14 19:22:00")},
            new Logger{ Id = 36, UserId = 36, Action = "Create", Timestamp = DateTime.Parse("2019-04-29 21:44:00")},
            new Logger{ Id = 37, UserId = 37, Action = "Create", Timestamp = DateTime.Parse("2019-06-15 00:06:00")},
            new Logger{ Id = 38, UserId = 38, Action = "Create", Timestamp = DateTime.Parse("2019-07-30 02:28:00")},
            new Logger{ Id = 39, UserId = 39, Action = "Create", Timestamp = DateTime.Parse("2019-09-14 04:50:00")},
            new Logger{ Id = 40, UserId = 40, Action = "Create", Timestamp = DateTime.Parse("2019-10-29 07:12:00")},
            new Logger{ Id = 41, UserId = 41, Action = "Create", Timestamp = DateTime.Parse("2019-12-13 09:34:00")},
            new Logger{ Id = 42, UserId = 42, Action = "Create", Timestamp = DateTime.Parse("2020-01-28 11:56:00")},
            new Logger{ Id = 43, UserId = 43, Action = "Create", Timestamp = DateTime.Parse("2020-03-14 14:18:00")},
            new Logger{ Id = 44, UserId = 44, Action = "Create", Timestamp = DateTime.Parse("2020-04-29 16:40:00")},
            new Logger{ Id = 45, UserId = 45, Action = "Create", Timestamp = DateTime.Parse("2020-06-14 19:02:00")},
            new Logger{ Id = 46, UserId = 46, Action = "Create", Timestamp = DateTime.Parse("2020-07-29 21:24:00")},
            new Logger{ Id = 47, UserId = 47, Action = "Create", Timestamp = DateTime.Parse("2020-09-13 23:46:00")},
            new Logger{ Id = 48, UserId = 48, Action = "Create", Timestamp = DateTime.Parse("2020-10-29 02:08:00")},
            new Logger{ Id = 49, UserId = 49, Action = "Create", Timestamp = DateTime.Parse("2020-12-14 04:30:00")},
            new Logger{ Id = 50, UserId = 50, Action = "Create", Timestamp = DateTime.Parse("2021-01-29 06:52:00")},
            new Logger{ Id = 51, UserId = 51, Action = "Create", Timestamp = DateTime.Parse("2021-03-15 09:14:00")},
            new Logger{ Id = 52, UserId = 52, Action = "Create", Timestamp = DateTime.Parse("2021-04-30 11:36:00")},
            new Logger{ Id = 53, UserId = 53, Action = "Create", Timestamp = DateTime.Parse("2021-06-15 13:58:00")},
            new Logger{ Id = 54, UserId = 54, Action = "Create", Timestamp = DateTime.Parse("2021-07-30 16:20:00")},
            new Logger{ Id = 55, UserId = 55, Action = "Create", Timestamp = DateTime.Parse("2021-09-14 18:42:00")},
            new Logger{ Id = 56, UserId = 56, Action = "Create", Timestamp = DateTime.Parse("2021-10-29 21:04:00")},
            new Logger{ Id = 57, UserId = 57, Action = "Create", Timestamp = DateTime.Parse("2021-12-14 23:26:00")},
            new Logger{ Id = 58, UserId = 58, Action = "Create", Timestamp = DateTime.Parse("2022-01-30 01:48:00")},
            new Logger{ Id = 59, UserId = 59, Action = "Create", Timestamp = DateTime.Parse("2022-03-16 04:10:00")},
            new Logger{ Id = 60, UserId = 60, Action = "Create", Timestamp = DateTime.Parse("2022-04-30 06:32:00")},
            new Logger{ Id = 61, UserId = 61, Action = "Create", Timestamp = DateTime.Parse("2022-06-15 08:54:00")},
            new Logger{ Id = 62, UserId = 2, Action = "Update", Timestamp = DateTime.Parse("2016-05-24 14:30:00")},
            new Logger{ Id = 63, UserId = 4, Action = "Update", Timestamp = DateTime.Parse("2016-08-09 16:52:00")},
            new Logger{ Id = 64, UserId = 6, Action = "Update", Timestamp = DateTime.Parse("2016-09-25 19:14:00")},
            new Logger{ Id = 65, UserId = 8, Action = "Update", Timestamp = DateTime.Parse("2016-11-10 21:36:00")},
            new Logger{ Id = 66, UserId = 10, Action = "Update", Timestamp = DateTime.Parse("2016-12-26 23:58:00")},
            new Logger{ Id = 67, UserId = 13, Action = "Update", Timestamp = DateTime.Parse("2017-02-11 02:20:00")},
            new Logger{ Id = 68, UserId = 15, Action = "Update", Timestamp = DateTime.Parse("2017-03-28 04:42:00")},
            new Logger{ Id = 69, UserId = 17, Action = "Update", Timestamp = DateTime.Parse("2017-05-13 07:04:00")},
            new Logger{ Id = 70, UserId = 19, Action = "Update", Timestamp = DateTime.Parse("2017-06-28 09:26:00")},
            new Logger{ Id = 71, UserId = 21, Action = "Update", Timestamp = DateTime.Parse("2017-08-13 11:48:00")},

        });
    }


    public DbSet<User>? Users { get; set; }
    public DbSet<Logger>? Loggers { get; set; }


    public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        => base.Set<TEntity>();
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

    #region Users Methods
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
    #endregion
}

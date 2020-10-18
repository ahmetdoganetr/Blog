using Blog.Core.Abstract;
using Blog.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Blog.Core.Repository
{
    public class UserRepository : CRUD, IUser
    {
        public bool Delete(int userId)
        {
            try
            {
                var user = Find(userId);

                if (user != null)
                {
                    user.IsDeleted = true;

                    return Update<User>(user);
                }

                return false;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public User Find(int userId)
        {
            try
            {
                return db.User.AsNoTracking().FirstOrDefault(a => a.UserId == userId && a.IsDeleted == false);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public User Find(string userName)
        {
            try
            {
                return db.User.AsNoTracking().FirstOrDefault(a => a.UserName == userName && a.IsDeleted == false);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Task<List<User>> Get()
        {
            try
            {
                return db.User.Where(a => a.IsDeleted == false).ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool Insert(User model)
        {
            try
            {
                return Insert<User>(model);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool Update(User model)
        {
            try
            {
                return Update<User>(model);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

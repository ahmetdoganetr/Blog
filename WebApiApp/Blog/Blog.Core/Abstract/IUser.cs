using Blog.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Core.Abstract
{
    public interface IUser : ICRUD
    {
        bool Delete(int userId);
        User Find(int userId);
        User Find(string userName);
        Task<List<User>> Get();
        bool Insert(User model);
        bool Update(User model);
    }
}

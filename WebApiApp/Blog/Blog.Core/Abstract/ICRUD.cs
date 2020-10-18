using System;

namespace Blog.Core.Abstract
{
    public interface ICRUD : IDisposable
    {
        bool Delete<T>(int id) where T : class;
        bool Insert<T>(T entity) where T : class;
        bool Update<T>(T entity) where T : class;
        bool Save<T>(T entity);
    }
}

using Blog.Core.Abstract;
using Blog.Core.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Blog.Core.Repository
{
    public class CRUD : ICRUD
    {
        private bool disposed;

        private BlogContext context = new BlogContext();

        protected BlogContext db
        {
            get { return context; }
            private set { context = value; }
        }

        public virtual bool Delete<T>(int id) where T : class
        {
            try
            {
                var entity = db.Set<T>().Find(id);

                db.Set<T>().Remove(entity);

                return Save<T>(entity);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual bool Insert<T>(T entity) where T : class
        {
            try
            {
                db.Set<T>().Add(entity);

                return Save<T>(entity);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual bool Update<T>(T entity) where T : class
        {
            try
            {
                db.Set<T>().Update(entity);

                return Save<T>(entity);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual bool Save<T>(T entity)
        {
            try
            {
                int value = db.SaveChanges();

                db.Entry(entity).State = EntityState.Detached;

                if (value > 0)
                {
                    return true;
                }

                return false;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbUpdateConcurrencyException("Başka bir kullanıcı güncelleme yapmaktatır, lütfen daha sonra tekrar deneyin.", ex.InnerException);
            }
            catch (ObjectDisposedException ex)
            {
                throw new ObjectDisposedException(ex.Message, ex.InnerException);
            }
            catch (NotSupportedException ex)
            {
                throw new NotSupportedException(ex.Message, ex.InnerException);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message, ex.InnerException);
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message, ex.InnerException);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
                    
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

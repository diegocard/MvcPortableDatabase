using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PortableDatabaseExample.Models
{ 
    public class TaskRepository : ITaskRepository
    {
        TaskContext context;

        public TaskRepository(bool useSqlCE)
        {
            if (useSqlCE)
            {
                this.context = new SqlCEContext();
            }
            else
            {
                this.context = new SQLiteContext();
            }
            
        }

        public IQueryable<Task> All
        {
            get { return context.Tasks; }
        }

        public IQueryable<Task> AllIncluding(params Expression<Func<Task, object>>[] includeProperties)
        {
            IQueryable<Task> query = context.Tasks;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Task Find(int id)
        {
            return context.Tasks.Find(id);
        }

        public void InsertOrUpdate(Task task)
        {
            if (task.ID == default(int)) {
                // New entity
                context.Tasks.Add(task);
            } else {
                // Existing entity
                context.Entry(task).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var task = context.Tasks.Find(id);
            context.Tasks.Remove(task);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface ITaskRepository : IDisposable
    {
        IQueryable<Task> All { get; }
        IQueryable<Task> AllIncluding(params Expression<Func<Task, object>>[] includeProperties);
        Task Find(int id);
        void InsertOrUpdate(Task task);
        void Delete(int id);
        void Save();
    }
}
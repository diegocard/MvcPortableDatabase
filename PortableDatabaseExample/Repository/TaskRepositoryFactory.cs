
using PortableDatabaseExample.Models;
namespace PortableDatabaseExample.Repository
{
    public class TaskRepositoryFactory
    {
        #region Singleton

        private static TaskRepositoryFactory instance;
        private static TaskRepository taskRepository;

        private TaskRepositoryFactory() { }

        public static TaskRepositoryFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaskRepositoryFactory();
                }
                return instance;
            }
        }

        #endregion

        public ITaskRepository GetTaskRepository(bool useSqlCE)
        {
            taskRepository = new TaskRepository(useSqlCE);
            return taskRepository;
        }

        public ITaskRepository GetTaskRepository()
        {
            if (taskRepository == null)
            {
                return GetTaskRepository(true);
            }
            else
            {
                return taskRepository;
            }
        }
    }
}
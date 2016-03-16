using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clear.Model
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetTasks();
        void Create(Task task);
        bool Update(Task task);
        Task GetTask(Guid taskId);
    }
}

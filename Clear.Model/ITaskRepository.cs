using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clear.Model
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetTasks();
    }
}

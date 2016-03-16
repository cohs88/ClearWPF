using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Linq;

namespace Clear.Model
{
    public class TaskRepository : ITaskRepository
    {
        private XDocument xDocTasks;
        public TaskRepository()
        {
            try
            {
                xDocTasks = XDocument.Load("data.xml");
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public IEnumerable<Task> GetTasks()
        {
            var list =
                from t in xDocTasks.Descendants("task")
                select new Task() { TaskId = new Guid(t.Element("taskId").Value), Name = t.Element("name").Value };

            return list;
        }


        public void Create(Task task)
        {
            throw new NotImplementedException();
        }

        public bool Update(Task task)
        {
            throw new NotImplementedException();
        }

        public Task GetTask(Guid taskId)
        {
            throw new NotImplementedException();
        }
    }
}

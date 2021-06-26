using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Implementations
{
    public class TaskListRepository: Repository<TaskList>, ITaskListRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskListRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public void CompleteTask(int id)
        {
            var task =_context.TaskLists.Find(id);
        
            if (task.Completed == true)
                task.Completed = false;
            else
                task.Completed = true;
        }
    }
}

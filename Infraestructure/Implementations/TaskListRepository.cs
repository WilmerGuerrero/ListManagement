using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Implementations
{
    public class TaskListRepository: Repository<TaskList>, ITaskListRepository
    {
        public TaskListRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ITaskListRepository:IRepository<TaskList>
    {
        void CompleteTask(int id);
    }
}

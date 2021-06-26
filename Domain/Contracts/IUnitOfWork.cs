using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUnitOfWork:IDisposable
    {
        public ITaskListRepository TaskList { get; }
        Task CompleteAsync();
        Task DisposeAsync();
    }
}

using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ITaskListRepository TaskList { get; set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            TaskList = new TaskListRepository(context);
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync(); 
        }

        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}

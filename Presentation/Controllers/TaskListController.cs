using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/task-list")]
    public class TaskListController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskListController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskList>>> GetAll() => Ok(await _unitOfWork.TaskList.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskList>> GetById(int id)
        {
            var dbTask = await _unitOfWork.TaskList.GetAsync(id);
            if ( dbTask != null)
                return Ok(dbTask);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<TaskList>> Add([FromBody] TaskList model)
        {
            try
            {
                await _unitOfWork.TaskList.AddAsync(model);
                await _unitOfWork.CompleteAsync();
                return Created("id", model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                await _unitOfWork.DisposeAsync();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Complete(int id)
        {
            var dbTask = await _unitOfWork.TaskList.GetAsync(id);
            try
            {
                if (dbTask != null)
                {
                    _unitOfWork.TaskList.CompleteTask(id);
                    await _unitOfWork.CompleteAsync();
                    return NoContent();
                }
                else
                    return NotFound();

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                await _unitOfWork.DisposeAsync();
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            var dbTask = await _unitOfWork.TaskList.GetAsync(id);
            try
            {
                if (dbTask != null)
                {
                    _unitOfWork.TaskList.Remove(dbTask);
                    await _unitOfWork.CompleteAsync();
                    return NoContent();
                }
                else
                    return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                await _unitOfWork.DisposeAsync();
            }
        }
    }
}

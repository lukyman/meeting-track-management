using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingTrackManagement.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingTrackManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/Task")]
    public class TaskController : Controller
    {
        MeetingTrackManagementContext db;
        public TaskController(MeetingTrackManagementContext _db)
        {
            db = _db;
        }
        // GET: api/Task
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var taskModel = await Task.Run(() =>
                {
                    return db.TaskModel.ToList();
                });

                return Ok(new { data = taskModel });

            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        // GET: api/Task/5
        [HttpGet("{id}", Name = "Get")]
        public TaskModel Get(int id)
        {
            return db.TaskModel.Find(id);
        }
        
        // POST: api/Task
        [HttpPost]
        public IActionResult Post(TaskModel taskModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            taskModel.CreatedAt = DateTime.Now;
            taskModel.UpdatedAt = DateTime.Now;
            db.TaskModel.Add(taskModel);
            db.SaveChanges();
            
            return Ok(new { data = taskModel });
        }
        
        // PUT: api/Task/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

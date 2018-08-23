using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingTrackManagement.Model;
using MeetingTrackManagement.Service;
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
        public IActionResult Get()
        {
            try
            {
                /* var taskModel = await Task.Run(() =>
                 {
                     return db.TaskModel.ToList();
                 });*/

                var totalMinutes = 420;
                var minutesBeforeLunch = 180;
                var minutesAfterLunch = 240;
                var cumulativeMinutes = 0;
                var selectedTasks = new List<TaskModel>();

                var morningTask = new List<TaskModel>();
                var eveningTask = new List<TaskModel>();

                var taskList = new List<TaskModel> {
                   new TaskModel { Title = "Writing Fast Tests Against Enterprise Rails", Minutes = 60 },
                        new TaskModel { Title = "Overdoing it in Python", Minutes = 45 },
                        new TaskModel { Title = "Lua for the Masses", Minutes = 30 },
                        new TaskModel { Title = "Ruby Errors from Mismatched Gem Versions", Minutes = 45 },
                        new TaskModel { Title = "Common Ruby Errors", Minutes = 45 },
                        new TaskModel { Title = "Rails for Python Developers lightning", Minutes = 35 },
                        new TaskModel { Title = "Communicating Over Distance", Minutes = 60 },
                        new TaskModel { Title = "Accounting - Driven Development", Minutes = 45 },
                        new TaskModel { Title = "Woah", Minutes = 30 },
                        new TaskModel { Title = "Sit Down and Write", Minutes = 30 },
                        new TaskModel { Title = "Pair Programming vs Noise", Minutes = 45 },
                        new TaskModel { Title = "Rails Magic", Minutes = 60 },
                        new TaskModel { Title = "Ruby on Rails: Why We Should Move On ?", Minutes = 60 },
                        new TaskModel { Title = "Clojure Ate Scala(on my project)", Minutes = 45 },
                        new TaskModel { Title = "Programming in the Boondocks of Seattle", Minutes = 30 },
                        new TaskModel { Title = "Ruby vs.Clojure for Back - End Development", Minutes = 30 },
                        new TaskModel { Title = "Ruby on Rails Legacy App Maintenance", Minutes = 60 },
                        new TaskModel { Title = "A World Without HackerNews", Minutes = 30 },
                        new TaskModel {Title = "User Interface CSS in Rails Apps", Minutes = 30}
                };

                var shuffledList = ShuffleList.Shuffle<TaskModel>(taskList);

                foreach (var item in shuffledList)
                {
                    var nextCumulativeMinutes = cumulativeMinutes + item.Minutes;
                    if (cumulativeMinutes < totalMinutes)
                    {
                        cumulativeMinutes += item.Minutes;
                        selectedTasks.Add(item);
                    }
                    else
                    {
                        break;
                    }

                }

                var morningCumulativeMinutes = 0;
                foreach (var item in selectedTasks)
                {
                    var nextCumulativeMinutes = morningCumulativeMinutes + item.Minutes;

                    if (nextCumulativeMinutes < minutesBeforeLunch)
                    {
                        morningCumulativeMinutes += item.Minutes;
                        morningTask.Add(item);
                        selectedTasks.Remove(item);
                    }
                }

                var eveningCumulativeMinutes = 0;
                foreach (var item in selectedTasks)
                {
                    var nextCumulativeMinutes = eveningCumulativeMinutes + item.Minutes;

                    if (nextCumulativeMinutes < minutesBeforeLunch)
                    {
                        eveningCumulativeMinutes += item.Minutes;
                        eveningTask.Add(item);
                        selectedTasks.Remove(item);
                    }
                }


                var a = cumulativeMinutes;



             return Ok(new { data = taskList });

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

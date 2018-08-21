using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingTrackManagement.Model
{
    public class MeetingTrackManagementContext:DbContext
    {
        public MeetingTrackManagementContext(DbContextOptions<MeetingTrackManagementContext> options)
            :base(options)
        {

        }

        public DbSet<TaskModel> TaskModel { get; set; }
    }
}

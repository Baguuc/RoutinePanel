using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RoutinePanel.Lib
{
    internal class TaskModel
    {
        [PrimaryKey, AutoIncrement]
	    public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

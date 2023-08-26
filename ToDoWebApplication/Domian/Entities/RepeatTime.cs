using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoWebApplication.Domian.Entities
{
    public class RepeatTime
    {
        public int Id { get; set; }
        public int Nummer { get; set; }
        public RepeatEnum AddDateTime { get; set; }
        public int TaskBaseId { get; set; }
        public TaskBase TaskBase { get; set; }
    }
    public enum RepeatEnum
    {
        Daily,
        Weekdays,
        Weekly,
        Monthly,
        Yearly
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoWebApplication.Domian.Entities
{
    public class AddDueDate
    {
        public int Id { get; set; }
        public AddDueEnum FinishedTime { get; set; }
        public int TaskBaseId { get; set; }
        public TaskBase TaskBase { get; set; }
    }
    public enum AddDueEnum
    {
        Today,
        Tomorrow,
        NextWeek
    }
}

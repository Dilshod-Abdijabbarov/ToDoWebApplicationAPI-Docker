using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoWebApplication.Domian.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public CategoryEnum AddDateTime { get; set; }
        public int TaskBaseId { get; set; }
        public TaskBase TaskBase { get; set; }
    }
    public enum CategoryEnum
    {
        Blue,
        Green,
        Orange,
        Purple,
        Red,
        Yellow
    }
}

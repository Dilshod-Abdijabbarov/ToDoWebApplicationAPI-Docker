using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoWebApplication.Domian.Entities
{
    public class AddFile
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public int TaskBaseId { get; set; }
        public TaskBase TaskBase { get; set; }
    }
}

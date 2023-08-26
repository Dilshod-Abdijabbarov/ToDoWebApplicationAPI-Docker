using System;
using System.Collections.Generic;
using ToDoWebApplication.Domian.Entities;
using ToDoWebApplication.Services.DTOs.AddDueDateDTOs;
using ToDoWebApplication.Services.DTOs.AddFileDTOs;
using ToDoWebApplication.Services.DTOs.CategoryDTOs;
using ToDoWebApplication.Services.DTOs.RepeatTimeDTOs;

namespace ToDoWebApplication.Services.DTOs.TaskBaseDTOs
{
    public class TaskBaseForViewDTO
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public DateTime? Remind_me { get; set; }
        public DateTime? Planned { get; set; }
        public bool? Important { get; set; }
        public bool FinishedTask { get; set; }
        public string? Note { get; set; }
        public DateTime CreateAt { get; set; }
        public int UserId { get; set; }
        public ICollection<CategoryForViewDTO> Categories { get; set; }
        public ICollection<RepeatTimeForViewDTO> RepeatTimes { get; set; }
        public ICollection<AddFileForViewDTOs> AddFiles { get; set; }
        public ICollection<AddDueDateForViewDTOs> AddDueDates { get; set; }

    }
}

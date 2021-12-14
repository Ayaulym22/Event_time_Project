using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Event_time_Project.Models
{
    public class Task
    {
        [Key]
        public int Task_id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Task Name is Required")]
        public string Task_name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Deadline is Required")]
        public string Deadline { get; set; }

        public bool Completed { get; set; }

        public int? Category_Id { get; set; }
        public Category_Task Category_Task { get; set; }
        public int? Notify_Id { get;  set; }
        public Notification Notification { get; set; }
    }
    }

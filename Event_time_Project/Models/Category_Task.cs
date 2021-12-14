using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Event_time_Project.Models
{
    public class Category_Task
    {
        [Key]
        public int Category_Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Category Name is Required")]
        public string Name { get; set; }
    }
}
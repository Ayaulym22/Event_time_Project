using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Event_time_Project.Models
{
    public class User
    {
        [Key]
        public int User_id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "User Name is Required")]
        public string User_name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Surname is Required")]
        public string Surname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Name is Required.")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Name is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone Number is Required.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public int? Event_id { get; set; }
        public Event Event { get; set; }

        public int? Task_id { get; set; }
        public Task Task { get; set; }

        public int? Calendar_id { get; set; }
        public Calendar Calendar { get; set; }
    }
}
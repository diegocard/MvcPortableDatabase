using System;
using System.ComponentModel.DataAnnotations;
namespace PortableDatabaseExample.Models
{
    public class Task
    {
        public int ID             { get; set; }
        [Required]
        public DateTime Date      { get; set; }
        [Required]
        public string Description { get; set; }
        public bool Done          { get; set; }
    }
}
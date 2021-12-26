using OdevSonHali.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApp_ASP.NET.Models
{
    public class Comment 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime ModifiedOn { get; set; }
        [Required, StringLength(300)]
        public string Text { get; set; }
        public Story Story { get; set; }
        public YourStoryUser Owner { get; set; }
    }
}

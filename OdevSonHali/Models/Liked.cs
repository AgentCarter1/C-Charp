using OdevSonHali.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApp_ASP.NET.Models
{
    public class Liked 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime ModifiedOn { get; set; }
        public string ModifiedUsername { get; set; }
        public virtual Story Story { get; set; }
        public virtual YourStoryUser LikedUser { get; set; }
    }
}

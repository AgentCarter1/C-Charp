using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApp_ASP.NET.Models
{
    public class Category 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime ModifiedOn { get; set; }
        [Required, StringLength(50)]
        public string Title { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        public List<Story> Storys { get; set; }
        

    }
}

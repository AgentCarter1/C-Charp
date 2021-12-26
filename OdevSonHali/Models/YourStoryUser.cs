using Microsoft.AspNetCore.Identity;
using MovieWebApp_ASP.NET.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OdevSonHali.Models
{
    public class YourStoryUser : IdentityUser
    {
        
       
        public string Adi { get; set; }
        public string Soyadi { get; set; }

        public bool IsAdmin { get; set; }
        public List<Story> Storys { get; set; }
        public List<Comment> Comments { get; set; }
        public virtual List<Liked> Likes { get; set; }
    }
}

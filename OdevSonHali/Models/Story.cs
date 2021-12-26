
using Microsoft.AspNetCore.Http;
using OdevSonHali.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieWebApp_ASP.NET.Models
{
    public class Story 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime ModifiedOn { get; set; }
        public string ModifiedUsername { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public bool IsDraft { get; set; }
        public int LikeCount { get; set; }
        public int CategoryId { get; set; }
        public virtual YourStoryUser Owner { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Liked> Likes { get; set; }
        public Story()
        {
            Comments = new List<Comment>();
            Likes = new List<Liked>();
        }

    }
}
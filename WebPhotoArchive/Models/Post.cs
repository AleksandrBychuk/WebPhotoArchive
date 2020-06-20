using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebPhotoArchive.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public byte[] Photo { get; set; }
        [Column(TypeName = ("integer"))]
        public int UserDoId { get; set; }
        [Column(TypeName = ("varchar(250)"))]
        public string Description { get; set; }
        [Column(TypeName = ("varchar(250)"))]
        public string UserDoName { get; set; }
        public DateTime Time { get; set; }
    }
}
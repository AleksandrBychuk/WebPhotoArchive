using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPhotoArchive.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = ("varchar(250)"))]
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public int? PostId { get; set; }
        [Column(TypeName = ("varchar(250)"))]
        public string NameComment { get; set; }
    }
}
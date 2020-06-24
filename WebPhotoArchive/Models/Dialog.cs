using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebPhotoArchive.Models
{
    public class Dialog
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = ("integer"))]
        public int FromId { get; set; }
        [Column(TypeName = ("integer"))]
        public int ToId { get; set; }
        [Column(TypeName = ("varchar(250)"))]
        public string FromName { get; set; }
        [Column(TypeName = ("varchar(250)"))]
        public string ToName { get; set; }
        [Column(TypeName = ("varchar(250)"))]
        public string LastMessage { get; set; }
        public DateTime LastMessageTime { get; set; }
        public DateTime Time { get; set; }
    }
}
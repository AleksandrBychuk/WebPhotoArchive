using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace WebPhotoArchive.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = ("integer"))]
        public int DialogId { get; set; }
        [Column(TypeName = ("varchar(250)"))]
        public string Name { get; set; }
        [Column(TypeName = ("varchar(250)"))]
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebPhotoArchive.Models
{
    public class Like
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = ("integer"))]
        public int LikerId { get; set; }
        [Column(TypeName = ("integer"))]
        public int LikingId { get; set; }
        public DateTime Time { get; set; }
    }
}
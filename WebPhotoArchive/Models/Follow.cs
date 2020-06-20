using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebPhotoArchive.Models
{
    public class Follow
    {
        [Key]
        public int FollowId { get; set; }
        [Column(TypeName = ("integer"))]
        public int FollowerId { get; set; }
        [Column(TypeName = ("integer"))]
        public int FollowingId { get; set; }
        public DateTime Time { get; set; }
    }
}
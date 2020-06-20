using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPhotoArchive.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = ("varchar(250)"))]
        public string Login { get; set; }
        [Column(TypeName = ("varchar(250)"))]
        public string Password { get; set; }
        [Column(TypeName = ("varchar(250)"))]
        public string FullName { get; set; }
        [Column(TypeName = ("varchar(250)"))]
        public string Description { get; set; }
        [Column(TypeName = ("varchar(250)"))]
        public string Email { get; set; }
        [Column(TypeName = ("integer"))]
        public int PhoneNumber { get; set; }
        [Column(TypeName = ("integer"))]
        public int Gender { get; set; }
        [Column(TypeName = ("varchar(250)"))]
        public string Website { get; set; }
        [Column(TypeName = ("integer"))]
        public int TypeProfile { get; set; }
        public byte[] Photo { get; set; }
        [Column(TypeName = ("integer"))]
        public int Postnum { get; set; }
        [Column(TypeName = ("integer"))]
        public int Followers { get; set; }
        [Column(TypeName = ("integer"))]
        public int Following { get; set; }
    }
}
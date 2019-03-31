using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProHallManagement.Models
{
    public class User
    {


        public User()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        [NotMapped]
        public string ConfirmEmail { get; set; }

        public string Password { get; set; }
        [NotMapped]
        public string ConformPassword { get; set; }


        public DateTime CreatedAt { get; set; }

        public int UserCategoryId { get; set; }
        [ForeignKey("UserCategoryId")]
        public virtual UserCategory UserCategory { get; set; }


        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<UComment> UComments { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UAlbum> UAlbums { get; set; }
        public virtual ICollection<UPost> UPosts { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProHallManagement.Models
{
    public class PImage
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }


        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual UPost UPost { get; set; }


        public int AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public virtual UAlbum UAlbum { get; set; }


        public bool IsProfilePic { get; set; }
        public bool IsCoverPic { get; set; }


        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

    }
}
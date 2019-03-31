using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProHallManagement.Models
{
    public class UImage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        public int AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public virtual UAlbum UAlbum { get; set; }


        public bool IsProfilePic { get; set; }
        public bool IsCoverPic { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
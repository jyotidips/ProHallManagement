using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProHallManagement.Models;

namespace ProHallManagement.Helpers
{
    public interface IPostRepo
    {
        List<UPost> GetAllPost();
        List<PImage> GetPostImages();
        PImage GetPostImageById(int id);
        List<UPost> GetAllPostById(int id);

    }
}
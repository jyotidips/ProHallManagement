using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProHallManagement.Models;

namespace ProHallManagement.Helpers
{


    public class PostManage : IPostRepo
    {
        private readonly DataContext _Context;


        public PostManage()
        {
            this._Context = new DataContext();

        }

        public List<UPost> GetAllPost()
        {

            List<UPost> posts = _Context.UPosts.ToList();
            return posts;
        }

        public PImage GetPostImageById(int id)
        {
            var post = _Context.PImages.Where(i => i.Id == id).Single();
            return post;
        }

        public List<PImage> GetPostImages()
        {

            var postImages = _Context.PImages.ToList();
            return postImages;
        }




        public List<UPost> GetAllPostById(int id)
        {
            var post = _Context.UPosts.Where(p => p.UserId == id).ToList();
            return post;
        }



    }
}
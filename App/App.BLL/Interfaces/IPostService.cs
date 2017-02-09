using System;
using System.Collections.Generic;
using App.BLL.DTO;

namespace App.BLL.Interfaces
{
    public interface IPostService
    {
        void CreatePost(PostDTO postDto);

        void EditPost(PostDTO postDto);
        PostDTO GetPost(int? id);
        IEnumerable<PostDTO> GetPosts();

        void DeletePost(int? id);

        IEnumerable<PostDTO> GetPostsByCategory(string category, int page);

        int Count();

    }
}

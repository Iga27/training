using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.BLL.Interfaces;
using App.DAL.Entities;
using App.DAL.Interfaces;
using App.BLL.DTO;
using App.BLL.Infrastructure;
using AutoMapper;
using App.BLL.BusinessModels;

namespace App.BLL.Services
{
    
    public class PostService : IPostService
    {
        IUnitOfWork DB { get; set; }
        public PostService(IUnitOfWork uow)
        {
            DB = uow;
        }
        public void CreatePost(PostDTO postDto)
        {
            Post post = new Post
            {
                Description=postDto.Description,
                Category=postDto.Category,
                UserId = postDto.UserId,
                Price=postDto.Price,
                Date=postDto.Date
            };
            DB.Posts.Create(post);
            DB.Save();
        }

        public PostDTO GetPost(int? id)
        {
            if (id == null)
                throw new ValidationException("укажите id поста","");

            var post = DB.Posts.Get((int)id);
            if (post == null)
                throw new ValidationException("данный пост не найден","");

            Mapper.Initialize(m => m.CreateMap<Post, PostDTO>());
            return Mapper.Map<Post, PostDTO>(post);
        }

        public IEnumerable<PostDTO> GetPostsByCategory(string category,int page)
        {
            if (!String.IsNullOrEmpty(category) && !category.Equals("все")) 
            {
                Mapper.Initialize(m => m.CreateMap<Post, PostDTO>());
                return Mapper.Map<IEnumerable<Post>, List<PostDTO>>(DB.Posts.Find(m => m.Category == category,page));
                
            }
            else
            {
                Mapper.Initialize(m => m.CreateMap<Post, PostDTO>());
                return Mapper.Map<IEnumerable<Post>, List<PostDTO>>(DB.Posts.GetAll(page));
            }
        }

        public IEnumerable<PostDTO>GetPosts() 
        {
            Mapper.Initialize(m => m.CreateMap<Post, PostDTO>());
            return Mapper.Map<IEnumerable<Post>,List<PostDTO>>(DB.Posts.GetAll());
        }

        public void EditPost(PostDTO postDto)
        {
            Mapper.Initialize(m => m.CreateMap<PostDTO, Post>());
            Post post= Mapper.Map<PostDTO,Post>(postDto);
            DB.Posts.Update(post);
            DB.Save();     
        }

        public int Count()
        {
            return DB.Posts.Count();
        }

        public void DeletePost(int? id)
        {
            DB.Posts.Delete((int)id); 
            DB.Save();
        }

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}

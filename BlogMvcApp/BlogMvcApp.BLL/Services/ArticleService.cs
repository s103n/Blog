﻿using BlogMvcApp.BLL.Interfaces;
using BlogMvcApp.DLL.Entities;
using BlogMvcApp.DLL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlogMvcApp.BLL.Services
{
    public class ArticleService : IArticleService
    {
        private IUnitOfWork Database { get; }

        public ArticleService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public Article GetArticleById(int id)
        {
            var article = Database.Articles.Get(id);

            return article;
        }

        public IEnumerable<Article> GetArticles()
        {
            return Database.Articles.GetAll();
        }

        public IEnumerable<Article> GetArticlesByGenre(Genre genre)
        {
            return Database.Articles.GetAll()
                .Where(article => article.Genre.Name == genre.Name);
        }

        public void EditArticle(Article article)
        {
            Database.Articles.Update(article);
            Database.Save();
        }

        public IEnumerable<Article> GetArticlesByGenreMood(bool mood)
        {
            return Database.Articles.GetDbSet()
                .Include(article => article.Genre)
                .Where(article => article.Genre.Mood && mood);
        }

        public void CreateArticle(Article article)
        {
            Database.Articles.Create(article);
            Database.Save();
        }

        public void DeleteArticle(int id)
        {
            Database.Articles.Delete(id);
            Database.Save();
        }

        public void DeleteArticle(Article article)
        {
            Database.Articles.Delete(article.Id);
            Database.Save();
        }
    }
}
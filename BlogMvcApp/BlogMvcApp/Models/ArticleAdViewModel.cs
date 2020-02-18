﻿using System;

namespace BlogMvcApp.Models
{
    public class ArticleAdViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int CommentCount { get; set; }
    }
}
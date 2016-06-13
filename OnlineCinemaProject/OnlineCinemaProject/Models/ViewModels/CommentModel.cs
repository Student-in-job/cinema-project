using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineCinemaProject.Models.ViewModels
{
    public class CommentModel:review
    {
        public UserViewModel user { get; set; }
    }

    public class UserViewModel
    {
        public string user_id { get; set; }
        public string name { get; set; }
    }
}
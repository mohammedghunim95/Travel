using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Travel.Models
{
    public class Post
    {
        public int Id { get; set; }

        [AllowHtml]
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public ApplicationUser user { get; set; }
    }
}
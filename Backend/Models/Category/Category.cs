using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Backend.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Status { get; set; }
        public int Position { get; set; }
        public string CreatedAt { get; set; }

        public Category(int id, string name, string desc, string img, int status, int pos, string dateTime)
        {
            CategoryId = id;
            CategoryName = name;
            Description = desc;
            Image = img;
            Status = status;
            Position = pos;
            CreatedAt = dateTime;
        }
    }

}
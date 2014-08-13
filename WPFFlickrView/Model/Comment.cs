using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFFlickrView.Model
{
    public class Comment
    {
        public string Id { get; set;  }
        public string UserId { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }
        public string UserName { get; set; }
    }
}

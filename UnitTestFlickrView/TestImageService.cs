using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFFlickrView.Model;

namespace UnitTestFlickrView
{
    class TestImageService : IImageService
    {
        public void Search(ImageSearchQuery query, Action<IEnumerable<Image>, Exception> result)
        {
            var images = new List<Image>();
            images.Add(new Image() { Title = "A", Thumbnail = "https://aaa.com/thumbnail", Description = "A description", Url = "https://aaa.ru/full" , Tags="T1" });
            images.Add(new Image() { Title = "B", Thumbnail = "https://bbb.com/thumbnail", Description = "B description", Url = "https://bbb.ru/full", Tags = "T2" });
            images.Add(new Image() { Title = "C", Thumbnail = "https://ccc.com/thumbnail", Description = "C description", Url = "https://ccc.ru/full", Tags = "T1 T2" });
            images.Add(new Image() { Title = "D", Thumbnail = "https://ddd.com/thumbnail", Description = "D description", Url = "https://ddd.ru/full", Tags = "T3" });
            
            var filtered = from i in images where i.Tags.Contains(query.Tags[0]) select i;

            result(filtered, null);
        }

        public void Comments(string id, Action<IEnumerable<Comment>, Exception> result)
        {
            var comments = new List<Comment>();
            comments.Add(new Comment() { Id = id, Body  = "1 Body",  UserName = "1 user", Url = "https://aaa.ru/1", UserId=id });
            result(comments, null);
        }
    }
}

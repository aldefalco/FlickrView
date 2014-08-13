using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFFlickrView.Model;

namespace UnitTestFlickrView
{
    class TestLotImageService : IImageService
    {
        public void Search(ImageSearchQuery query, Action<IEnumerable<Image>, Exception> result)
        {
            var images = new List<Image>();
            images.Add(new Image() { Title = "P1", Thumbnail = "https://aaa.com/thumbnail", Description = "A description", Url = "https://aaa.ru/full" , Tags="T1" });
            images.Add(new Image() { Title = "B", Thumbnail = "https://bbb.com/thumbnail", Description = "B description", Url = "https://bbb.ru/full", Tags = "T2" });
            images.Add(new Image() { Title = "C", Thumbnail = "https://ccc.com/thumbnail", Description = "C description", Url = "https://ccc.ru/full", Tags = "T1 T2" });
            images.Add(new Image() { Title = "D", Thumbnail = "https://ddd.com/thumbnail", Description = "D description", Url = "https://ddd.ru/full", Tags = "T3" });
            images.Add(new Image() { Title = "AA", Thumbnail = "https://aaa.com/thumbnail", Description = "AA description", Url = "https://aaa.ru/full", Tags = "T1" });
            images.Add(new Image() { Title = "AA", Thumbnail = "https://aaa.com/thumbnail", Description = "AA description", Url = "https://aaa.ru/full", Tags = "T1" });
            images.Add(new Image() { Title = "AA", Thumbnail = "https://aaa.com/thumbnail", Description = "AA description", Url = "https://aaa.ru/full", Tags = "T1" });
            images.Add(new Image() { Title = "AA", Thumbnail = "https://aaa.com/thumbnail", Description = "AA description", Url = "https://aaa.ru/full", Tags = "T1" });
            images.Add(new Image() { Title = "P2", Thumbnail = "https://aaa.com/thumbnail", Description = "AA description", Url = "https://aaa.ru/full", Tags = "T1" });
            images.Add(new Image() { Title = "BB", Thumbnail = "https://aaa.com/thumbnail", Description = "AA description", Url = "https://aaa.ru/full", Tags = "T1" });
            images.Add(new Image() { Title = "AA", Thumbnail = "https://aaa.com/thumbnail", Description = "AA description", Url = "https://aaa.ru/full", Tags = "T1" });
            images.Add(new Image() { Title = "CC", Thumbnail = "https://ccc.com/thumbnail", Description = "CC description", Url = "https://ccc.ru/full", Tags = "T1 T2" });
            images.Add(new Image() { Title = "CC", Thumbnail = "https://ccc.com/thumbnail", Description = "CC description", Url = "https://ccc.ru/full", Tags = "T1 T2" });
            images.Add(new Image() { Title = "CC", Thumbnail = "https://ccc.com/thumbnail", Description = "CC description", Url = "https://ccc.ru/full", Tags = "T1 T2" });

            
            //var filtered = from i in images where i.Tags.Contains(query.Tags[0]) select i;

            result(images, null);
        }

        public void Comments(string id, Action<IEnumerable<Comment>, Exception> result)
        {
            throw new NotImplementedException();
        }
    }
}

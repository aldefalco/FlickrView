using FlickrNet;
using System;
using System.Collections.Generic;
using WPFFlickrView.Model;

namespace WPFFlickrView.Design
{
    public class DesignService : IImageService
    {
        public void Search(ImageSearchQuery option, Action<IEnumerable<Image>, Exception> callback)
        {
            var images = new List<Image>();
            images.Add(new Image() { Title = "Google", Thumbnail = "https://www.google.ru/images/srpr/logo11w.png", Description = "Google description", Url = "https://www.google.ru/images/srpr/logo11w.png" });
            images.Add(new Image() { Title = "Microsoft", Thumbnail = "https://c.s-microsoft.com/ru-ru/CMSImages/mslogo.png?version=856673f8-e6be-0476-6669-d5bf2300391d" });
            images.Add(new Image() { Title = "Google+", Thumbnail = "https://www.google.ru/images/srpr/logo11w.png" });
            images.Add(new Image() { Title = "Microsoft", Thumbnail = "https://c.s-microsoft.com/ru-ru/CMSImages/mslogo.png?version=856673f8-e6be-0476-6669-d5bf2300391d" });
            callback(images, null);
        }

        public void Comments(string id, Action<IEnumerable<Comment>, Exception> result)
        {
            throw new NotImplementedException();
        }
        
    }
}
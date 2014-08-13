using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFFlickrView.Model
{
    public interface IImageService
    {
        void Search(ImageSearchQuery query, Action<IEnumerable<Image>, Exception> result);
        void Comments(string id, Action<IEnumerable<Comment>, Exception> result);
    }
}

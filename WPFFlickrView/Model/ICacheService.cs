using System;
using System.Collections.Generic;

namespace WPFFlickrView.Model
{
    public interface ICacheService
    {
        IEnumerable<Image> GetCache(string key);
        void AddCache(string key, IEnumerable<Image> images);
        bool IsCached(string key);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFFlickrView.Model
{
    public class CacheService : Model.ICacheService
    {
        Dictionary<string, IList<Image>> _memoryCache = new Dictionary<string,IList<Image>>();

        public bool IsCached(string key)
        {
            return _memoryCache.ContainsKey(key);
        }

        public IEnumerable<Image> GetCache(string key)
        {
            if (IsCached(key))
            {
                return _memoryCache[key];
            }

            return null;
        }

        public async void AddCache(string key, IEnumerable<Image> images)
        {
            if (IsCached(key))
                return;

            var list = await Task.Run<IList<Image>>(() => { 
                return images.ToList();
            });

            _memoryCache.Add(key, list);
        }
    }
}

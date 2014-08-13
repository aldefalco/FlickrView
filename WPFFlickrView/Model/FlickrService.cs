using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WPFFlickrView.Model
{
    public class FlickrService : IImageService
    {
        public const string ApiKey = "23a8b86a42e5e817b67ced3679a4cf9a";
        public const string SharedSecret = "fba0f4f0c6fe4043";
        public readonly OAuthAccessToken token;

        private readonly ICacheService _cache;

        public FlickrService(ICacheService cache)
        {
            //TODO: used hardcoded authentication temporary. Security issue! fix it as soon as possible
            token = new OAuthAccessToken
            {
                FullName = "Alex Sherby",
                Token = "72157645974172627-02eb7fb2a4dd7a06",
                TokenSecret = "2c6cd42f8714fa25",
                UserId = "124777160@N02",
                Username = "alex.sherby"
            };

            _cache = cache;
        }

        private Flickr GetFlickr()
        {
            Flickr f = new Flickr(ApiKey, SharedSecret);
            f.OAuthAccessToken = token.Token;
            f.OAuthAccessTokenSecret = token.TokenSecret;
            return f;
        }

        public async void Search(ImageSearchQuery query, Action<IEnumerable<Image>, Exception> callback)
        {
            if (_cache != null && _cache.IsCached(query.ToString()))
            {
                callback(_cache.GetCache(query.ToString()), null);
            }

            var f = GetFlickr();

            PhotoSearchOptions o = new PhotoSearchOptions();

            if (query.UserOnly)
                o.Username = token.Username;

            o.Extras = PhotoSearchExtras.AllUrls | PhotoSearchExtras.Description | PhotoSearchExtras.OwnerName;
            o.SortOrder = PhotoSearchSortOrder.Relevance;

            if (query.Tags != null && query.Tags.Count > 0)
                o.Tags = String.Join(" ", query.Tags);

            /*
            f.PhotosSearchAsync(o, result => {

                if (result.HasError)
                {
                    callback(null, new Exception(result.ErrorMessage));
                }

                var a = (from r in result.Result select new Image { Title = r.Title, Url = r.OriginalUrl }).Take(20);
                callback(a, null);
            });
            */

            var taskResult = await Task.Run<FlickrResult<PhotoCollection>>(() =>
            {
                var result = new FlickrResult<PhotoCollection>();
                try
                {
                    result.Result = f.PhotosSearch(o);
                }
                catch (Exception ex)
                {
                    result.HasError = true;
                    result.ErrorMessage = ex.Message;
                    result.Error = ex;
                }
                return result;
            });

            var images = (from r in taskResult.Result
                     select new Image
                         {
                             Id = r.PhotoId,
                             Title = r.Title,
                             Url = r.LargeUrl,
                             Thumbnail = r.ThumbnailUrl,
                             Description = r.Description + string.Join(" ", r.Tags.ToArray<string>())
                         });

            _cache.AddCache(query.ToString(), images);
            callback(images, null);
        }

        public async void Comments(string id, Action<IEnumerable<Comment>, Exception> callback)
        {
            var f = GetFlickr();

            var taskResult = await Task.Run<FlickrResult<PhotoCommentCollection>>(() =>
            {
                var result = new FlickrResult<PhotoCommentCollection>();
                try
                {
                    result.Result = f.PhotosCommentsGetList(id);
                }
                catch (Exception ex)
                {
                    result.HasError = true;
                    result.ErrorMessage = ex.Message;
                    result.Error = ex;
                }
                return result;
            });

            var comments = (from r in taskResult.Result
                     select new Comment
                     {
                         Id = r.CommentId,
                         Body = r.CommentHtml,
                         UserId = r.AuthorUserId,
                         UserName = r.AuthorUserName,
                         Url = r.Permalink

                     });
            callback(comments, null);
        }
    }
}
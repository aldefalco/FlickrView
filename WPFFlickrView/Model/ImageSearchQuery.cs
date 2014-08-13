using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFFlickrView.Model
{
    public class ImageSearchQuery
    {
        public ImageSearchQuery()
        {
            Tags = new List<string>();
            SortOrders = new List<string>();
        }

        public ImageSearchQuery FilterByTag(string tag)
        {
            Tags.Add(tag);
            return this;
        }

        public ImageSearchQuery FilterByTags(string tags)
        {
            Tags.AddRange(tags.Split(' '));
            return this;
        }

        public ImageSearchQuery Sort(string sortOrder)
        {
            SortOrders.Add(sortOrder);
            return this;
        }

        public ImageSearchQuery ForUserOnly(bool val)
        {
            UserOnly = val;
            return this;
        }

        public List<string> Tags { get; private set; }
        public List<string> SortOrders { get; private set; }
        public bool UserOnly { get; private set; }

        public override string ToString()
        {
            return string.Join("-", Tags) + " Sort: " + string.Join("-", SortOrders);
        }
    }
}

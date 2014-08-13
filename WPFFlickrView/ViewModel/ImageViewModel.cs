using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using WPFFlickrView.Model;

namespace WPFFlickrView.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ImageViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="Id" /> property's name.
        /// </summary>
        public const string IdPropertyName = "Id";

        private string _id = "";

        /// <summary>
        /// Sets and gets the Id property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id == value)
                {
                    return;
                }

                RaisePropertyChanging(IdPropertyName);
                _id = value;
                RaisePropertyChanged(IdPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Url" /> property's name.
        /// </summary>
        public const string UrlPropertyName = "Url";

        private string _url = "";

        /// <summary>
        /// Sets and gets the Url property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Url
        {
            get
            {
                return _url;
            }

            set
            {
                if (_url == value)
                {
                    return;
                }

                RaisePropertyChanging(UrlPropertyName);
                _url = value;
                RaisePropertyChanged(UrlPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="Title" /> property's name.
        /// </summary>
        public const string TitlePropertyName = "Title";

        private string _title = "";

        /// <summary>
        /// Sets and gets the Title property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (_title == value)
                {
                    return;
                }

                RaisePropertyChanging(TitlePropertyName);
                _title = value;
                RaisePropertyChanged(TitlePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Thumbnail" /> property's name.
        /// </summary>
        public const string ThumbnailPropertyName = "Thumbnail";

        private string _thumbnail = "";

        /// <summary>
        /// Sets and gets the Thumbnail property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Thumbnail
        {
            get
            {
                return _thumbnail;
            }

            set
            {
                if (_thumbnail == value)
                {
                    return;
                }

                RaisePropertyChanging(ThumbnailPropertyName);
                _thumbnail = value;
                RaisePropertyChanged(ThumbnailPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="Description" /> property's name.
        /// </summary>
        public const string DescriptionPropertyName = "Description";

        private string _desctiption = "";

        /// <summary>
        /// Sets and gets the Description property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Description
        {
            get
            {
                return _desctiption;
            }

            set
            {
                if (_desctiption == value)
                {
                    return;
                }

                RaisePropertyChanging(DescriptionPropertyName);
                _desctiption = value;
                RaisePropertyChanged(DescriptionPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Comments" /> property's name.
        /// </summary>
        public const string CommentsPropertyName = "Comments";

        private ObservableCollection<CommentViewModel> _comments = null;

        /// <summary>
        /// Sets and gets the Comments property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<CommentViewModel> Comments
        {
            get
            {
                return _comments;
            }

            set
            {
                if (_comments == value)
                {
                    return;
                }

                RaisePropertyChanging(CommentsPropertyName);
                _comments = value;
                RaisePropertyChanged(CommentsPropertyName);
            }
        }

        /// <summary>
        /// Initializes a new instance of the ImageViewModel class.
        /// </summary>
        public ImageViewModel()
        {
        }
    }
}
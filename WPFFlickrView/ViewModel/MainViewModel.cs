using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using WPFFlickrView.Model;
using System.Linq;

namespace WPFFlickrView.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IImageService _dataService;

        /// <summary>
        /// The <see cref="Images" /> property's name.
        /// </summary>
        public const string ImagesPropertyName = "Images";

        private ObservableCollection<ImageViewModel> _images = new ObservableCollection<ImageViewModel>();

        /// <summary>
        /// Sets and gets the Images property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<ImageViewModel> Images
        {
            get
            {
                return _images;
            }

            set
            {
                if (_images == value)
                {
                    return;
                }

                RaisePropertyChanging(ImagesPropertyName);
                _images = value;
                RaisePropertyChanged(ImagesPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="TagsFilter" /> property's name.
        /// </summary>
        public const string TagsFilterPropertyName = "TagsFilter";

        private string _tagsFilter = "";

        /// <summary>
        /// Sets and gets the TagsFilter property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TagsFilter
        {
            get
            {
                return _tagsFilter;
            }

            set
            {
                if (_tagsFilter == value)
                {
                    return;
                }

                RaisePropertyChanging(TagsFilterPropertyName);
                _tagsFilter = value;
                RaisePropertyChanged(TagsFilterPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsReady" /> property's name.
        /// </summary>
        public const string IsReadyPropertyName = "IsReady";

        private bool _isReady = true;

        /// <summary>
        /// Sets and gets the IsReady property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsReady
        {
            get
            {
                return _isReady;
            }

            set
            {
                if (_isReady == value)
                {
                    return;
                }

                RaisePropertyChanging(IsReadyPropertyName);
                _isReady = value;
                RaisePropertyChanged(IsReadyPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="OnlyUser" /> property's name.
        /// </summary>
        public const string OnlyUserPropertyName = "OnlyUser";

        private bool _onlyUser = false;

        /// <summary>
        /// Sets and gets the OnlyUser property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool OnlyUser
        {
            get
            {
                return _onlyUser;
            }

            set
            {
                if (_onlyUser == value)
                {
                    return;
                }

                RaisePropertyChanging(OnlyUserPropertyName);
                _onlyUser = value;
                RaisePropertyChanged(OnlyUserPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Current" /> property's name.
        /// </summary>
        public const string CurrentPropertyName = "Current";

        private ImageViewModel _current = null;

        /// <summary>
        /// Sets and gets the Current property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ImageViewModel Current
        {
            get
            {
                return _current;
            }

            set
            {
                if (_current == value)
                {
                    return;
                }

                RaisePropertyChanging(CurrentPropertyName);
                _current = value;
                RaisePropertyChanged(CurrentPropertyName);
            }
        }

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
        /// The <see cref="PageSize" /> property's name.
        /// </summary>
        public const string PageSizePropertyName = "PageSize";

        private int _pageSize = 20;

        /// <summary>
        /// Sets and gets the PageSize property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int PageSize
        {
            get
            {
                return _pageSize;
            }

            set
            {
                if (_pageSize == value)
                {
                    return;
                }

                RaisePropertyChanging(PageSizePropertyName);
                _pageSize = value;
                RaisePropertyChanged(PageSizePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Page" /> property's name.
        /// </summary>
        public const string PagePropertyName = "Page";

        private int _page = 0;

        /// <summary>
        /// Sets and gets the Page property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Page
        {
            get
            {
                return _page;
            }

            set
            {
                if (_page == value)
                {
                    return;
                }

                RaisePropertyChanging(PagePropertyName);
                _page = value;
                RaisePropertyChanged(PagePropertyName);
            }
        }

        public RelayCommand Search { get; private set; }
        public RelayCommand<ImageViewModel> ChangeCurrent { get; private set; }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IImageService dataService)
        {
            _dataService = dataService;


            ChangeCurrent = new RelayCommand<ImageViewModel>(image =>
            {
                Current = image;

                if (Current != null)
                {
                    _dataService.Comments(image.Model.Id, (items, error) =>
                    {
                        if (error != null)
                            throw error;

                        Current.Comments = new ObservableCollection<CommentViewModel>(
                                from i in items
                                select new CommentViewModel (i) );
                    });
                }
            });


            Search = new RelayCommand(() =>
            {
                Images = null;
                _dataService.Search(new ImageSearchQuery()
                    .FilterByTags(TagsFilter).ForUserOnly(OnlyUser),
                    (items, error) =>
                    {
                        if (error != null)
                            throw error;

                        Images = new ObservableCollection<ImageViewModel>(
                            (from i in items
                            select new ImageViewModel (i)).Skip(Page*PageSize).Take(PageSize)
                           );

                        IsReady = true;
                    });

                IsReady = false;
            });

            if (IsInDesignMode)
            {
                Search.Execute(null);
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}
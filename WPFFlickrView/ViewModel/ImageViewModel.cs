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
        /// The <see cref="Model" /> property's name.
        /// </summary>
        public const string ModelPropertyName = "Model";

        private Image _model = null;

        /// <summary>
        /// Sets and gets the Model property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Image Model
        {
            get
            {
                return _model;
            }

            set
            {
                if (_model == value)
                {
                    return;
                }

                RaisePropertyChanging(ModelPropertyName);
                _model = value;
                RaisePropertyChanged(ModelPropertyName);
            }
        }

        /// <summary>
        /// Initializes a new instance of the ImageViewModel class.
        /// </summary>
        public ImageViewModel(Image model)
        {
            this._model = model;
        }
    }
}
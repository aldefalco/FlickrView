using GalaSoft.MvvmLight;
using WPFFlickrView.Model;

namespace WPFFlickrView.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CommentViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="Model" /> property's name.
        /// </summary>
        public const string ModelPropertyName = "Model";

        private Comment _model = null;

        /// <summary>
        /// Sets and gets the Model property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Comment Model
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
        /// Initializes a new instance of the CommentViewModel class.
        /// </summary>
        public CommentViewModel(Comment model)
        {
            _model = model;
        }
    }
}
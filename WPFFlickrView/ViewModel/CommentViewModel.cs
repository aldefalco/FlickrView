using GalaSoft.MvvmLight;

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
        /// The <see cref="Body" /> property's name.
        /// </summary>
        public const string BodyPropertyName = "Body";

        private string _body = "";

        /// <summary>
        /// Sets and gets the Body property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Body
        {
            get
            {
                return _body;
            }

            set
            {
                if (_body == value)
                {
                    return;
                }

                RaisePropertyChanging(BodyPropertyName);
                _body = value;
                RaisePropertyChanged(BodyPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="UserName" /> property's name.
        /// </summary>
        public const string UserNamePropertyName = "UserName";

        private string _userName = "";

        /// <summary>
        /// Sets and gets the UserName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                if (_userName == value)
                {
                    return;
                }

                RaisePropertyChanging(UserNamePropertyName);
                _userName = value;
                RaisePropertyChanged(UserNamePropertyName);
            }
        }

        /// <summary>
        /// Initializes a new instance of the CommentViewModel class.
        /// </summary>
        public CommentViewModel()
        {
        }
    }
}
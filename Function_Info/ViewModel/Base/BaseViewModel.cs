using System.ComponentModel;

namespace Function_Info.ViewModel.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Event that is raised when the property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
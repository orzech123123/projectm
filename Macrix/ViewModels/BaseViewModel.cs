using System.ComponentModel;

namespace Macrix.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

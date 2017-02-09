using System.Collections.ObjectModel;
using System.Windows.Input;
using Macrix.Commands;
using Macrix.Entities;

namespace Macrix.ViewModels
{
    public class TableViewModel : BaseViewModel
    {
        public ICommand RemoveCommand => removeCommand ?? (removeCommand = new DelegateCommand(CanRemove, Remove));
        private ObservableCollection<PersonEntity> personEntities;
        private ICommand removeCommand;

        public TableViewModel()
        {
            PersonEntities = new ObservableCollection<PersonEntity>();
        }

        public ObservableCollection<PersonEntity> PersonEntities
        {
            get { return personEntities; }
            set
            {
                personEntities = value;
                OnPropertyChanged("PersonEntities");
            }
        }
        
        private bool CanRemove(object parameter)
        {
            return true;
        }

        private void Remove(object parameter)
        {
            var index = PersonEntities.IndexOf(parameter as PersonEntity);
            if (index > -1 && index < PersonEntities.Count)
                PersonEntities.RemoveAt(index);
        }
    }
}

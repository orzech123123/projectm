using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Macrix.Commands;
using Macrix.Entities;

namespace Macrix.ViewModels
{
    public class TableViewModel : BaseViewModel
    {
        public ICommand RemoveCommand => removeCommand ?? (removeCommand = new DelegateCommand(CanRemove, Remove));
        public ICommand SaveCommand => saveCommand ?? (saveCommand = new DelegateCommand(CanSave, Save));
        public ICommand CancelCommand => cancelCommand ?? (cancelCommand = new DelegateCommand(CanCancel, Cancel));

        private ObservableCollection<PersonEntity> personEntities;
        private ICommand removeCommand;
        private ICommand saveCommand;
        private ICommand cancelCommand;

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
        
        private bool CanRemove(object entity)
        {
            return true;
        }

        private void Remove(object entity)
        {
            var index = PersonEntities.IndexOf(entity as PersonEntity);
            if (index > -1 && index < PersonEntities.Count)
                PersonEntities.RemoveAt(index);
        }

        private bool CanSave(object entity)
        {
            return PersonEntitiesChanged();
        }

        private void Save(object entity)
        {

        }
        
        private bool CanCancel(object entity)
        {
            return PersonEntitiesChanged();
        }

        private void Cancel(object entity)
        {

        }

        private bool PersonEntitiesChanged()
        {
            return PersonEntities.Any(p => p.IsChanged);
        }
    }
}

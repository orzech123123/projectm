using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Xml.Serialization;
using Macrix.Commands;
using Macrix.Entities;

namespace Macrix.ViewModels
{
    public class TableViewModel : BaseViewModel
    {
        private const string File = "macrix.xml";
        private static string Path => System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), File);

        public ICommand RemoveCommand => removeCommand ?? (removeCommand = new DelegateCommand(CanRemove, Remove));
        public ICommand SaveCommand => saveCommand ?? (saveCommand = new DelegateCommand(CanSave, Save));
        public ICommand CancelCommand => cancelCommand ?? (cancelCommand = new DelegateCommand(CanCancel, Cancel));

        private ObservableCollection<PersonEntity> personEntities;
        private ICommand removeCommand;
        private ICommand saveCommand;
        private ICommand cancelCommand;
        private readonly XmlSerializer serializer;

        private bool removed;

        public TableViewModel()
        {
            PersonEntities = new ObservableCollection<PersonEntity>();
            serializer = new XmlSerializer(typeof(PersonCollection));

            Deserialize();
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

            removed = true;
        }

        public bool CanSave(object entity)
        {
            return IsChanged();
        }

        public void Save(object entity)
        {
            Serialize();
        }

        private void SetAsUnchanged()
        {
            foreach (var personEntity in PersonEntities)
            {
                personEntity.IsChanged = false;
            }

            removed = false;
        }

        private void Serialize()
        {
            using (var stringWriter = new StringWriter())
            {
                var collection = new PersonCollection {Persons = PersonEntities.ToArray()};
                serializer.Serialize(stringWriter, collection);
                var xml = stringWriter.ToString();

                using (var fileStream = System.IO.File.Create(Path))
                {
                    var bytes = new UTF8Encoding(true).GetBytes(xml);
                    fileStream.Write(bytes, 0, bytes.Length);
                }
            }

            SetAsUnchanged();
        }

        public bool CanCancel(object entity)
        {
            return IsChanged();
        }

        public void Cancel(object entity)
        {
            Deserialize();
        }

        private void Deserialize()
        {
            if (!System.IO.File.Exists(Path))
                return;

            using (var streamReader = new StreamReader(Path))
            {
                var collection = (PersonCollection) serializer.Deserialize(streamReader);

                PersonEntities.Clear();
                foreach (var person in collection.Persons)
                    PersonEntities.Add(person);
            }

            SetAsUnchanged();
        }

        private bool IsChanged()
        {
            return PersonEntities.Any(p => p.IsChanged) || removed;
        }
    }
}

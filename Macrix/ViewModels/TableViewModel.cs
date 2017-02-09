using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Macrix.Commands;
using Macrix.Entities;

namespace Macrix.ViewModels
{
    public class TableViewModel : BaseViewModel
    {
        ObservableCollection<PersonEntity> infos;
        ICommand _command;

        public TableViewModel()
        {
            PersonsInfo = new ObservableCollection<PersonEntity>();

            PersonsInfo.Add(new PersonEntity
            {
                Firstname = "aaa",
                Lastname = "bbb",
                Birthdate = new DateTime(2011, 11, 11)
            });

            //Haha();
        }

        private void Haha()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                Application.Current.Dispatcher.Invoke((Action) delegate
                {
//                    PersonsInfo.Add(new RecordInfo { Name = "JJ", Age = 21, DateOfBirth = new DateTime(1990, 11, 27), Address = "XXXXX XXXXXXXX XX" });

                });

                Thread.Sleep(2000);
                Haha();
            }).Start();
        }

        public ObservableCollection<PersonEntity> PersonsInfo
        {
            get { return infos; }
            set
            {
                infos = value;
                OnPropertyChanged("PersonsInfo");
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                if (_command == null)
                {
                    _command = new DelegateCommand(CanExecute, Execute);
                }
                return _command;
            }
        }

        private void Execute(object parameter)
        {

//            Application.Current.Dispatcher.Invoke((Action)delegate
//            {
//                PersonsInfo.Add(new RecordInfo { Name = "JJ", Age = 21, DateOfBirth = new DateTime(1990, 11, 27), Address = "XXXXX XXXXXXXX XX" });
//
//            });

            return;

            int index = PersonsInfo.IndexOf(parameter as PersonEntity);
            if (index > -1 && index < PersonsInfo.Count)
            {
                PersonsInfo.RemoveAt(index);
            }
        }

        private bool CanExecute(object parameter)
        {
            return true;
        }
    }
}

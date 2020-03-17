using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TodoWpfApp.Resources;

namespace TodoWpfApp.ViewModels
{
    public class ControllerViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TodoItemViewModel> TodoItems { get; }

        private string _newDescription;

        public string NewDescription
        {
            get => _newDescription;
            set
            {
                _newDescription = value;
                this.OnPropertyChanged();
            }
        }

        private DateTime _newDate;

        public DateTime NewDate
        {
            get => this._newDate;
            set
            {
                this._newDate = value;
                this.OnPropertyChanged();
            }
        }

        public ICommand AddNewTodoItemCommand => new DelegateCommand(_ =>
        {
            this.TodoItems.Add(new TodoItemViewModel(this.NewDescription, this.NewDate));

            this.NewDescription = "";
            this.NewDate = DateTime.Now;
        });

        public ControllerViewModel()
        {
            this.NewDescription = "";
            this.NewDate = DateTime.Now;

            this.TodoItems = new ObservableCollection<TodoItemViewModel>();

            // For test purposes:
            this.TodoItems.Add(
                new TodoItemViewModel("Test", DateTime.Now.AddDays(1))
            );
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

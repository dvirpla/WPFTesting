using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TodoWpfApp.Resources;
using TodoWpfApp.Views;

namespace TodoWpfApp.ViewModels
{
    public class ControllerViewModel : INotifyPropertyChanged
    {
        public static string[] TodoTypes = {
            "House Chores",
            "Health and Sports",
            "Work"
        };

        public ObservableCollection<TodoItemViewModel> TodoItems { get; }

        private string _newSelectedTodoType = TodoTypes[0];

        public string NewSelectedTodoType
        {
            get => this._newSelectedTodoType;
            set
            {
                this._newSelectedTodoType = value;
                this.OnPropertyChanged();
            }
        }

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
            this.TodoItems.Add(new TodoItemViewModel(this.NewSelectedTodoType, this.NewDescription, this.NewDate));

            this.NewSelectedTodoType = TodoTypes[0];
            this.NewDescription = "";
            this.NewDate = DateTime.Now;
        });


        public ICommand NewTodoItemDialogCommand => new DelegateCommand(_ =>
        {
            var dialog = new NewTodoItemDialog(this);
            dialog.ShowDialog();
        });

        public ControllerViewModel()
        {
            this.NewDescription = "";
            this.NewDate = DateTime.Now;

            this.TodoItems = new ObservableCollection<TodoItemViewModel>();

            // For test purposes:
            this.TodoItems.Add(
                new TodoItemViewModel( TodoTypes[0], "Test", DateTime.Now.AddDays(1))
            );
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

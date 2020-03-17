using System;
using System.Collections.ObjectModel;

namespace TodoWpfApp.ViewModels
{
    public class ControllerViewModel
    {
        public ObservableCollection<TodoItemViewModel> TodoItems { get; }

        public ControllerViewModel()
        {
            this.TodoItems = new ObservableCollection<TodoItemViewModel>();

            // For test purposes:
            this.TodoItems.Add(
                new TodoItemViewModel("Test", DateTime.Now.AddDays(1))
            );
        }
    }
}

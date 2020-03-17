using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoWpfApp.Resources;

namespace TodoWpfApp.ViewModels
{
    public class TodoItemViewModel : INotifyPropertyChanged
    {
        public string Description { get; set; }

        public DateTime DueBy { get; set; }

        private bool _isDone;

        public bool IsDone
        {
            get => this._isDone;

            set
            {
                this._isDone = value;
                this.OnPropertyChanged();
            }
        }

        public ICommand MarkAsDoneCommand => new DelegateCommand(_ => { this.IsDone = true; });

        public TodoItemViewModel(string description, DateTime dueBy)
        {
            this.Description = description;
            this.DueBy = dueBy;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TodoWpfApp.Views
{
    /// <summary>
    /// Interaction logic for NewTodoItemView.xaml
    /// </summary>
    public partial class NewTodoItemView : UserControl
    {
        public NewTodoItemView()
        {
            InitializeComponent();
        }

        private void NewTodoItemView_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.TodoTypeSelector.Focus();
        }
    }
}

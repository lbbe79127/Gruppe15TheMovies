using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TheMovies.UI.ViewModels;

namespace TheMovies.UI.Views
{
    /// <summary>
    /// Interaction logic for ProgramWindow.xaml
    /// </summary>
    public partial class ProgramWindow : Window
    {
        public ProgramWindow()
        {
            InitializeComponent();
            DataContext = new ProgramWindowViewModel();
        }

        private void listboxCinema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

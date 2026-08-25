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
using TheMovies.Core.Repositories;
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
            IShowingRepository showingRepository = new FileShowingRepository();
            IMovieRepository movieRepository = new FileMovieRepository();
            DataContext = new ProgramWindowViewModel(showingRepository, movieRepository);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            DayProgramWindow dayProgramWindow = new DayProgramWindow();
            dayProgramWindow.ShowDialog();
        }
    }
}

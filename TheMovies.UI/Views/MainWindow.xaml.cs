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

namespace TheMovies.UI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Exit.");
            Environment.Exit(0);
        }

        //To be able to run whole xaml design, made instances in MainWindow.
        private void btnFilmRegister_Click(object sender, RoutedEventArgs e)
        {
            //Create an instance: filmRegisterWindow:(variable) of Class: FilmRegisterWindow 
            FilmRegisterWindow filmRegisterWindow = new FilmRegisterWindow();
            filmRegisterWindow.ShowDialog();
        }

        private void btnProgram_Click(object sender, RoutedEventArgs e)
        {
            ProgramWindow programWindow = new ProgramWindow();
            programWindow.ShowDialog();
        }
    }
}

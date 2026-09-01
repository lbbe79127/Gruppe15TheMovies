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
using TheMovies.Core.Models;
using TheMovies.Core.Repositories;

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
            CheckExistingCinemas();

            IScreenRepository screenRepository = new FileScreenRepository();
            IEnumerable<Screen> allScreens = screenRepository.GetAll();
            if (!allScreens.Any())
            {
            screenRepository.Add(new Screen(0,1,80,0));
            screenRepository.Add(new Screen(1, 2, 80, 0));
            screenRepository.Add(new Screen(2, 3, 60, 0));
            screenRepository.Add(new Screen(3, 4, 80, 0));
            screenRepository.Add(new Screen(4, 1, 80, 1));
            screenRepository.Add(new Screen(5, 2, 40, 1));
            screenRepository.Add(new Screen(6, 1, 80, 2));
            screenRepository.Add(new Screen(7, 2, 30, 2));
            screenRepository.Add(new Screen(8, 1, 70, 3)); //Alt + Shift
            }
        }

        private static void CheckExistingCinemas()
        {
            ICinemaRepository repository = new FileCinemaRepository();
            IEnumerable<Cinema> allCinemas = repository.GetAll();
            if (allCinemas.Count() == 0)
            {
                AddDefaultCinemaData(repository);
            }
        }

        private static void AddDefaultCinemaData(ICinemaRepository repository)
        {
            repository.Add(new Cinema(0, "Hjerm"));
            repository.Add(new Cinema(1, "Videbæk"));
            repository.Add(new Cinema(2, "Thorsminde"));
            repository.Add(new Cinema(3, "Ræhr")); 
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

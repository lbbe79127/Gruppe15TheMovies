using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Text;
using TheMovies.Core.Models;
using TheMovies.Core.Repositories;
using System.Windows;

namespace TheMovies.UI.ViewModels
{
    class ProgramWindowViewModel : ViewModelBase
    {
        //----- Repositories ---- Cinema missing ----
        private readonly IScreenRepository _screenRepository;
        private readonly IShowingRepository _showingRepository;
        private readonly IMovieRepository _movieRepository;
        //private readonly ICinemaRepository _cinemaRepository;

        // --------- Observable Collections --------- 
        private ObservableCollection<Cinema> _cinemas;
        public ObservableCollection<Cinema> Cinemas
        {
                get { return _cinemas; }
                set { _cinemas = value; }
        }

        // --------- Properties w PropertyChanged --------- 
        private Cinema _selectedCinema;
        public Cinema SelectedCinema
        {
            get { return _selectedCinema; }
            set { _selectedCinema = value; OnPropertyChanged(); }
        }

        private string _selectedDate;
        public string SelectedDate
        {
            get { return _selectedDate; }
            set { _selectedDate = value; OnPropertyChanged(); }
        }

        private string _selectedScreen;
        public string SelectedScreen
        {
            get { return _selectedScreen; }
            set { _selectedScreen = value; OnPropertyChanged(); }
        }

        // --------- RelayCommands --------- 
        public ICommand RegisterCommand { get; private set; }


        // --------- Contructor --------- 
        public ProgramWindowViewModel()
        {
            Cinemas = new ObservableCollection<Cinema>();
            RegisterCommand = new RelayCommand(_ => RegisterShowing(), _ => true);

            // Test Cinemas
            Cinemas.Add(new Cinema() {CinemaID = 0, Name = "Østerbro" });
            Cinemas.Add(new Cinema() {CinemaID = 1, Name = "Kolding" });

            SelectedCinema = Cinemas[0];
            SelectedDate = "";
            SelectedScreen = "";
        }

        // --------- Methods for relaycommands --------- 
        public void RegisterShowing()
        {
            try
            {
                MessageBox.Show($"Registreret: {SelectedDate}, {SelectedCinema.Name}, {SelectedScreen}");
            }
            catch (Exception ex) {
                MessageBox.Show("Registreret!");
            }
        }
    }
}

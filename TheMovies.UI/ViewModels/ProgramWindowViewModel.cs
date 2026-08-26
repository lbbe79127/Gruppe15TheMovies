using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TheMovies.Core.Models;
using TheMovies.Core.Repositories;

namespace TheMovies.UI.ViewModels
{
    class ProgramWindowViewModel : ViewModelBase
    {
        //----- Repositories ---- Cinema missing ----
        private readonly IScreenRepository _screenRepository;
        private readonly IShowingRepository _showingRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly ICinemaRepository _cinemaRepository;

        // --------- Collections ---------

        private readonly List<Screen> _screens;

        // --------- Observable Collections --------- 
        private ObservableCollection<Cinema> _cinemas;
        public ObservableCollection<Cinema> Cinemas
        {
                get { return _cinemas; }
                set { _cinemas = value; }
        }

        private ObservableCollection<Movie> _movies;
        public ObservableCollection<Movie> Movies
        {
            get { return _movies; }
            set { _movies = value; }
        }

        // --------- Properties w PropertyChanged --------- 
        private Cinema _selectedCinema;
        public Cinema SelectedCinema
        {
            get { return _selectedCinema; }
            set { _selectedCinema = value; OnPropertyChanged(); }
        }

        private Movie _selectedMovie;
        public Movie SelectedMovie
        {
            get { return _selectedMovie; }
            set { _selectedMovie = value; OnPropertyChanged(); }
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
        //selectedStartTime
        private string _selectedStartTime;
        public string SelectedStartTime
        {
            get { return _selectedStartTime; }
            set { _selectedStartTime = value; OnPropertyChanged(); }
        }

        // --------- RelayCommands --------- 
        public ICommand RegisterCommand { get; private set; }


        // --------- Contructor --------- 
        public ProgramWindowViewModel(IShowingRepository showingRepository, IMovieRepository movieRepository, IScreenRepository screenRepository, ICinemaRepository cinemaRepository)
        {
            _showingRepository = showingRepository;
            _movieRepository = movieRepository;
            _screenRepository = screenRepository;
            _cinemaRepository = cinemaRepository;

            Cinemas = new ObservableCollection<Cinema>(cinemaRepository.GetAll());
            Movies = new ObservableCollection<Movie>(movieRepository.GetAll());
            _screens = new List<Screen>(screenRepository.GetAll());

            RegisterCommand = new RelayCommand(_ => RegisterShowing(), _ => CanRegisterShowing());

            SelectedCinema = null;
            SelectedMovie = null;
            SelectedDate = "";
            SelectedScreen = "";
            SelectedStartTime = "";
        }

        // --------- Methods for relaycommands --------- 
        public bool CanRegisterShowing() // Checks if datainput is filled
        {
            if (SelectedMovie != null && SelectedCinema != null && SelectedDate != "" && SelectedScreen != "" && SelectedStartTime != "")
            {
                return true;
            }
            return false;
        }
        public void RegisterShowing() // Checks and informs user if datainput is correct then informs user if data has been saved
        {

            try
            {
                string startime = SelectedDate + " " + SelectedStartTime;
                Movie selectedMovie = _movieRepository.GetByID(SelectedMovie.MovieID);
                Showing newShowing = new Showing()
                {
                    ShowingID = -1,
                    MovieID = SelectedMovie.MovieID,
                    ScreenNumber = Int32.Parse(SelectedScreen),
                    StartTime = DateTime.ParseExact(startime, "dd/MM/yyyy HH:mm", new CultureInfo("da-DK")),
                    EndTime = DateTime.ParseExact(startime, "dd/MM/yyyy HH:mm", new CultureInfo("da-DK"))
                    .AddMinutes(SelectedMovie.Duration)
                    .AddMinutes(30)
                };
                _showingRepository.Add(newShowing);
                MessageBox.Show($"Registreret: {newShowing.ShowingID}, {newShowing.MovieID}, {newShowing.ScreenNumber}, {newShowing.StartTime.ToString()}, {newShowing.EndTime.ToString()}");
            }
            catch (Exception ex) {
                MessageBox.Show("Registreret!");
            }
        }
    }
}

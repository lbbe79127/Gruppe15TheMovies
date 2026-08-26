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
        //private readonly ICinemaRepository _cinemaRepository;

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
        public ProgramWindowViewModel(IShowingRepository showingRepository, IMovieRepository movieRepository)
        {
            _showingRepository = showingRepository;
            _movieRepository = movieRepository;
            Cinemas = new ObservableCollection<Cinema>();
            Movies = new ObservableCollection<Movie>();
            RegisterCommand = new RelayCommand(_ => RegisterShowing(), _ => true);

            // Test Cinemas
            Cinemas.Add(new Cinema() { CinemaID = 0, Name = "Hjerm" });
            Cinemas.Add(new Cinema() { CinemaID = 1, Name = "Videbæk" });
            Cinemas.Add(new Cinema() { CinemaID = 2, Name = "Thorsminde" });
            Cinemas.Add(new Cinema() { CinemaID = 3, Name = "Ræhr" });
            Cinemas.Add(new Cinema() { CinemaID = 4, Name = "Østerbro" });
            Cinemas.Add(new Cinema() { CinemaID = 5, Name = "Kolding" });

            // Test movies
            Movies.Add(new Movie() { MovieID = 0, Title = "De uskyldige", Duration = 117, Instructor = "Eskil Vogt", Genre = "Thriller", PremiereDate = DateTime.Now });
            Movies.Add(new Movie() { MovieID = 1, Title = "Druk", Duration = 117, Instructor = "Thomas Vinterberg", Genre = "Comedy", PremiereDate = DateTime.Now });

            SelectedCinema = Cinemas[0];
            SelectedMovie = Movies[0];
            SelectedDate = "";
            SelectedScreen = "";
        }

        // --------- Methods for relaycommands --------- 
        public void RegisterShowing()
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

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
        public ProgramWindowViewModel(IShowingRepository showingRepository)
        {
            _showingRepository = showingRepository;
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
                Showing newShowing = new Showing()
                {
                    ShowingID = -1,
                    MovieID = -1,
                    ScreenNumber = Int32.Parse(SelectedScreen),
                    StartTime = DateTime.ParseExact(SelectedDate, "dd/MM/yyyy", new CultureInfo("da-DK")),
                    EndTime = DateTime.ParseExact(SelectedDate, "dd/MM/yyyy", new CultureInfo("da-DK")).AddHours(2)
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

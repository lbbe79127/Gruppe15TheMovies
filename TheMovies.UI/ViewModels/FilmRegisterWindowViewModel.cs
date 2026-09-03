using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TheMovies.Core.Models;
using TheMovies.Core.Repositories;

namespace TheMovies.UI.ViewModels
{
class FilmRegisterWindowViewModel : ViewModelBase
{
private readonly IMovieRepository _movieRepository;

    private string _title;
    public string Title
    {
        get { return _title; }
        set
        {
            _title = value;
            OnPropertyChanged();
        }
    }

    private string _duration;
    public string Duration
    {
        get { return _duration; }
        set
        {
            _duration = value;
            OnPropertyChanged();
        }
    }

    private string _selectedGenre;
    public string SelectedGenre
    {
        get { return _selectedGenre; }
        set
        {
            _selectedGenre = value;
            OnPropertyChanged();
        }
    }

    private string _director;
    public string Director
    {
        get { return _director; }
        set
        {
            _director = value;
            OnPropertyChanged();
        }
    }

    private DateTime? _premiereDate;
    public DateTime? PremiereDate
    {
        get { return _premiereDate; }
        set
        {
            _premiereDate = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<string> Genres { get; set; }

    public ICommand RegisterCommand { get; private set; }

    public FilmRegisterWindowViewModel(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;

        Genres = new ObservableCollection<string>
        {
            "Action",
            "Animation",
            "Comedy",
            "Drama",
            "Horror",
            "Thriller"
        };

        RegisterCommand = new RelayCommand(
            _ => RegisterMovie(),
            _ => true
        );
    }

    private void RegisterMovie()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                MessageBox.Show("Indtast en filmtitel.");
                return;
            }

            if (!int.TryParse(Duration, out int duration))
            {
                MessageBox.Show("Varighed skal være et helt tal.");
                return;
            }

            if (string.IsNullOrWhiteSpace(SelectedGenre))
            {
                MessageBox.Show("Vælg en filmgenre.");
                return;
            }

            Movie newMovie = new Movie
            {
                Title = Title,
                Duration = duration,
                Genre = SelectedGenre,
                Director = Director,
                PremiereDate = PremiereDate
            };

            _movieRepository.Add(newMovie);

            MessageBox.Show(
                $"Filmen \"{newMovie.Title}\" er registreret."
            );

            Title = "";
            Duration = "";
            SelectedGenre = null;
            Director = "";
            PremiereDate = null;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Kunne ikke registrere filmen: {ex.Message}"
            );
        }
    }
}

}

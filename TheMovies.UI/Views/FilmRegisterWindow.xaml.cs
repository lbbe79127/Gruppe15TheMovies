using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;
using TheMovies.Core.Repositories;
using TheMovies.UI.ViewModels;

namespace TheMovies.UI
{
    public partial class FilmRegisterWindow : Window
    {
        public FilmRegisterWindow()
        {
            InitializeComponent();

            IMovieRepository movieRepository = new FileMovieRepository();

            DataContext = new FilmRegisterWindowViewModel(movieRepository);
        }

        private void btnAnnuller_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace PV168_Project.windows
{
    /// <summary>
    /// Interaction logic for PlayersWindow.xaml
    /// </summary>
    public partial class PlayersWindow : UserControl
    {

        private readonly DataContext _context =
            new DataContext();

        private CollectionViewSource playerViewSource;
        public PlayersWindow()
        {
            InitializeComponent();
            playerViewSource =
                (CollectionViewSource)FindResource(nameof(playerViewSource));
        }

        private void PlayerWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();
            _context.Players.Load();
            playerViewSource.Source =
                _context.Players.Local.ToObservableCollection();

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
            playersDataGrid.Items.Refresh();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new MenuUserControl();
        }

    }
}

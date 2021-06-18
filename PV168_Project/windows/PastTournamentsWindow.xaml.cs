using System;
using System.Collections.Generic;
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

namespace PV168_Project.windows
{
    /// <summary>
    /// Interaction logic for PastTournamentsWindow.xaml
    /// </summary>
    public partial class PastTournamentsWindow : UserControl
    {
        private readonly DataContext _context =
            new DataContext();

        private CollectionViewSource tournamentViewSource;

        public PastTournamentsWindow()
        {
            InitializeComponent();
            tournamentViewSource =
                (CollectionViewSource)FindResource(nameof(tournamentViewSource));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new MenuUserControl();
        }
    }
}

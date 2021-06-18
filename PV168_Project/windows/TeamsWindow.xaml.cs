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
using Microsoft.EntityFrameworkCore;
using PV168_Project.Entities;

namespace PV168_Project.windows
{
    /// <summary>
    /// Interaction logic for TeamsWindow.xaml
    /// </summary>
    public partial class TeamsWindow : UserControl
    {
        private readonly DataContext _context =
            new DataContext();

        private CollectionViewSource teamViewSource;
        public TeamsWindow()
        {
            InitializeComponent();
            teamViewSource =
                (CollectionViewSource)FindResource(nameof(teamViewSource));
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();
            _context.Teams.Load();
            teamViewSource.Source =
                _context.Teams.Local.ToObservableCollection();
        }

        private void CreateTeamButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new NewTeamWindow();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new MenuUserControl();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Team selectedTeam = (Team)teamsDataGrid.SelectedItem;
            if(selectedTeam is null)
            {
                return;
            }
            /*
            foreach(Team team in selectedTeams)
            {
                foreach(Player player in team.Players)
                {
                    player.Team = null;
                    _context.Update(player);
                }*/
            foreach (Player player in selectedTeam.Players)
            {
                player.Team = null;
                _context.Update(player);
            }
            _context.Remove(selectedTeam);
            _context.SaveChanges();
            //}
        }
    }
}

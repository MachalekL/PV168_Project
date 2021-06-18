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
    /// Interaction logic for NewTeamWindow.xaml
    /// </summary>
    public partial class NewTeamWindow : UserControl
    {
        private readonly DataContext _context =
            new DataContext();

        private CollectionViewSource playerViewSource;

        private CollectionViewSource playersInTeamViewSource;

        private List<Player> teamPlayers = new();

        public NewTeamWindow()
        {
            InitializeComponent();
            playerViewSource =
                (CollectionViewSource)FindResource(nameof(playerViewSource));
            playersInTeamViewSource =
                (CollectionViewSource)FindResource(nameof(playersInTeamViewSource));
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string teamName = TeamNameBox.Text;
            if(teamName.Length == 0)
            {
                MessageBox.Show("Team has to have a name.");
                return;
            }
            Team newTeam = new Team(teamName);
            newTeam.Players = teamPlayers;
            foreach(var player in teamPlayers)
            {
                player.Team = newTeam;
            }
            _context.Add(newTeam);
            _context.SaveChanges();
            this.Content = new TeamsWindow();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new TeamsWindow();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();
            _context.Players.Load();
            playerViewSource.Source =
                _context.Players.Local.ToObservableCollection();
        }
        
        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if(cmbPlayers.SelectedValue is null || teamPlayers.Contains((Player)cmbPlayers.SelectedValue))
            {
                MessageBox.Show("You haven't selected a player, or the team already contains this player.");
                return;
            }
            teamPlayers.Add((Player)cmbPlayers.SelectedValue);
            playersInTeamViewSource.Source = teamPlayers;
            playersDataGrid.Items.Refresh();
        }
    }
}

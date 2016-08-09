using DIRECTView.Controls.Groups;
using DIRECTView.Information;
using System.Windows;

namespace DIRECTView.Controls.Scenarios
{
    /// <summary>
    /// Interaction logic for SelectedScenarios.xaml
    /// </summary>
    public partial class SelectedScenarios : GroupBox
    {
        public Scenario Scenario { get; set; }
        public MainWindow MainWindow { get; set; }
        public SelectedScenarios()
        {
            InitializeComponent();
        }

        private void RemoveScenario_Click(object sender, RoutedEventArgs e)
        {
            //SceIsChecked = (IsChecked) ? false : true;
            Scenario.IsChecked = false;
            MainWindow.ChartsPage.RefreshViews(Scenario, Scenario.IsChecked);
            MainWindow.Filters.RefreshColors(MainWindow.ChartsPage);
        }
    }
}

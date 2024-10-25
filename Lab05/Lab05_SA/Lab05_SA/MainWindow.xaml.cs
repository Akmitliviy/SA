using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Lab05_SA
{
    public partial class MainWindow : Window
    {
        private TabControl SelectedTab { get; set; }
        public ObservableCollection<Risk> TechnicalRisks { get; set; }
        public ObservableCollection<Risk> CostRisks { get; set; }
        public ObservableCollection<Risk> ScheduleRisks { get; set; }
        public ObservableCollection<Risk> ProcessRisks { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Initialize data collections
            TechnicalRisks = new ObservableCollection<Risk>
            {
                new Risk { Number = 1, RiskSource = "Функціональні характеристики ПЗ", IsSelected = false },
                new Risk { Number = 2, RiskSource = "Характеристики якості ПЗ", IsSelected = false },
                new Risk { Number = 3, RiskSource = "Характеристики надійності ПЗ", IsSelected = false },
                new Risk { Number = 4, RiskSource = "Застосовність ПЗ", IsSelected = false },
                new Risk { Number = 5, RiskSource = "Часова продуктивність ПЗ", IsSelected = false },
                new Risk { Number = 6, RiskSource = "Супроводжуваність ПЗ", IsSelected = false },
                new Risk { Number = 7, RiskSource = "Повторне використання компонент ПЗ", IsSelected = false }
            };

            CostRisks = new ObservableCollection<Risk>
            {
                new Risk { Number = 1, RiskSource = "Обмеження сумарного бюджету", IsSelected = false },
                new Risk { Number = 2, RiskSource = "Недоступна вартість реалізації", IsSelected = false },
                new Risk { Number = 3, RiskSource = "Низька ступінь реалізму оцінки", IsSelected = false }
            };

            ScheduleRisks = new ObservableCollection<Risk>
            {
                new Risk { Number = 1, RiskSource = "Гнучкість внесення змін до планів", IsSelected = false },
                new Risk { Number = 2, RiskSource = "Порушення термінів", IsSelected = false },
                new Risk { Number = 3, RiskSource = "Низький реалізм при плануванні", IsSelected = false }
            };

            ProcessRisks = new ObservableCollection<Risk>
            {
                new Risk { Number = 1, RiskSource = "Хибна стратегія реалізації", IsSelected = false },
                new Risk { Number = 2, RiskSource = "Неефективне планування", IsSelected = false },
                new Risk { Number = 3, RiskSource = "Неефективне керування", IsSelected = false },
                new Risk { Number = 4, RiskSource = "Хибний вибір інструментів", IsSelected = false }
            };

            // Set data context
            DataContext = this;

            SelectedTab = RiskIdentificationTabControl;
            
            TechnicalRisksGrid.ItemsSource = TechnicalRisks;
            CostRisksGrid.ItemsSource = CostRisks;
            ScheduleRisksGrid.ItemsSource = ScheduleRisks;
            ProcessRisksGrid.ItemsSource = ProcessRisks;
        }

        // Button click event to select/reset all for Technical Risks
        private void SelectResetAllTechnical_Click(object sender, RoutedEventArgs e)
        {
            ToggleSelection(TechnicalRisks);
        }

        // Button click event to select/reset all for Cost Risks
        private void SelectResetAllCost_Click(object sender, RoutedEventArgs e)
        {
            ToggleSelection(CostRisks);
        }

        // Button click event to select/reset all for Schedule Risks
        private void SelectResetAllSchedule_Click(object sender, RoutedEventArgs e)
        {
            ToggleSelection(ScheduleRisks);
        }

        // Button click event to select/reset all for Process Risks
        private void SelectResetAllProcess_Click(object sender, RoutedEventArgs e)
        {
            ToggleSelection(ProcessRisks);
        }

        // Method to toggle IsSelected for all risks in a collection
        private void ToggleSelection(ObservableCollection<Risk> risks)
        {
            bool allSelected = risks.All(r => r.IsSelected);
            foreach (var risk in risks)
            {
                risk.IsSelected = !allSelected;
            }
        }

        public ObservableCollection<Risk> GetTechnicalRisks()
        {
            return TechnicalRisks;
        }

        private void RiskIdentificationButton_OnClick(object sender, RoutedEventArgs e)
        {
            SelectedTab.Visibility = Visibility.Collapsed;
            SelectedTab = RiskIdentificationTabControl;
            SelectedTab.Visibility = Visibility.Visible;
            
        }

        private void RiskAnalysisButton_OnClick(object sender, RoutedEventArgs e)
        {
            SelectedTab.Visibility = Visibility.Collapsed;
            SelectedTab = RiskAnalysisTabControl;
            SelectedTab.Visibility = Visibility.Visible;
        }

        private void RiskPlanningButton_OnClick(object sender, RoutedEventArgs e)
        {
            SelectedTab.Visibility = Visibility.Collapsed;
            SelectedTab = RiskScheduleTabControl;
            SelectedTab.Visibility = Visibility.Visible;
        }

        private void RiskTrackingButton_OnClick(object sender, RoutedEventArgs e)
        {
            SelectedTab.Visibility = Visibility.Collapsed;
            SelectedTab = RiskTrackingTabControl;
            SelectedTab.Visibility = Visibility.Visible;
        }
    }


    public class Risk
    {
        public int Number { get; set; }
        public string RiskSource { get; set; }
        public bool IsSelected { get; set; }
    }
}

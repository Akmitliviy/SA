using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Lab05_SA.RiskObjects;

namespace Lab05_SA
{
    public partial class MainWindow : Window
    {
        private TabControl SelectedTab { get; set; }
        
        //Possible Risks
        private ObservableCollection<Risk> TechnicalRisks { get; set; }
        private ObservableCollection<Risk> CostRisks { get; set; }
        private ObservableCollection<Risk> ScheduleRisks { get; set; }
        private ObservableCollection<Risk> ProcessRisks { get; set; }
        
        

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
            SelectedTab = RiskIdentificationTabControl;
            PossibleRisksInit();
        }

        private void PossibleRisksInit()
        {
            
            // Initialize data collections
            TechnicalRisks =
            [
                new Risk { Number = 1, RiskSource = "Функціональні характеристики ПЗ", IsSelected = false },
                new Risk { Number = 2, RiskSource = "Характеристики якості ПЗ", IsSelected = false },
                new Risk { Number = 3, RiskSource = "Характеристики надійності ПЗ", IsSelected = false },
                new Risk { Number = 4, RiskSource = "Застосовність ПЗ", IsSelected = false },
                new Risk { Number = 5, RiskSource = "Часова продуктивність ПЗ", IsSelected = false },
                new Risk { Number = 6, RiskSource = "Супроводжуваність ПЗ", IsSelected = false },
                new Risk { Number = 7, RiskSource = "Повторне використання компонент ПЗ", IsSelected = false }
            ];

            CostRisks =
            [
                new Risk { Number = 1, RiskSource = "Обмеження сумарного бюджету", IsSelected = false },
                new Risk { Number = 2, RiskSource = "Недоступна вартість реалізації", IsSelected = false },
                new Risk { Number = 3, RiskSource = "Низька ступінь реалізму оцінки", IsSelected = false }
            ];

            ScheduleRisks =
            [
                new Risk { Number = 1, RiskSource = "Гнучкість внесення змін до планів", IsSelected = false },
                new Risk { Number = 2, RiskSource = "Порушення термінів", IsSelected = false },
                new Risk { Number = 3, RiskSource = "Низький реалізм при плануванні", IsSelected = false }
            ];

            ProcessRisks =
            [
                new Risk { Number = 1, RiskSource = "Хибна стратегія реалізації", IsSelected = false },
                new Risk { Number = 2, RiskSource = "Неефективне планування", IsSelected = false },
                new Risk { Number = 3, RiskSource = "Неефективне керування", IsSelected = false },
                new Risk { Number = 4, RiskSource = "Хибний вибір інструментів", IsSelected = false }
            ];

            TechnicalRisksGrid.ItemsSource = TechnicalRisks;
            CostRisksGrid.ItemsSource = CostRisks;
            ScheduleRisksGrid.ItemsSource = ScheduleRisks;
            ProcessRisksGrid.ItemsSource = ProcessRisks;
        }

        // Select/Reset
        private void SelectResetAllTechnical_Click(object sender, RoutedEventArgs e)
        {
            ToggleSelection(TechnicalRisks);
        }

        private void SelectResetAllCost_Click(object sender, RoutedEventArgs e)
        {
            ToggleSelection(CostRisks);
        }

        private void SelectResetAllSchedule_Click(object sender, RoutedEventArgs e)
        {
            ToggleSelection(ScheduleRisks);
        }

        private void SelectResetAllProcess_Click(object sender, RoutedEventArgs e)
        {
            ToggleSelection(ProcessRisks);
        }

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

        // Switch between tabs
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

        public void RecalculateEverything()
        {
            
        }
    }
}
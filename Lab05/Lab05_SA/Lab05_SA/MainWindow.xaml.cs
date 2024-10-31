using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Lab05_SA.RiskObjects;

namespace Lab05_SA
{
    public partial class MainWindow : Window
    {
        //To implement switch tab logic
        private TabControl SelectedTab { get; set; }
        
        //Possible Risks
        private ObservableCollection<Risk> TechnicalRisks { get; set; }
        private ObservableCollection<Risk> CostRisks { get; set; }
        private ObservableCollection<Risk> ScheduleRisks { get; set; }
        private ObservableCollection<Risk> ProcessRisks { get; set; }
        
        //Possible Risks' Events
        private ObservableCollection<Risk> TechnicalRisksEvents { get; set; }
        private ObservableCollection<Risk> CostRisksEvents { get; set; }
        private ObservableCollection<Risk> ScheduleRisksEvents { get; set; }
        private ObservableCollection<Risk> ProcessRisksEvents { get; set; }
        
        //ResultingRisksEvaluation
        private ObservableCollection<ErStuff> ResultingRisksEvaluation { get; set; }
        
        //ResultingRiskAmount
        private ObservableCollection<Priorities> ResultingRisksAmount { get; set; }
        
        //PossibleRisksSolutions
        private ObservableCollection<Solutions> TechnicalRisksSolution { get; set; }
        private ObservableCollection<Solutions> CostRisksSolution { get; set; }
        private ObservableCollection<Solutions> ScheduleRisksSolution { get; set; }
        private ObservableCollection<Solutions> ProcessRisksSolution { get; set; }
        
        //RiskProbability
        private ObservableCollection<ErStuff> RiskProbability { get; set; }
        
        //RiskAndPrioritiesAssessmentGrid
        private ObservableCollection<Priorities> RiskAndPrioritiesAssessment { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            SelectedTab = RiskIdentificationTabControl;
            
            PossibleRisksInit();
            PossibleRiskEventsInit();
            RiskAnalysisInit();
            PossibleRisksSolutionsInit();
            RiskTrackingInit();
            
            DataContext = this;
        }

        private void PossibleRisksInit()
        {
            
            TechnicalRisks =
            [
                new Risk { Name = "tRS1", RiskSource = "Функціональні характеристики ПЗ", IsSelected = false },
                new Risk { Name = "tRS2", RiskSource = "Характеристики якості ПЗ", IsSelected = false },
                new Risk { Name = "tRS3", RiskSource = "Характеристики надійності ПЗ", IsSelected = false },
                new Risk { Name = "tRS4", RiskSource = "Застосовність ПЗ", IsSelected = false },
                new Risk { Name = "tRS5", RiskSource = "Часова продуктивність ПЗ", IsSelected = false },
                new Risk { Name = "tRS6", RiskSource = "Супроводжуваність ПЗ", IsSelected = false },
                new Risk { Name = "tRS7", RiskSource = "Повторне використання компонент ПЗ", IsSelected = false }
            ];
            foreach (var risk in TechnicalRisks)
            {
                risk.PropertyChanged += CalculateRisks;
            }

            CostRisks =
            [
                new Risk { Name = "cRS1", RiskSource = "Обмеження сумарного бюджету", IsSelected = false },
                new Risk { Name = "cRS2", RiskSource = "Недоступна вартість реалізації", IsSelected = false },
                new Risk { Name = "cRS3", RiskSource = "Низька ступінь реалізму оцінки", IsSelected = false }
            ];
            foreach (var risk in CostRisks)
            {
                risk.PropertyChanged += CalculateRisks;
            }

            ScheduleRisks =
            [
                new Risk { Name = "pRS1", RiskSource = "Гнучкість внесення змін до планів", IsSelected = false },
                new Risk { Name = "pRS2", RiskSource = "Порушення термінів", IsSelected = false },
                new Risk { Name = "pRS3", RiskSource = "Низький реалізм при плануванні", IsSelected = false }
            ];
            foreach (var risk in ScheduleRisks)
            {
                risk.PropertyChanged += CalculateRisks;
            }

            ProcessRisks =
            [
                new Risk { Name = "mRS1", RiskSource = "Хибна стратегія реалізації", IsSelected = false },
                new Risk { Name = "mRS2", RiskSource = "Неефективне планування", IsSelected = false },
                new Risk { Name = "mRS3", RiskSource = "Неякісне оцінювання", IsSelected = false },
                new Risk { Name = "mRS4", RiskSource = "Прогалини в документуванні", IsSelected = false },
                new Risk { Name = "mRS5", RiskSource = "Погане прогнозування", IsSelected = false }
            ];
            foreach (var risk in ProcessRisks)
            {
                risk.PropertyChanged += CalculateRisks;
            }

            TechnicalRisksGrid.ItemsSource = TechnicalRisks;
            CostRisksGrid.ItemsSource = CostRisks;
            ScheduleRisksGrid.ItemsSource = ScheduleRisks;
            ProcessRisksGrid.ItemsSource = ProcessRisks;
        }
        private void PossibleRiskEventsInit()
        {
            TechnicalRisksEvents =
            [
                new Risk { Name = "tR1",  RiskSource = "Затримки у постачанні обладнання, необхідного для підтримки процесу розроблення ПЗ", IsSelected = false },
                new Risk { Name = "tR2",  RiskSource = "Затримки у постачанні інструментальних засобів, необхідних для підтримки процесу розроблення ПЗ", IsSelected = false },
                new Risk { Name = "tR3",  RiskSource = "Небажання команди виконавців ПЗ використовувати інструментальні засоби для підтримки процесу розроблення ПЗ", IsSelected = false },
                new Risk { Name = "tR4",  RiskSource = "Відмова команди виконавців від CASE-засобів розроблення ПЗ", IsSelected = false },
                new Risk { Name = "tR5",  RiskSource = "Формування запитів на більш потужні інструментальні засоби розроблення ПЗ", IsSelected = false },
                new Risk { Name = "tR6",  RiskSource = "Недостатня продуктивність баз(и) даних для підтримки процесу розроблення ПЗ", IsSelected = false },
                new Risk { Name = "tR7",  RiskSource = "Програмні компоненти, які використовуються повторно в ПЗ, мають дефекти та обмежені функціональні можливості", IsSelected = false },
                new Risk { Name = "tR8",  RiskSource = "Неефективність програмного коду, згенерованого CASE-засобами розроблення ПЗ", IsSelected = false },
                new Risk { Name = "tR9",  RiskSource = "Неможливість інтеграції CASE-засобів з іншими інструментальними засобами для підтримки процесу розроблення ПЗ", IsSelected = false },
                new Risk { Name = "tR10", RiskSource = "Швидкість виявлення дефектів у програмному коді є нижчою від раніше запланованих термінів", IsSelected = false },
                new Risk { Name = "tR11", RiskSource = "Поява дефектних системних компонент, які використовують для розроблення ПЗ", IsSelected = false }
            ];
            foreach (var risk in TechnicalRisksEvents)
            {
                risk.PropertyChanged += CalculateRiskEvents;
            }
            

            CostRisksEvents =
            [
                new Risk { Name = "cR1", RiskSource = "Недооцінювання витрат на реалізацію програмного проєкту (надмірно низька вартість)", IsSelected = false },
                new Risk { Name = "cR2", RiskSource = "Переоцінювання витрат на реалізацію програмного проєкту (надмірно висока вартість)", IsSelected = false },
                new Risk { Name = "cR3", RiskSource = "Фінансові ускладнення у компанії-замовника ПЗ", IsSelected = false },
                new Risk { Name = "cR4", RiskSource = "Фінансові ускладнення у компанії-розробника ПЗ", IsSelected = false },
                new Risk { Name = "cR5", RiskSource = "Збільшення бюджету програмного проєкту з ініціативи компанії-замовника ПЗ під час його реалізації", IsSelected = false },
                new Risk { Name = "cR6", RiskSource = "Збільшення бюджету програмного проєкту з ініціативи компанії-розробника ПЗ під час його реалізації", IsSelected = false },
                new Risk { Name = "cR7", RiskSource = "Зниження витрат на виконання повторних робіт, необхідних для зміни вимог до ПЗ", IsSelected = false },
                new Risk { Name = "cR8", RiskSource = "Реорганізація структурних підрозділів у компанії-замовника ПЗ", IsSelected = false },
                new Risk { Name = "cR9", RiskSource = "Реорганізація команди виконавців у компанії-розробника ПЗ", IsSelected = false }
            ];
            foreach (var risk in CostRisksEvents)
            {
                risk.PropertyChanged += CalculateRiskEvents;
            }
            
            ScheduleRisksEvents =
            [
                new Risk { Name = "pR1", RiskSource = "Зміни графіка виконання робіт з боку замовника чи виконавця", IsSelected = false },
                new Risk { Name = "pR2", RiskSource = "Порушення графіка виконання робіт у компанії-розробника ПЗ", IsSelected = false },
                new Risk { Name = "pR3", RiskSource = "Потреба зміни користувацьких вимог до ПЗ з боку компанії-замовника ПЗ", IsSelected = false },
                new Risk { Name = "pR4", RiskSource = "Потреба зміни функціональних вимог до ПЗ з боку компанії-розробника ПЗ", IsSelected = false },
                new Risk { Name = "pR5", RiskSource = "Потреба виконання великої кількості повторних робіт, необхідних для зміни вимог до ПЗ", IsSelected = false },
                new Risk { Name = "pR6", RiskSource = "Недооцінювання тривалості етапів реалізації програмного проєкту з боку компанії-ні-розробника ПЗ", IsSelected = false },
                new Risk { Name = "pR7", RiskSource = "Переоцінювання тривалості етапів реалізації програмного проєкту", IsSelected = false },
                new Risk { Name = "pR8", RiskSource = "Остаточний розмір ПЗ перевищує заплановані його характеристики", IsSelected = false },
                new Risk { Name = "pR9", RiskSource = "Остаточний розмір ПЗ значно менший за планові його характеристики", IsSelected = false },
                new Risk { Name = "pR10", RiskSource = "Поява на ринку аналогічного ПЗ до виходу замовленого", IsSelected = false },
                new Risk { Name = "pR11", RiskSource = "Поява на ринку більш конкурентоздатного ПЗ", IsSelected = false }
            ];
            foreach (var risk in ScheduleRisksEvents)
            {
                risk.PropertyChanged += CalculateRiskEvents;
            }

            ProcessRisksEvents =
            [
                new Risk { Name = "mR1", RiskSource = "Низький моральний стан персоналу команди виконавців ПЗ", IsSelected = false },
                new Risk { Name = "mR2", RiskSource = "Низька взаємодія між членами команди виконавців ПЗ", IsSelected = false },
                new Risk { Name = "mR3", RiskSource = "Пасивність керівника (менеджера) програмного проєкту", IsSelected = false },
                new Risk { Name = "mR4", RiskSource = "Недостатня компетентність керівника (менеджера) програмного проєкту", IsSelected = false },
                new Risk { Name = "mR5", RiskSource = "Незадоволеність замовника результатами етапів реалізації програмного проєкту", IsSelected = false },
                new Risk { Name = "mR6", RiskSource = "Недостатня кількість фахівців у команді виконавців ПЗ з необхідним професійним рівнем", IsSelected = false },
                new Risk { Name = "mR7", RiskSource = "Хвороба одного виконавця в найкритичніший момент розроблення ПЗ", IsSelected = false },
                new Risk { Name = "mR8", RiskSource = "Одночасна хвороба декількох виконавців підчас розроблення ПЗ", IsSelected = false },
                new Risk { Name = "mR9", RiskSource = "Недостатнє забезпечення необхідного навчання персоналу команди виконавців ПЗ", IsSelected = false },
                new Risk { Name = "mR10", RiskSource = "Перешкоди у процесі управління програмним проєктом", IsSelected = false },
                new Risk { Name = "mR11", RiskSource = "Ініціативи щодо змін структури команди виконавців ПЗ з боку замовника ПЗ", IsSelected = false },
                new Risk { Name = "mR12", RiskSource = "Наявність недосвідченої великої кількості розробників (підрядників і субпідрядників) на етапах активного циклу розроблення ПЗ", IsSelected = false },
                new Risk { Name = "mR13", RiskSource = "Наявність недосвідченої великої кількості розробників (підрядників і субпідрядників) на етапах планування розроблення ПЗ", IsSelected = false },
                new Risk { Name = "mR14", RiskSource = "Недостатнє документування результатів на етапах реалізації програмного проєкту", IsSelected = false },
                new Risk { Name = "mR15", RiskSource = "Незадоволеність замовника результатами на етапах реалізації програмного проєкту", IsSelected = false },
                new Risk { Name = "mR16", RiskSource = "Ініціативи щодо змін структури команди виконавців ПЗ з боку компанії-замовника ПЗ", IsSelected = false }
            ];
            foreach (var risk in ProcessRisksEvents)
            {
                risk.PropertyChanged += CalculateRiskEvents;
            }
            
            TechnicalRiskActionsGrid.ItemsSource = TechnicalRisksEvents;
            CostRiskActionsGrid.ItemsSource = CostRisksEvents;
            ScheduleRiskActionsGrid.ItemsSource = ScheduleRisksEvents;
            ProcessRiskActionsGrid.ItemsSource = ProcessRisksEvents;
        }

        private void RiskAnalysisInit()
        {
            ResultingRisksEvaluation = new ObservableCollection<ErStuff>();
            
            foreach (var risksEvent in TechnicalRisksEvents)
            {
                ResultingRisksEvaluation.Add(new ErStuff(){
                    Name = risksEvent.Name, RiskSource = risksEvent.RiskSource,
                    Per1 = GetRandom(),
                    Per2 = GetRandom(),
                    Per3 = GetRandom(),
                    Per4 = GetRandom(),
                    Per5 = GetRandom(),
                    Per6 = GetRandom(),
                    Per7 = GetRandom(),
                    Per8 = GetRandom(),
                    Per9 = GetRandom(),
                    Per10 = GetRandom()
                });
            }
            foreach (var risksEvent in CostRisksEvents)
            {
                ResultingRisksEvaluation.Add(new ErStuff(){
                    Name = risksEvent.Name, RiskSource = risksEvent.RiskSource,
                    Per1 = GetRandom(),
                    Per2 = GetRandom(),
                    Per3 = GetRandom(),
                    Per4 = GetRandom(),
                    Per5 = GetRandom(),
                    Per6 = GetRandom(),
                    Per7 = GetRandom(),
                    Per8 = GetRandom(),
                    Per9 = GetRandom(),
                    Per10 = GetRandom()
                });
            }
            foreach (var risksEvent in ScheduleRisksEvents)
            {
                ResultingRisksEvaluation.Add(new ErStuff(){
                    Name = risksEvent.Name, RiskSource = risksEvent.RiskSource,
                    Per1 = GetRandom(),
                    Per2 = GetRandom(),
                    Per3 = GetRandom(),
                    Per4 = GetRandom(),
                    Per5 = GetRandom(),
                    Per6 = GetRandom(),
                    Per7 = GetRandom(),
                    Per8 = GetRandom(),
                    Per9 = GetRandom(),
                    Per10 = GetRandom()
                });
            }
            foreach (var risksEvent in ProcessRisksEvents)
            {
                ResultingRisksEvaluation.Add(new ErStuff(){
                    Name = risksEvent.Name, RiskSource = risksEvent.RiskSource,
                    Per1 = GetRandom(),
                    Per2 = GetRandom(),
                    Per3 = GetRandom(),
                    Per4 = GetRandom(),
                    Per5 = GetRandom(),
                    Per6 = GetRandom(),
                    Per7 = GetRandom(),
                    Per8 = GetRandom(),
                    Per9 = GetRandom(),
                    Per10 = GetRandom()
                });
            }
            
            
            ResultingRisksAmount = new ObservableCollection<Priorities>();
            
            foreach (var risksEvent in TechnicalRisksEvents)
            {
                ResultingRisksAmount.Add(new Priorities(){Name = risksEvent.Name, RiskSource = risksEvent.RiskSource, Lrer = GetRandom()});
            }
            foreach (var risksEvent in CostRisksEvents)
            {
                ResultingRisksAmount.Add(new Priorities(){Name = risksEvent.Name, RiskSource = risksEvent.RiskSource, Lrer = GetRandom()});
            }
            foreach (var risksEvent in ScheduleRisksEvents)
            {
                ResultingRisksAmount.Add(new Priorities(){Name = risksEvent.Name, RiskSource = risksEvent.RiskSource, Lrer = GetRandom()});
            }
            foreach (var risksEvent in ProcessRisksEvents)
            {
                ResultingRisksAmount.Add(new Priorities(){Name = risksEvent.Name, RiskSource = risksEvent.RiskSource, Lrer = GetRandom()});
            }
            
            CalculateRiskAnalysis();
            foreach (var erStuff in ResultingRisksEvaluation)
            {
                erStuff.PropertyChanged += CalculateRiskAnalysis;
            }
            ResultingRisksEvaluationGrid.ItemsSource = ResultingRisksEvaluation;
            ResultingRiskAmountGrid.ItemsSource = ResultingRisksAmount;
            
        }
        
        private void PossibleRisksSolutionsInit()
        {
            TechnicalRisksSolution = new ObservableCollection<Solutions>();
            foreach (var risksEvent in TechnicalRisksEvents)
            {
                TechnicalRisksSolution.Add(new Solutions(){Name = risksEvent.Name, RiskSource = risksEvent.RiskSource, RiskSolution = RiskSolutions.ComponentAcquisition});
            }
            TechnicalRisksSolutionGrid.ItemsSource = TechnicalRisksSolution;
            
            CostRisksSolution = new ObservableCollection<Solutions>();
            foreach (var risksEvent in CostRisksEvents)
            {
                CostRisksSolution.Add(new Solutions(){Name = risksEvent.Name, RiskSource = risksEvent.RiskSource, RiskSolution = RiskSolutions.ComponentAcquisition});
            }
            CostRisksSolutionGrid.ItemsSource = CostRisksSolution;
            
            ScheduleRisksSolution = new ObservableCollection<Solutions>();
            foreach (var risksEvent in ScheduleRisksEvents)
            {
                ScheduleRisksSolution.Add(new Solutions(){Name = risksEvent.Name, RiskSource = risksEvent.RiskSource, RiskSolution = RiskSolutions.ComponentAcquisition});
            }
            ScheduleRisksSolutionGrid.ItemsSource = ScheduleRisksSolution;
            
            ProcessRisksSolution = new ObservableCollection<Solutions>();
            foreach (var risksEvent in ProcessRisksEvents)
            {
                ProcessRisksSolution.Add(new Solutions(){Name = risksEvent.Name, RiskSource = risksEvent.RiskSource, RiskSolution = RiskSolutions.ComponentAcquisition});
            }
            ProcessRisksSolutionGrid.ItemsSource = ProcessRisksSolution;
        }

        //RiskTracking init
        private void RiskTrackingInit()
        {
            RiskProbability = new ObservableCollection<ErStuff>();
            foreach (var risksEvent in TechnicalRisksEvents)
            {
                RiskProbability.Add(new ErStuff(){
                    Name = risksEvent.Name, RiskSource = risksEvent.RiskSource,
                    Per1 = GetRandom(),
                    Per2 = GetRandom(),
                    Per3 = GetRandom(),
                    Per4 = GetRandom(),
                    Per5 = GetRandom(),
                    Per6 = GetRandom(),
                    Per7 = GetRandom(),
                    Per8 = GetRandom(),
                    Per9 = GetRandom(),
                    Per10 = GetRandom()
                });
            }
            foreach (var risksEvent in CostRisksEvents)
            {
                RiskProbability.Add(new ErStuff(){
                    Name = risksEvent.Name, RiskSource = risksEvent.RiskSource,
                    Per1 = GetRandom(),
                    Per2 = GetRandom(),
                    Per3 = GetRandom(),
                    Per4 = GetRandom(),
                    Per5 = GetRandom(),
                    Per6 = GetRandom(),
                    Per7 = GetRandom(),
                    Per8 = GetRandom(),
                    Per9 = GetRandom(),
                    Per10 = GetRandom()
                });
            }
            foreach (var risksEvent in ScheduleRisksEvents)
            {
                RiskProbability.Add(new ErStuff(){
                    Name = risksEvent.Name, RiskSource = risksEvent.RiskSource,
                    Per1 = GetRandom(),
                    Per2 = GetRandom(),
                    Per3 = GetRandom(),
                    Per4 = GetRandom(),
                    Per5 = GetRandom(),
                    Per6 = GetRandom(),
                    Per7 = GetRandom(),
                    Per8 = GetRandom(),
                    Per9 = GetRandom(),
                    Per10 = GetRandom()
                });
            }
            foreach (var risksEvent in ProcessRisksEvents)
            {
                RiskProbability.Add(new ErStuff(){
                    Name = risksEvent.Name, RiskSource = risksEvent.RiskSource,
                    Per1 = GetRandom(),
                    Per2 = GetRandom(),
                    Per3 = GetRandom(),
                    Per4 = GetRandom(),
                    Per5 = GetRandom(),
                    Per6 = GetRandom(),
                    Per7 = GetRandom(),
                    Per8 = GetRandom(),
                    Per9 = GetRandom(),
                    Per10 = GetRandom()
                });
            }
            


            RiskAndPrioritiesAssessment = new ObservableCollection<Priorities>();
            foreach (var risksEvent in TechnicalRisksEvents)
            {
                RiskAndPrioritiesAssessment.Add(new Priorities(){Name = risksEvent.Name, RiskSource = risksEvent.RiskSource, Lrer = GetRandom()});
            }
            foreach (var risksEvent in CostRisksEvents)
            {
                RiskAndPrioritiesAssessment.Add(new Priorities(){Name = risksEvent.Name, RiskSource = risksEvent.RiskSource, Lrer = GetRandom()});
            }
            foreach (var risksEvent in ScheduleRisksEvents)
            {
                RiskAndPrioritiesAssessment.Add(new Priorities(){Name = risksEvent.Name, RiskSource = risksEvent.RiskSource, Lrer = GetRandom()});
            }
            foreach (var risksEvent in ProcessRisksEvents)
            {
                RiskAndPrioritiesAssessment.Add(new Priorities(){Name = risksEvent.Name, RiskSource = risksEvent.RiskSource, Lrer = GetRandom()});
            }
            
            CalculateRiskTracking();
            foreach (var risk in RiskProbability)
            {
                risk.PropertyChanged += CalculateRiskTracking;
            }
            RiskProbabilityGrid.ItemsSource = RiskProbability;
            RiskAndPrioritiesAssessmentGrid.ItemsSource = RiskAndPrioritiesAssessment;
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
        
        private void SelectResetAllTechnicalEvents_Click(object sender, RoutedEventArgs e)
        {
            ToggleSelection(TechnicalRisksEvents);
        }

        private void SelectResetAllCostEvents_Click(object sender, RoutedEventArgs e)
        {
            ToggleSelection(CostRisksEvents);
        }

        private void SelectResetAllScheduleEvents_Click(object sender, RoutedEventArgs e)
        {
            ToggleSelection(ScheduleRisksEvents);
        }

        private void SelectResetAllProcessEvents_Click(object sender, RoutedEventArgs e)
        {
            ToggleSelection(ProcessRisksEvents);
        }

        private void ToggleSelection(ObservableCollection<Risk> risks)
        {
            bool allSelected = risks.All(r => r.IsSelected);
            foreach (var risk in risks)
            {
                risk.IsSelected = !allSelected;
            }
        }

        public double GetRandom()
        {
            const double minimum = 0.01;
            const double maximum = 1.0;
            var random = new Random((int)DateTime.Now.Ticks);
            return Math.Round(random.NextDouble() * (maximum - minimum) + minimum, 2);
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

        private void CalculateRisks(object? sender, PropertyChangedEventArgs e)
        {
            double tech, cost, schedule, process;

            tech = Convert.ToDouble(TechnicalRisks.Count(x => x.IsSelected)) / 18 * 100;
            cost = Convert.ToDouble(CostRisks.Count(x => x.IsSelected)) / 18 * 100;
            schedule = Convert.ToDouble(ScheduleRisks.Count(x => x.IsSelected)) / 18 * 100;
            process = Convert.ToDouble(ProcessRisks.Count(x => x.IsSelected)) / 18 * 100;
            TechRisksPercent.Text = (tech).ToString("F2") + "%";
            CostRisksPercent.Text = (cost).ToString("F2") + "%";
            ScheduleRisksPercent.Text = (schedule).ToString("F2") + "%";
            ProcessRisksPercent.Text = (process).ToString("F2") + "%";
            AllRisksPercent.Text = (tech + cost + schedule + process).ToString("F2") + "%";
        }

        private void CalculateRiskEvents(object? sender, PropertyChangedEventArgs e)
        {
            double tech, cost, schedule, process;

            tech = Convert.ToDouble(TechnicalRisksEvents.Count(x => x.IsSelected)) / 47 * 100;
            cost = Convert.ToDouble(CostRisksEvents.Count(x => x.IsSelected)) / 47 * 100;
            schedule = Convert.ToDouble(ScheduleRisksEvents.Count(x => x.IsSelected)) / 47 * 100;
            process = Convert.ToDouble(ProcessRisksEvents.Count(x => x.IsSelected)) / 47 * 100;
            TechRiskEventsPercent.Text = (tech).ToString("F2") + "%";
            CostRiskEventsPercent.Text = (cost).ToString("F2") + "%";
            ScheduleRiskEventsPercent.Text = (schedule).ToString("F2") + "%";
            ProcessRiskEventsPercent.Text = (process).ToString("F2") + "%";
            AllRiskEventsPercent.Text = (tech + cost + schedule + process).ToString("F2") + "%";
        
        }

        private void CalculateRiskAnalysis(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName is "Er" or "Priority")
            {
                return;
            }
            CalculateRiskAnalysis();
        }

        private void CalculateRiskAnalysis()
        {
            foreach (var risk in ResultingRisksEvaluation)
            {
                risk.Er = Math.Round((risk.Per1 + risk.Per2 + risk.Per3 + risk.Per4 + risk.Per5 + risk.Per6 + risk.Per7 +
                            risk.Per8 + risk.Per9 + risk.Per10) / 10.0, 2);
            }

            int i = 0;
            foreach (var risk in ResultingRisksAmount)
            {
                risk.Er = ResultingRisksEvaluation[i].Er;
                risk.Vrer = Math.Round(risk.Er * risk.Lrer, 2);
                i++;
            }
            
            var maxVrer = ResultingRisksAmount.Max(x => x.Vrer);
            var minVrer = ResultingRisksAmount.Min(x => x.Vrer);
            var mpr = Math.Round((maxVrer - minVrer) / 3.0, 2);

            var leftMiddleBound = Math.Round(minVrer + mpr, 2);
            var rightMiddleBound = Math.Round(minVrer + 2 * mpr, 2);

            MinVrer.Text = minVrer.ToString();
            MaxVrer.Text = maxVrer.ToString();
            
            LowVrer.Text = $"[{minVrer}; {leftMiddleBound})";
            MidVrer.Text = $"[{leftMiddleBound}; {rightMiddleBound})";
            HighVrer.Text = $"[{rightMiddleBound}; {maxVrer})";

            foreach (var risk in ResultingRisksAmount)
            {
                if (risk.Vrer >= minVrer && risk.Vrer < leftMiddleBound)
                {
                    risk.Priority = "low priority";
                } 
                else if (risk.Vrer >= leftMiddleBound && risk.Vrer < rightMiddleBound)
                {
                    risk.Priority = "medium priority";
                }
                else
                {
                    risk.Priority = "high priority";
                }
            }
        }
        private void CalculateRiskTracking(object? sender, PropertyChangedEventArgs e)
        {
            
            if(e.PropertyName is "Er" or "Priority")
            {
                return;
            }
            CalculateRiskTracking();
        
        }

        private void CalculateRiskTracking()
        {
            foreach (var risk in RiskProbability)
            {
                risk.Er = Math.Round((risk.Per1 + risk.Per2 + risk.Per3 + risk.Per4 + risk.Per5 + risk.Per6 + risk.Per7 +
                            risk.Per8 + risk.Per9 + risk.Per10) / 10.0, 2);
            }

            int i = 0;
            foreach (var risk in RiskAndPrioritiesAssessment)
            {
                risk.Er = RiskProbability[i].Er;
                risk.Vrer = Math.Round(risk.Er * risk.Lrer, 2);
                i++;
            }
            
            var maxVrer = RiskAndPrioritiesAssessment.Max(x => x.Vrer);
            var minVrer = RiskAndPrioritiesAssessment.Min(x => x.Vrer);
            var mpr = Math.Round((maxVrer - minVrer) / 3.0, 2);

            var leftMiddleBound = Math.Round(minVrer + mpr, 2);
            var rightMiddleBound = Math.Round(minVrer + 2 * mpr, 2);

            MinEvrer.Text = minVrer.ToString();
            MaxEvrer.Text = maxVrer.ToString();
            
            LowEvrer.Text = $"[{minVrer}; {leftMiddleBound})";
            MidEvrer.Text = $"[{leftMiddleBound}; {rightMiddleBound})";
            HighEvrer.Text = $"[{rightMiddleBound}; {maxVrer})";

            foreach (var risk in RiskAndPrioritiesAssessment)
            {
                if (risk.Vrer >= minVrer && risk.Vrer < leftMiddleBound)
                {
                    risk.Priority = "low priority";
                } 
                else if (risk.Vrer >= leftMiddleBound && risk.Vrer < rightMiddleBound)
                {
                    risk.Priority = "medium priority";
                }
                else
                {
                    risk.Priority = "high priority";
                }
            }
        }
    }
}
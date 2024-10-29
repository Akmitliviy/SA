using System.Collections.ObjectModel;
using System.ComponentModel;
using Lab05_SA.RiskObjects;

namespace Lab05_SA;

public class Calculator
{
    
        
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
    
    public Calculator(ObservableCollection<Risk> technicalRisks, ObservableCollection<Risk> costRisks,
                        ObservableCollection<Risk> scheduleRisks, ObservableCollection<Risk> processRisks,
                        ObservableCollection<Risk> technicalRisksEvents, ObservableCollection<Risk> costRisksEvents,
                        ObservableCollection<Risk> scheduleRisksEvents, ObservableCollection<Risk> processRisksEvents,
                        ObservableCollection<ErStuff> resultingRisksEvaluation, ObservableCollection<Priorities> resultingRisksAmount,
                        ObservableCollection<Solutions> technicalRisksSolution, ObservableCollection<Solutions> costRisksSolution,
                        ObservableCollection<Solutions> scheduleRisksSolution, ObservableCollection<Solutions> processRisksSolution,
                        ObservableCollection<ErStuff> riskProbability, ObservableCollection<Priorities> riskAndPrioritiesAssessment)
    {
        TechnicalRisks = technicalRisks;
        CostRisks = costRisks;
        ScheduleRisks = scheduleRisks;
        ProcessRisks = processRisks;
        TechnicalRisksEvents = technicalRisksEvents;
        CostRisksEvents = costRisksEvents;
        ScheduleRisksEvents = scheduleRisksEvents;
        ProcessRisksEvents = processRisksEvents;
        ResultingRisksEvaluation = resultingRisksEvaluation;
        ResultingRisksAmount = resultingRisksAmount;
        TechnicalRisksSolution = technicalRisksSolution;
        CostRisksSolution = costRisksSolution;
        ScheduleRisksSolution = scheduleRisksSolution;
        ProcessRisksSolution = processRisksSolution;
        RiskProbability = riskProbability;
        RiskAndPrioritiesAssessment = riskAndPrioritiesAssessment;
    }
}
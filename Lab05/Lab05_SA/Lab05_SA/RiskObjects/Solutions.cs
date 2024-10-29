using System.ComponentModel;

namespace Lab05_SA.RiskObjects;

public enum RiskSolutions
{
    /// <summary>Попереднє навчання членів проєктного колективу.</summary>
    PreliminaryTraining,

    /// <summary>Узгодження детального переліку вимог до ПЗ із замовником.</summary>
    RequirementsAgreementWithCustomer,

    /// <summary>Внесення узгодженого переліку вимог до ПЗ замовника в договір.</summary>
    RequirementsInclusionInContract,

    /// <summary>Точне слідування вимогам замовника з узгодженого переліку вимог до ПЗ.</summary>
    ExactRequirementsAdherence,

    /// <summary>Попередні дослідження ринку.</summary>
    PreliminaryMarketResearch,

    /// <summary>Експертна оцінка програмного проєкту досвідченим стороннім консультантом.</summary>
    ExpertProjectEvaluation,

    /// <summary>Консультації досвідченого стороннього консультанта.</summary>
    ExperiencedConsultantAdvice,

    /// <summary>Тренінг з вивчення необхідних інструментів розроблення ПЗ.</summary>
    ToolsTraining,

    /// <summary>Укладення договору страхування.</summary>
    InsuranceContract,

    /// <summary>Використання "шаблонних" рішень з вдалих попередніх проєктів при управлінні програмним проєктом.</summary>
    UseOfTemplateSolutions,

    /// <summary>Підготовка документів, які показують важливість даного проєкту для досягнення фінансових цілей компанії-розробника.</summary>
    DocumentationOfProjectImportance,

    /// <summary>Реорганізація роботи проєктного колективу так, щоб обов'язки та робота членів колективу перехрещували один одного.</summary>
    TeamReorganization,

    /// <summary>Придбання (замовлення) частини компонентів розроблюваного ПЗ.</summary>
    ComponentAcquisition,

    /// <summary>Заміна потенційно дефектних компонентів розроблюваного ПЗ придбаними компонентами, які гарантують якість виконання роботи.</summary>
    DefectiveComponentReplacement,

    /// <summary>Придбання більш продуктивної бази даних.</summary>
    HighPerformanceDatabasePurchase,

    /// <summary>Використання генератора програмного коду.</summary>
    CodeGeneratorUse,

    /// <summary>Реорганізація роботи проєктного колективу залежно від рівня трудності виконаних ним завдань та професійних рівнів розробників.</summary>
    ReorganizationBasedOnTaskDifficulty,

    /// <summary>Внесення в проєкт придатних компонентів ПЗ, які були розроблені для інших програмних проєктів.</summary>
    ReusableComponentInclusion,

    /// <summary>Відстрочка початку розроблення даного ПЗ.</summary>
    ProjectStartDelay
}

public class Solutions : INotifyPropertyChanged
{

    
    private RiskSolutions _riskSolution;

    
    public string Name { get; init; }
    public string RiskSource { get; init; }

    public RiskSolutions RiskSolution
    {
        get => _riskSolution;
        set
        {
            if (_riskSolution != value)
            {
                _riskSolution = value;
                OnPropertyChanged(nameof(RiskSolution));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
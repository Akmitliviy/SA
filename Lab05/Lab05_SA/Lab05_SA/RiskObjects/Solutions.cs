using System.ComponentModel;

namespace Lab05_SA.RiskObjects;


public class Solutions : INotifyPropertyChanged
{

    private string _riskSolution;

    public int Number { get; set; }
    public string RiskSource { get; set; }

    public string RiskSolution
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
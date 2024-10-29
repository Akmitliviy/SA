using System.ComponentModel;

namespace Lab05_SA.RiskObjects;


public class Priorities : INotifyPropertyChanged
{
    private double _er;
    private double _lrer;
    private double _vrer;
    private string _priority;

    public string Name { get; set; }
    public string RiskSource { get; set; }

    public double Er
    {
        get => _er;
        set
        {
            if (value is > 0.009 and < 1.0)
            {
                _er = value;
                OnPropertyChanged(nameof(Er));
            }
        }
    }

    public double Lrer
    {
        get => _lrer;
        set
        {
            if (value is > 0.009 and < 1.0)
            {
                _lrer = value;
                OnPropertyChanged(nameof(Lrer));
            }
        }
    }

    public double Vrer
    {
        get => _vrer;
        set
        {
            if (value is > 0.009 and < 1.0)
            {
                _vrer = value;
                OnPropertyChanged(nameof(Vrer));
            }
        }
    }

    public string Priority
    {
        get => _priority;
        set => _priority = value;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
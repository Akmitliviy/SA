using System.ComponentModel;

namespace Lab05_SA.RiskObjects;


public class Priorities : INotifyPropertyChanged
{
    private double _er;
    private double _lrer;
    private double _vrer;

    public int Number { get; set; }
    public string RiskSource { get; set; }

    public double Er
    {
        get => _er;
        set
        {
            if ((_er - value) > 0.00000001)
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
            if ((_lrer - value) > 0.00000001)
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
            if ((_vrer - value) > 0.00000001)
            {
                _vrer = value;
                OnPropertyChanged(nameof(Vrer));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
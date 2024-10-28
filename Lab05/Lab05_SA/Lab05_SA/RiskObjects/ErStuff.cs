using System.ComponentModel;

namespace Lab05_SA.RiskObjects;


public class ErStuff : INotifyPropertyChanged
{
    private double _per1;
    private double _per2;
    private double _per3;
    private double _per4;
    private double _per5;
    private double _per6;
    private double _per7;
    private double _per8;
    private double _per9;
    private double _per10;

    public int Number { get; set; }
    public string RiskSource { get; set; }

    public double Per1
    {
        get => _per1;
        set
        {
            if ((_per1 - value) > 0.00000001)
            {
                _per1 = value;
                OnPropertyChanged(nameof(Per1));
            }
        }
    }
    public double Per2
    {
        get => _per2;
        set
        {
            if ((_per2 - value) > 0.00000001)
            {
                _per2 = value;
                OnPropertyChanged(nameof(Per2));
            }
        }
    }
    public double Per3
    {
        get => _per3;
        set
        {
            if ((_per3 - value) > 0.00000001)
            {
                _per3 = value;
                OnPropertyChanged(nameof(Per3));
            }
        }
    }
    public double Per4
    {
        get => _per4;
        set
        {
            if ((_per4 - value) > 0.00000001)
            {
                _per4 = value;
                OnPropertyChanged(nameof(Per4));
            }
        }
    }
    public double Per5
    {
        get => _per5;
        set
        {
            if ((_per5 - value) > 0.00000001)
            {
                _per5 = value;
                OnPropertyChanged(nameof(Per5));
            }
        }
    }
    public double Per6
    {
        get => _per6;
        set
        {
            if ((_per6 - value) > 0.00000001)
            {
                _per6 = value;
                OnPropertyChanged(nameof(Per6));
            }
        }
    }
    public double Per7
    {
        get => _per7;
        set
        {
            if ((_per7 - value) > 0.00000001)
            {
                _per7 = value;
                OnPropertyChanged(nameof(Per7));
            }
        }
    }
    public double Per8
    {
        get => _per8;
        set
        {
            if ((_per8 - value) > 0.00000001)
            {
                _per8 = value;
                OnPropertyChanged(nameof(Per8));
            }
        }
    }
    public double Per9
    {
        get => _per9;
        set
        {
            if ((_per9 - value) > 0.00000001)
            {
                _per9 = value;
                OnPropertyChanged(nameof(Per9));
            }
        }
    }
    public double Per10
    {
        get => _per10;
        set
        {
            if ((_per10 - value) > 0.00000001)
            {
                _per10 = value;
                OnPropertyChanged(nameof(Per10));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
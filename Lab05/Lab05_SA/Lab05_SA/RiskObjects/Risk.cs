﻿using System.ComponentModel;

namespace Lab05_SA.RiskObjects;


public class Risk : INotifyPropertyChanged
{
    private bool _isSelected;

    public int Number { get; set; }
    public string RiskSource { get; set; }

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (_isSelected != value)
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
using System;
using UnityEngine;

[Serializable]
public class StatusCount
{
    public event Action<float> OnValueChanged;

    private StatusData _data;

    private float _currentValue;
    public float Value => _currentValue;

    public StatusCount(StatusData data)
    {
        _data = data;

        _currentValue = data.BaseValue;
    }

    public void AddValue(float value)
    {
        _currentValue += value;

        _currentValue = Mathf.Clamp(_currentValue, _data.MinValue, _data.MaxValue);

        OnValueChanged?.Invoke(_currentValue);
    }

    public void MulValue(float value)
    {
        _currentValue *= value;

        _currentValue = Mathf.Clamp(_currentValue, _data.MinValue, _data.MaxValue);

        OnValueChanged?.Invoke(_currentValue);
    }

    public void Reset()
    {
        _currentValue = _data.BaseValue;

        OnValueChanged?.Invoke(_currentValue);
    }
}

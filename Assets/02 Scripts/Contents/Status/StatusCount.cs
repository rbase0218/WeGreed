using System;
using UnityEngine;

[Serializable]
public class StatusCount
{
    public event Action<float> OnValueChanged;

    private StatusData _data;

    private float _currentValue;

    public float Value
    {
        get => _currentValue;

        set
        {
            _currentValue = Mathf.Clamp(value, _data.MinValue, _data.MaxValue);

            OnValueChanged?.Invoke(_currentValue);
        }
    }

    public StatusCount(StatusData data)
    {
        _data = data;

        _currentValue = data.BaseValue;
    }

    public void AddValue(float value)
    {
        Value += value;
    }

    public void MulValue(float value)
    {
        Value *= value;
    }

    public void Reset()
    {
        Value = _data.BaseValue;
    }
}

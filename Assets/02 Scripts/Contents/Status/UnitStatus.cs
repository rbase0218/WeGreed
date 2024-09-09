using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public enum StatusType
{
    MaxHP = 1,
    HP,
    AttackPower,
    AttackDelay,
    AttackDistance,
    DefencePower,
    MoveSpeed,
    ViewDistance,
    CriticalPercent,
    Level,
    Exp,
    LifeSteal,
    AbilityHaste
}

[CreateAssetMenu(fileName = "UnitStatus", menuName = "Status System/Status")]
public class UnitStatus : ScriptableObject
{
    [SerializeField] private List<StatusCount> StatusList;

    private Dictionary<StatusType, StatusCount> _statusDictionary;

    public void Initialize()
    {
        var baseStats = App.Data.Title.StatusDatas;

        _statusDictionary = new(baseStats.Count);

        foreach (var stat in baseStats.Values)
        {
            _statusDictionary[(StatusType)stat.Type] = new StatusCount(stat);
        }

        StatusList = _statusDictionary.Values.ToList();
    }

    public StatusCount GetStatus(StatusType type)
    {
        if (_statusDictionary.TryGetValue(type, out var status))
        {
            return status;
        }
        else
        {
            Debug.LogWarning($"Status {type} not found, returning default.");

            return new StatusCount(new StatusData()); 
        }
    }
}

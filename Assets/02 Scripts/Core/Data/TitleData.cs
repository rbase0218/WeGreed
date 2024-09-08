using System;
using System.Collections.Generic;

[Serializable]
public class StatusData
{
    public int Type;
    public string Code;
    public int BaseValue;
    public int MaxValue;
    public int MinValue;
}

public class TitleData : Data
{
    public Dictionary<int, StatusData> _statusDatas = new();

    private const string _statusDataPath = "Data/StatusData";

    protected override void Awake()
    {
        base.Awake();

        LoadData();
    }

    private void LoadData()
    {
        _statusDatas.Clear();

        var statusDatasRaw = DataLoader.LoadData<StatusData>(_statusDataPath);

        foreach (var data in statusDatasRaw)
        {
            _statusDatas.Add(data.Type, data);
        }
    }
}
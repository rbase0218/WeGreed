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
    public Dictionary<int, StatusData> StatusDatas { get; private set; }

    private const string _statusDataPath = "Data/StatusData";

    protected override void Awake()
    {
        base.Awake();

        LoadData();
    }

    private void LoadData()
    {
        var statusDatasRaw = DataLoader.LoadData<StatusData>(_statusDataPath);

        StatusDatas = new(statusDatasRaw.Length);

        foreach (var data in statusDatasRaw)
        {
            StatusDatas.Add(data.Type, data);
        }
    }
}
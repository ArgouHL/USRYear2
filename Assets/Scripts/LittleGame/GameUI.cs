using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Queue<string> logs = new Queue<string>();
    [SerializeField] private int logNum;
    public static GameUI instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    [SerializeField] private TMP_Text gameTime;
    [SerializeField] private TMP_Text gameWeek;
    [SerializeField] private TMP_Text logText;
    [SerializeField] private TMP_Text gameMoney;
    [SerializeField] private TMP_Text gamelocation;
    public Image staffImg;

    private void Start()
    {
        ShowGameWeekAndLocation();
        UpdateMoney();
    }


    public void UpdateGameTime(float timefloat)
    {
        TimeSpan time = TimeSpan.FromSeconds(timefloat);
        gameTime.text = time.ToString("m':'ss");
    }
    

    public void ShowGameWeekAndLocation()
    {
        gameWeek.text = SelfCodeHelper.GetMonth(StageControl.currentMonth) + " " + SelfCodeHelper.GetWeek(StageControl.currentWeek);
        gamelocation.text = StageControl.instance.currentLevel.PortName;
    }

    public void AddLog(string log)
    {
        
        logs.Enqueue(log);
        if (logs.Count > logNum)
        {
            logs.Dequeue();
        }
        string _log = "";
        foreach (var l in logs)
        {
            _log += l + "\n";
        }
        _log = _log.TrimEnd('\r', '\n');
        logText.text = _log;
        Debug.Log(logs);
        Debug.Log(_log);
    }

    public void SetStaffImage(StaffData staffData)
    {
    
        staffImg.sprite = staffData.StaffPic;
        staffImg.color = Color.white;
    }

    public void UpdateMoney()
    {
        gameMoney.text = ScoreCount.instance.income.ToString() ;
    }
}

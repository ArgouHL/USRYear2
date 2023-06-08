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

    public Image staffImg;
    public void UpdateGameTime(float timefloat)
    {
        TimeSpan time = TimeSpan.FromSeconds(timefloat);
        gameTime.text = time.ToString("m':'ss");
    }
    public void ShowGameWeek(int week)
    {
        gameWeek.text = "²Ä" + week + "¶g";
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
    }
}

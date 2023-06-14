using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public static ScoreCount instance;
    public int income { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    internal void Initialization()
    {
        income = 0;
    }

    public void AddMoney(int addMoney)
    {
        income += addMoney;
        //updateShow
    }

    public void FinalCount()
    {
        ResultShow.instance.CalAndShowResult(PlayerDataControl.instance.playerData.Player_Money,income, out int netIncome);
        AddToPlayer(netIncome);

    }








    public void AddToPlayer(int netIncome)
    {
        if (netIncome <= 0)
            return;
        PlayerDataControl.instance.playerData.GetMoney(netIncome);
        //PlayerDataControl.instance.Save();
    }

}

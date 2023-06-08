using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public static ScoreCount instance;
    public int income { get; private set; }

    private void Awake()
    {
        if(instance!=null)
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
        ResultShow.instance.CalAndShowResult(income);
    }

   






    public void AddToPlayer()
    {
        PlayerDataControl.instance.playerData.GetMoney(income);
        PlayerDataControl.instance.Save();
    }

}

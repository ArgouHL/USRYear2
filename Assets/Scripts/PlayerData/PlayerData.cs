using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "NewPlayer")]
public class PlayerData : ScriptableObject
{
    public int Player_Money;
    public bool normalOpen = false;
    public bool hardOpen = false;
    public int month;

    internal void NewData()
    {
        Player_Money = 0;
        month = 1;
        normalOpen = false;
        hardOpen = false;

    }

    internal void NormalOpenLevel()
    {
        normalOpen = true;
    }


    internal void HardOpenLevel()
    {
        hardOpen = true;
    }

    internal void saveMounth(int _month)
    {
        month = _month;
    }

    internal void GetMoney(int money)
    {
        Player_Money += money;
    }
    internal void Reverse(Account ac)
    {
        Player_Money = ac.Player_Money;
        normalOpen = ac.normalOpen;
        hardOpen = ac.hardOpen;
        month = ac.month;

    }
}
[System.Serializable]
public class Account
{
    internal int Player_Money;
    internal bool normalOpen;
    internal bool hardOpen;
    internal int month;
    internal Account(PlayerData ac)
    {
        Player_Money = ac.Player_Money;
        normalOpen = ac.normalOpen;
        hardOpen = ac.hardOpen;
        month = ac.month;

    }
}


public enum OpenLevel { One, Two, Three }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "NewPlayer")]
public class PlayerData : ScriptableObject
{
    public int Player_Money;
    public OpenLevel nowOpenLevel;

    internal void Reload()
    {
        Player_Money = 0;
        nowOpenLevel = OpenLevel.One;

    }

    internal void SetOpenLevel(OpenLevel level)
    {
        nowOpenLevel = level;
    }

    internal void GetMoney(int money)
    {
        Player_Money += money;
    }
    internal void Reverse(Account ac)
    {
        Player_Money = ac.Player_Money;
        nowOpenLevel = ac.newOpenLevel;

    }
}
[System.Serializable]
public class Account
{
    internal int Player_Money;
    internal OpenLevel newOpenLevel;
    internal Account(PlayerData ac)
    {
        Player_Money = ac.Player_Money;
        newOpenLevel = ac.nowOpenLevel;

    }
}


public enum OpenLevel { One, Two, Three }

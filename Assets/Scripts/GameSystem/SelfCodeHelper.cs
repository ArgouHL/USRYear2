using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SelfCodeHelper
{
    public static T[] ShuffleOrder<T>(ref T[] array)
    {
        System.Random random = new System.Random();
        array = array.OrderBy(x => random.Next()).ToArray();
        return array;
    }


    public static string GetGoodName(GoodType type)
    {
        string good;
        switch (type)
        {
            case GoodType.Paper:
            default:
                good = "�ʥЯ�";
                break;
            case GoodType.China:
                good = "����";
                break;
            case GoodType.Seafood:
                good = "���A";
                break;
            case GoodType.Medi:
                good = "����";
                break;
            case GoodType.Cloth:
                good = "����";
                break;
            case GoodType.Tea:
                good = "��";
                break;
            case GoodType.Rice:
                good = "��";
                break;

        }
        return good;
    }

    public static string GetWeek(int week)
    {
        string _week;
        switch (week)
        {
            default:
            case 1:
                _week = "�Ĥ@�g";
                break;
            case 2:
                _week = "�ĤG�g";
                break;
            case 3:
                _week = "�ĤT�g";
                break;
            case 4:
                _week = "�ĥ|�g";
                break;

        }
        return _week;
    }



}
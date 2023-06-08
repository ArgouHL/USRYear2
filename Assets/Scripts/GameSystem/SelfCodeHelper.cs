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
                good = "百田紙";
                break;
            case GoodType.China:
                good = "瓷器";
                break;
            case GoodType.Seafood:
                good = "海鮮";
                break;
            case GoodType.Medi:
                good = "中藥";
                break;
            case GoodType.Cloth:
                good = "布料";
                break;
            case GoodType.Tea:
                good = "茶";
                break;
            case GoodType.Rice:
                good = "米";
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
                _week = "第一週";
                break;
            case 2:
                _week = "第二週";
                break;
            case 3:
                _week = "第三週";
                break;
            case 4:
                _week = "第四週";
                break;

        }
        return _week;
    }



}
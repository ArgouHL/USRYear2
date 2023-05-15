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
}

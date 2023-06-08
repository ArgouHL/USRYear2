using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RandomObjs<T>
{
    
    private List<Tuple<T, float>> weightedList;
    private float totalWeight;

    public RandomObjs()
    {
       
        weightedList = new List<Tuple<T, float>>();
        totalWeight = 0;
    }

    public void AddItem(T item, float weight)
    {
        //if (weight <= 0)
        //    throw new ArgumentException("Weight must be a positive float.");

        weightedList.Add(new Tuple<T, float>(item, weight));
        totalWeight += weight;
    }

    public T GetRandomItem()
    {
        if (weightedList.Count == 0)
            throw new InvalidOperationException("No items have been added.");

        float randomNumber = UnityEngine.Random.Range(0,totalWeight);
        float cumulativeWeight = 0;

        foreach (var tuple in weightedList)
        {
            cumulativeWeight += tuple.Item2;
            if (randomNumber <= cumulativeWeight)
                return tuple.Item1;
        }

        // This should never happen unless there's an error in the logic
        throw new InvalidOperationException("Unable to retrieve a random item.");
    }

}

//public class RandomObject
//{

//    public int Weight { set; get; }
//}

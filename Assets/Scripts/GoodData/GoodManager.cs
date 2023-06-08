using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodManager : MonoBehaviour
{
    public static GoodManager instance;

    private Dictionary<GoodType, GoodData> allGood = new Dictionary<GoodType, GoodData>();
    [SerializeField] private GoodData[] goods;

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

    private void Start()
    {
        foreach (var good in goods)
        {
            if (allGood.ContainsKey(good.type)) continue;
            allGood.Add(good.type, good);
        }
    }

    public int GetPrice(GoodType type)
    {
        GoodData good;

        allGood.TryGetValue(type,out good);
        return good.price;
    }
}

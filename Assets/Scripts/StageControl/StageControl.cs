using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageControl : MonoBehaviour
{
    public static StageControl instance;

    internal StageDataObj currentLevel;
    internal StaffData currentStaff;
    [SerializeField]
    private GoodData[] goodDatas;
    private Dictionary<GoodType, GoodData> goodDict= new Dictionary<GoodType, GoodData>();


    [SerializeField] private float gameTime=60f;
    private int currentDay = 1;
    internal float currentTime = 0;
    internal int week = 1;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        foreach(var g in goodDatas)
        {
            goodDict.Add(g.type, g);
        }
    }

    public void SetCurrentLevel(StageDataObj InputLevel)
    {
        currentLevel = InputLevel;
    }
    
    
    
    public void SetStaff(StaffData InputStaff)
    {
        currentStaff = InputStaff;
        //game Start

    }

    public void ResetTime()
    {
        currentTime = 0;
    }


    public List<GoodData> GetGoodsData()
    {
        var _goods = new List<GoodData>();
        foreach(var sg in currentLevel.StageGoods)
        {
            GoodData gd;
            goodDict.TryGetValue(sg, out gd);
            _goods.Add(gd);
        }
        return _goods;

    }
}

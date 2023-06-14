using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageControl : MonoBehaviour
{
    public static StageControl instance;

    internal StageDataObj currentLevel;
    internal StaffData currentStaff;
    internal int[] staffCost;
    [SerializeField]
    private GoodData[] goodDatas;
    private Dictionary<GoodType, GoodData> goodDict= new Dictionary<GoodType, GoodData>();


    [SerializeField] internal float gameTime=5;
    internal static int currentWeek = 1;
    internal static int currentMonth = 1;

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

    internal int TotalStaffCost()
    {
        return staffCost.Sum();
    }

    public void SetCurrentLevel(StageDataObj InputLevel)
    {
        currentLevel = InputLevel;
        staffCost = new int[4];
        currentWeek = 1;
        ScoreCount.instance.Initialization();
    }
    
    
    
    public void SetStaff(StaffData inputStaff)
    {
        currentStaff = inputStaff;
        staffCost[currentWeek - 1] = inputStaff.Cost;
        GameUI.instance.SetStaffImage(inputStaff);
    }

   

    public List<GoodData> GetGoodsData()
    {
        var _goods = new List<GoodData>();
        foreach(var sg in currentLevel.StageGoods)
        {
            GoodData gd;
            goodDict.TryGetValue(sg, out gd);
            _goods.Add(gd);
            //Debug.Log(gd);
        }
        return _goods;

    }
    public List<GoodType> GetGoodTypes()
    {
        var _goodsTypes = new List<GoodType>();
        foreach (var sg in currentLevel.StageGoods)
        {
            GoodData gd;
            goodDict.TryGetValue(sg, out gd);
            _goodsTypes.Add(gd.type);
        }
        return _goodsTypes;
    }

    public void NextWeek()
    {
        currentWeek++;
        
        LevelLoader.NextWeek();
    }

   



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



[System.Serializable]
[CreateAssetMenu(menuName = "StageData/Creat new Stage")]
public class StageDataObj : ScriptableObject
{

    public Level level;

    [SerializeField]
    private string portName;
    public string PortName { get { return portName; } }


    [SerializeField]
    private string info;
    public string Info { get { return info; } }

    [SerializeField]
    private GoodType[] stageGoods;
    public GoodType[] StageGoods { get { return stageGoods; } }
    public string StageGoodsString()
    { return SelfCodeHelper.GetGoodName(stageGoods[0]) + "," + SelfCodeHelper.GetGoodName(stageGoods[01]) + "," + SelfCodeHelper.GetGoodName(stageGoods[2]); }


    [SerializeField]
    private int cost;
    public int Cost { get { return cost; } }

    [SerializeField]
    private AnimationCurve easyQuestion;
    public AnimationCurve EasyQuestion { get { return easyQuestion; } }

    [SerializeField]
    private AnimationCurve normalQuestion;
    public AnimationCurve NormalQuestion { get { return normalQuestion; } }

    [SerializeField]
    private AnimationCurve hardQuestion;
    public AnimationCurve HardQuestion { get { return hardQuestion; } }





}
public enum Level { easy, normal, hard }
public enum GoodType { Paper, China, Seafood, Medi, Cloth, Tea, Rice }
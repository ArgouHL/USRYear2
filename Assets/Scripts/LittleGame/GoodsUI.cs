using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GoodsUI : MonoBehaviour
{
    private GoodData[] goodDatas;
    [SerializeField]
    private GoodSelect[] goodSelects;

    private void Start()
    {

        goodDatas = StageControl.instance.GetGoodsData().ToArray();
        foreach (var g in goodDatas)
        {
            Debug.Log(g.type);
        }
        SelfCodeHelper.ShuffleOrder(ref goodDatas);
        for (int i = 0; i < goodDatas.Length; i++)
        {
            goodSelects[i].SetGood(goodDatas[i]);
            Debug.Log(goodDatas[i].type);
        }

    }


}

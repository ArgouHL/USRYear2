using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GoodsUI : MonoBehaviour
{
    public static GoodsUI instance;
    private GoodData[] goodDatas;
    
    [SerializeField]
    private GoodSelect[] goodSelects;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;            
        }

    }
    private void Start()
    {

        goodDatas = StageControl.instance.GetGoodsData().ToArray();
        foreach (var g in goodDatas)
        {
            //Debug.Log(g.type);
        }
        RandomPos();

    }

    private void RandomPos()
    {
        SelfCodeHelper.ShuffleOrder(ref goodDatas);
        for (int i = 0; i < goodDatas.Length; i++)
        {
            goodSelects[i].SetGood(goodDatas[i]);
            Debug.Log(goodDatas[i].type);
        }
    }

    public void HideOneWrong(GoodType correctType)
    {

        var index = Random.Range(0, 3);
        Debug.Log("ran" + index);
        while(goodDatas[index].type== correctType)
        {
            index = Random.Range(0, 3);
            Debug.Log("ran" + index);
        }
        goodSelects[index].Hide();
    }

    public void ShowAll()
    {
        foreach(var g in goodSelects)
        {
            g.Show();
        }
    }

}

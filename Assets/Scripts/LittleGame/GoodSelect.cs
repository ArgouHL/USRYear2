using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodSelect : MonoBehaviour
{
    private GoodType goodType;

    [SerializeField] private Image image;

    public void SetGood(GoodData data)
    {
        goodType = data.type;
        image.sprite = data.sprite;
    }



    public void SelectThisGood()
    {
        GameManagement.instance.SelectGood(goodType);
    }


}

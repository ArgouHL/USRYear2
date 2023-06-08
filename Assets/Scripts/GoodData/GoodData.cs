using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GoodData", menuName = "NewGood")]
public class GoodData : ScriptableObject
{
    public string goodName;
    public GoodType type;
    public Sprite sprite;
    public int price;


}

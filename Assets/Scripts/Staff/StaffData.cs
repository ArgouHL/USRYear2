using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "StaffData/Creat new Staff")]
public class StaffData : ScriptableObject
{
    [SerializeField] private string staffName;
    public string StaffName { get { return staffName; } }

    [SerializeField] private Sprite staffPic;
    public Sprite StaffPic { get { return staffPic; } }

    [SerializeField] private StaffType type;
    public StaffType Type { get { return type; } }

    [Multiline]
    [SerializeField] private string info;
    public string Info { get { return info; } }



}

public enum StaffType { Normal}

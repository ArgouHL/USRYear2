using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StaffShow : MonoBehaviour
{
    private StaffData staffData;
    

    [SerializeField] private Image pic;
    [SerializeField] private TMP_Text staffName;
    [SerializeField] private TMP_Text staffInfo;
    [SerializeField] private Button select;

    internal void Show(StaffData _staffData)
    {
        staffData = _staffData;
        pic.sprite = staffData.StaffPic;
        staffName.text = staffData.StaffName;
        staffInfo.text = staffData.Info;
        select.interactable = true;
    }

    public void SelectThisStaff()
    {
        StageControl.instance.SetStaff(staffData);
        StaffSelect.instance.HideUI();

    }

     internal void setButtonActive(bool b)
    {
        select.interactable = b;
    }
}

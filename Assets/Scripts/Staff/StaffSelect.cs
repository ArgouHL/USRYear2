using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StaffSelect : MonoBehaviour
{
    public static StaffSelect instance;

    [SerializeField] private StaffData[] allStaff;

    [SerializeField] private StaffShow[] staffShows;

    [SerializeField] private CanvasGroup ui;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public void StartSelect()
    {
        List<StaffData> _staffs = allStaff.ToList();
        List<StaffData> threeStaffs = new List<StaffData>();
        for (int i = 0; i < staffShows.Length; i++)
        {

            var index = Random.Range(0, _staffs.Count);
            var staff = _staffs[index];
            while (threeStaffs.Contains(staff))
            {
                index = Random.Range(0, _staffs.Count);
                staff = _staffs[index];

            }

            threeStaffs.Add(_staffs[index]);

        }


        for (int p = 0; p < staffShows.Length; p++)
        {
            staffShows[p].Show(threeStaffs[p]);
        }
        setButtonActive(true);
    }

    internal void setButtonActive(bool b)
    {
        foreach(var staffShow in staffShows)
        {
            staffShow.setButtonActive(b);
        }    
    }

    internal void HideUI() 
    {
        ui.alpha = 0;
        ui.interactable = false;
        ui.blocksRaycasts = false;
    }

    internal void ShowUI()
    {
        ui.alpha = 1;
        ui.interactable = true;
        ui.blocksRaycasts = true;
    }


}

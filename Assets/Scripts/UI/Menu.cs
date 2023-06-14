using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Menu : MonoBehaviour
{
    [SerializeField] private UIMove Inst, button,logo;
    [SerializeField] private PortSelect portSelect;
    [SerializeField] private TMP_Text startbutton;



    public void StartGame()
    {
        
        Debug.Log("Startbutton");
        PlayerDataControl.instance.LoadPlayer();
        button.hide(Way.L);
        portSelect.ShowPorts();
        logo.hide(Way.R);


    }

    public void ShowInst()
    {
        Debug.Log("ShowInst");
        Inst.Show();
        SfxControl.instance.PlayClick();
    }

    public void Exit()
    {
        SfxControl.instance.PlayClick();
        Debug.Log("Exit");
        Application.Quit();
    }

    public void Clear()
    {
        PlayerDataControl.instance.NewRec();
        startbutton.text = "開始遊戲";
        SfxControl.instance.PlayClick();
    }

    private void Start()
    {
        MusicControl.instance.PlayBGMFadeIn(bgmType.title);
        if (StageControl.currentMonth != 1)
            startbutton.text = "繼續遊戲";

    }
}

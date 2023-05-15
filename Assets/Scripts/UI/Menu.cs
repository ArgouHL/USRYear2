using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private UIMove Inst, button;
    [SerializeField] private PortSelect portSelect;
   public void StartGame()
    {
        Debug.Log("Startbutton");
        PlayerDataControl.instance.LoadPlayer();
        button.hide();
        portSelect.ShowPorts();
        
    }

    public void ShowInst()
    {
        Debug.Log("ShowInst");
        Inst.Show();
    }

    public void Exit()
    {
        Debug.Log("Exit");
    }
}
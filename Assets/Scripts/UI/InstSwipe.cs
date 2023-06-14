using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstSwipe : MonoBehaviour
{
    [SerializeField] private GameObject story, inst;



    public void ShowStory()
    {
        SfxControl.instance.PlayClick();
        inst.SetActive(false);
        story.SetActive(true);
    }

    public void ShowInst()
    {
        SfxControl.instance.PlayClick();
        inst.SetActive(true);
        story.SetActive(false);
    }
}

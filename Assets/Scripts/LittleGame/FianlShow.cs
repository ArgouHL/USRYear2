using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FianlShow : MonoBehaviour
{
    public static FianlShow instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    [SerializeField] private float duration = 1;


   [SerializeField] private CanvasGroup passUI, passText, failUI, failText;

    public void Pass()
    {
        SfxControl.instance.PlayPass();
        passUI.blocksRaycasts = true;
        LeanTween.value(0, 1, duration).setOnUpdate((float val) => passUI.alpha = val).setOnComplete(() =>
         LeanTween.delayedCall(1,()=>
          LeanTween.value(0, 1, duration).setOnUpdate((float val) => passText.alpha = val).setOnComplete(()=>
           LeanTween.delayedCall(9, () =>
           {
               GameFade.instance.FadeOut(1f);
               LeanTween.delayedCall(1.2f, () =>
                      SceneManager.LoadScene("Menu"));
           }))));
    }

    public void Fail()
    {
        SfxControl.instance.PlayFail();
        failUI.blocksRaycasts = true;
        LeanTween.value(0, 1, duration).setOnUpdate((float val) => failUI.alpha = val).setOnComplete(() =>
         LeanTween.delayedCall(1, () =>
           LeanTween.value(0, 1, duration).setOnUpdate((float val) => failText.alpha = val).setOnComplete(() =>
            LeanTween.delayedCall(6, () =>
            {
                PlayerDataControl.instance.NewRec();
                GameFade.instance.FadeOut(1f);
                LeanTween.delayedCall(1.2f, () =>
                 SceneManager.LoadScene("Menu"));
            }))));
    }
}

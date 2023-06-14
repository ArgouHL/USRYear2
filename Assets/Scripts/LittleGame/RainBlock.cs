using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainBlock : MonoBehaviour
{

    public static RainBlock instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }


    [SerializeField] private CanvasGroup rain,rainBG;
    [SerializeField] private Image rainImg;
    [SerializeField] private Sprite[] rainSprites;
    private int imgIndex = 0;

    [SerializeField] private float fadeTime, holdTime;
    private Coroutine raincoro;


    [SerializeField] private RainData[] rainDatas;
    private RainData currentRainData;
    private float rainTime;

    private void Start()
    {
        int index = StageControl.currentMonth <= rainDatas.Length ? StageControl.currentMonth : rainDatas.Length;
        currentRainData = rainDatas[index - 1];
        rainTime = (float)currentRainData.rainTime[StageControl.currentWeek - 1]/60f*StageControl.instance.gameTime;
       


    }


    public void StartToWaitRain()
    {
        if (rainTime <= 0)
            return;
        float _time = StageControl.instance.gameTime;
        if (StageControl.instance.currentStaff.Type == StaffType.lessRain)
            _time *= 0.8f;
        if (StageControl.instance.currentStaff.Type == StaffType.longerTime)
            _time += 5;
        LeanTween.delayedCall(_time - rainTime, ()=>StartRain(rainTime));
    }
   


    private void StartRain(float duration)
    {
        SfxControl.instance.StartRain();
        if (raincoro != null)
            return;
        raincoro = StartCoroutine(Rainy());
        LeanTween.value(0, 1, 2).setOnUpdate((float val)=>rainBG.alpha=val);
        
    }

    public void StopRain()
    {
        
        SfxControl.instance.StopRain(); ;
      
        raincoro = null;
        
    }



    private IEnumerator Rainy()
    {
        
        while (rainTime > 0)
        {
            
            yield return SingleRain();
        }
        raincoro = null;
       
    }



    private IEnumerator SingleRain()
    {
        rainTime -= (fadeTime * 2 + holdTime);
        rainImg.sprite = rainSprites[imgIndex];
        imgIndex = (imgIndex + 1) % rainSprites.Length;
        float timer = 0;
        while (timer < fadeTime)
        {
            rain.alpha = Mathf.Lerp(0, 1, timer / fadeTime);
            timer += Time.deltaTime;
            yield return null;
        }
        rain.alpha = 1;
        yield return new WaitForSeconds(holdTime);
        timer = 0;
        while (timer < fadeTime)
        {
            rain.alpha = Mathf.Lerp(1, 0, timer / fadeTime);
            timer += Time.deltaTime;
            yield return null;
        }
        rain.alpha = 0;
    }







}

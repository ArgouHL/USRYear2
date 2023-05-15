using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public static GameManagement instance;
    private Coroutine GameCoro;
   




    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    





    public void GameStart()
    {
        Debug.Log("GameStart");

    }

    internal void SelectGood(GoodType goodType)
    {
        throw new NotImplementedException();
    }

    public void StartLevel()
    {
        if (GameCoro != null)
        {
            Debug.LogError("current game playing");
            return;
        }
        GameCoro = StartCoroutine(GameIE());
    }

    private IEnumerator GameIE()
    {

        //while (currentTime < gameTime)
        //{
        //    //update clock/time show

        //    currentTime += Time.deltaTime;
        yield return null;
        //}
        ////game stop
        //GameCoro = null;
    }

    public void GameStop()
    {

    }

}

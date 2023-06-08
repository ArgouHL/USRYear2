using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public static GameManagement instance;
    private Coroutine GameCoro;


    private List<QuestionData> easyCustomer = new List<QuestionData>();
    private List<QuestionData> normalCustomer = new List<QuestionData>();
    private List<QuestionData> hardCustomer = new List<QuestionData>();
    private RandomObjs<Difficulty> selector = new RandomObjs<Difficulty>();
    private Question currentCustomer;
    private bool isSelected = true;
    private bool gameEnd = false;
    float time = 0;
    private int custCount = 0;
    [SerializeField] private Transform custPos;


    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        ResetAll();
        GetCustomers(StageControl.instance.week);
        //GameStart();
    }

    private void ResetAll()
    {
        currentCustomer = null;
        selector = new RandomObjs<Difficulty>();
        easyCustomer = new List<QuestionData>();
        normalCustomer = new List<QuestionData>();
        hardCustomer = new List<QuestionData>();

        gameEnd = false;
        time = 0;
    }

    private void GetCustomers(int day)
    {
        var customerList = CustomerCtr.instance.GetTagetCutomers();
        foreach (var cust in customerList)
        {
            if (!StageControl.instance.currentLevel.StageGoods.Contains(cust.goodType))
                return;
            switch (cust.questionDifficuly)
            {
                case Difficulty.easy:
                    easyCustomer.Add(cust);
                    break;
                case Difficulty.normal:
                    normalCustomer.Add(cust);
                    break;
                case Difficulty.hard:
                    hardCustomer.Add(cust);
                    break;
            }
        }

        float _easyQuestionF = StageControl.instance.currentLevel.EasyQuestion.Evaluate(day);
        float _normalQuestionF = StageControl.instance.currentLevel.NormalQuestion.Evaluate(day);
        float _hardQuestionF = StageControl.instance.currentLevel.HardQuestion.Evaluate(day);
        selector.AddItem(Difficulty.easy, _easyQuestionF);
        selector.AddItem(Difficulty.normal, _normalQuestionF);
        selector.AddItem(Difficulty.hard, _hardQuestionF);
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

    internal void SelectGood(GoodType goodType)
    {
        if (isSelected)
            return;
        Debug.Log("ClickedSelectGood" + goodType);
        if (currentCustomer == null)
            return;
        Debug.Log("SelectedGood" + goodType);

        if (goodType == currentCustomer.goodTpye)
        {
            GameUI.instance.AddLog("客人覺得很開心。");
            currentCustomer.Happy();
            //LogHappy
            float index = StageControl.instance.currentStaff.Type == StaffType.earnMore ? 1.2f : 1f;
            ScoreCount.instance.AddMoney((int)(GoodManager.instance.GetPrice(goodType) * index));
            GameUI.instance.AddLog("賣出了" + SelfCodeHelper.GetGoodName(goodType) + "!");
        }
        else
        {
            currentCustomer.Sad();
            GameUI.instance.AddLog("客人覺得不開心。");
        }
        isSelected = true;
    }

    private IEnumerator GameIE()
    {
        StartCoroutine(TimeCount());
        while (!gameEnd)
        {
            yield return NewCustomer();
        }
        //game End
        
        //Show week/day count

    }
    private IEnumerator TimeCount()
    {
        float time = StageControl.instance.gameTime;
        if (StageControl.instance.currentStaff.Type == StaffType.longerTime)
            time += 5f;
        
        while (time >0)
        {
            
            time -= Time.deltaTime;
            GameUI.instance.UpdateGameTime(time);
            yield return null;
        }
    
        gameEnd = true;
        StopCoroutine(GameCoro);
        GameCoro = null;
        GameStop();
    }




    private IEnumerator NewCustomer()
    {

        currentCustomer = new Question(RandomCustomer());
        currentCustomer.GenCustomer(Instantiate(currentCustomer.customerPre, custPos));
       
        //Play Cust Enter Ani
        //Log Cust In


        float playerEnterTime = 1.5f;
        if (StageControl.instance.currentStaff.Type == StaffType.fastCust)
        {
            playerEnterTime = 0.5f;
            currentCustomer.FastIn();
        }

        else
            currentCustomer.Enter();


        
        yield return new WaitForSeconds(playerEnterTime);
        GameUI.instance.AddLog("客人來了");
        QuestionUIControl.instance.ShowQuestion(currentCustomer);
        if(StageControl.instance.currentStaff.Type==StaffType.correcter)
        {
            if(isThirdCust())
            {
                GoodsUI.instance.HideOneWrong(currentCustomer.goodTpye);
            }
            else
                GoodsUI.instance.ShowAll();

        }


        //wait for select

        isSelected = false;
        yield return new WaitUntil(() => isSelected);
        QuestionUIControl.instance.HideQuestion();
        yield return new WaitForSeconds(1);
        currentCustomer.Leave();
        var _customer = currentCustomer;
        LeanTween.delayedCall(1.5f, _customer.Off);
        GameUI.instance.AddLog("客人離開了");
        GameUI.instance.AddLog("");
        yield return new WaitForSeconds(0.5f);
        currentCustomer = null;
        //Play Player Left
    }


    private QuestionData RandomCustomer()
    {
        QuestionData _cust;
        Difficulty _diff = selector.GetRandomItem();
        switch (_diff)
        {
            case Difficulty.easy:
            default:
                _cust = easyCustomer[UnityEngine.Random.Range(0, easyCustomer.Count)];
                break;
            case Difficulty.normal:
                _cust = normalCustomer[UnityEngine.Random.Range(0, normalCustomer.Count)];
                break;
            case Difficulty.hard:
                _cust = hardCustomer[UnityEngine.Random.Range(0, hardCustomer.Count)];
                break;
        }
        return _cust;
    }

    public void GameStop()
    {
        if (StageControl.instance.week <= 3)
        {

            LeanTween.delayedCall(1.5f, () => StageControl.instance.NextWeek());
            GameFade.instance.FadeOut(1);
        }
        else if (StageControl.instance.week == 4)
        {
            LeanTween.delayedCall(1.5f, () =>
            {
                switch (StageControl.instance.currentLevel.level)
                {
                    case Level.easy:
                        PlayerDataControl.instance.playerData.NormalOpenLevel();
                        break;
                    case Level.normal:
                        PlayerDataControl.instance.playerData.HardOpenLevel();
                        break;
                }
                ScoreCount.instance.FinalCount();

            });
        }
        else
            Debug.LogError("WrongWeek");
    }

    private bool isThirdCust()
    {
        var _custCount = custCount;
        custCount = (custCount + 1) % 3;
        return _custCount == 2 ? true : false;
    }
}




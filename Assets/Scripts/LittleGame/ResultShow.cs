using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultShow : MonoBehaviour
{
    public static ResultShow instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    [SerializeField] private CanvasGroup orgMUI, resultUI, winUI, loseUI, earnUI, staffCostUI, levelCostUI, totalUI, winBtns, loseBtns;
    [SerializeField] TMP_Text orgMoney,earn, staffCost, levelCost, total;

    public int CalAndShowResult(int orgmoney,int income,out int netIncome)
    {

        var _income = income;
        var _staffcost = StageControl.instance.TotalStaffCost();
        var _levelcost = StageControl.instance.currentLevel.Cost;
        int net = income - _staffcost - _levelcost;
        netIncome = net;
        StartCoroutine(ResultShowIE(orgmoney,_income, _staffcost, _levelcost, net));
        return net;
    }

    private IEnumerator ResultShowIE(int orgmoney,int income, int staffcost, int levelcost, int net)
    {
        int addPerSecond = 1000;
        resultUI.alpha = 1;
        resultUI.blocksRaycasts = true;
        resultUI.interactable = true;

        orgMUI.alpha = 1;
        int _org = 0;
        while (_org < orgmoney)
        {
            _org += (int)(addPerSecond * Time.deltaTime);
            orgMoney.text = _org.ToString();
            yield return null;
        }
        orgMoney.text = orgmoney.ToString();
        earnUI.alpha = 1;
        int _income = 0;
        while (_income < income)
        {
            _income += (int)(addPerSecond * Time.deltaTime);
            earn.text = _income.ToString();
            yield return null;
        }
        earn.text = income.ToString();
        yield return new WaitForSeconds(1f);
        staffCostUI.alpha = 1;
        int _staffcost = 0;
        while (_staffcost < staffcost)
        {
            _staffcost += (int)(addPerSecond * Time.deltaTime);
            staffCost.text = _staffcost.ToString();
            yield return null;
        }
        staffCost.text = staffcost.ToString();
        yield return new WaitForSeconds(1f);
        levelCostUI.alpha = 1;
        int _levelcost = 0;
        while (_levelcost < levelcost)
        {
            _levelcost += (int)(addPerSecond * Time.deltaTime);
            levelCost.text = _levelcost.ToString();
            yield return null;
        }
        levelCost.text = levelcost.ToString();
        yield return new WaitForSeconds(1f);
        totalUI.alpha = 1;
        int final = orgmoney + net;


        int _final = 0;
        int absfinal = Mathf.Abs(final);
        while (_final < absfinal)
        {
            _final += (int)(addPerSecond * Time.deltaTime);

            total.text = net >= 0 ? _final.ToString() : "-" + _final.ToString();
            yield return null;
        }
        total.text = final >= 0 ? absfinal.ToString() : "-" + absfinal.ToString();


        if (final >= 0)
        {
           
            if (StageControl.currentMonth != 4)
            {
                LeanTween.value(0, 1, 2).setOnUpdate((float val) => winUI.alpha = val).setOnComplete(() =>
                  {
                      winBtns.alpha = 1;
                      winBtns.interactable = true;
                      winBtns.blocksRaycasts = true;
                  });
            }
            else
            {
              FianlShow.instance.Pass();
            }
        }

        else
            LeanTween.value(0, 1, 2).setOnUpdate((float val) => loseUI.alpha = val).setOnComplete(() =>
            {

                //loseBtns.alpha = 1;
                //loseBtns.interactable = true;
                //loseBtns.blocksRaycasts = true;
                //PlayerDataControl.instance.NewRec();
                FianlShow.instance.Fail();
            });
    }


    public void NextGame()
    {
        SfxControl.instance.PlayClick();
        GameFade.instance.FadeOut(1f);
        LeanTween.delayedCall(1.2f, () => 
        SceneManager.LoadScene("ContinueMenu"));
    }

    public void BackTitle()
    {
        SfxControl.instance.PlayClick();
        GameFade.instance.FadeOut(1f);
        LeanTween.delayedCall(1.2f, () =>
        SceneManager.LoadScene("Menu"));
    }
}

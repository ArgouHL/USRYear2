using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomerData", menuName = "New Customer")]
public class QuestionData : ScriptableObject
{
    public CustType customerType;

    public GoodType goodType;
    public Difficulty questionDifficuly;

    [Multiline]
    public string[] questions;
 



}

public enum Difficulty { easy, normal, hard }

public class Question 
{

    private Animator ani;
    public GameObject customerPre;
    public GameObject customerObj;
    public GoodType goodTpye;
    public Difficulty questionDifficuly;

    public List<string> questions;
    

    public Question(QuestionData data)
    {
        questions = new List<string>();
        customerPre = CustomerCtr.instance.GetPre(data.customerType);
        goodTpye = data.goodType;
        questionDifficuly = data.questionDifficuly;
        foreach(var q in data.questions)
        {
            questions.Add(q);
        }
       
   

    }

    public void GenCustomer(GameObject _customerObj)
    {
        customerObj = _customerObj;
        ani = customerObj.GetComponent<Animator>();
    }

    public void Off()
    {
        customerObj.SetActive(false);
    }
    public void Enter()
    {
        ani.SetTrigger("WalkIn");
    }
    public void Happy()
    {
        ani.SetTrigger("Happy");
    }
    public void Sad()
    {
        ani.SetTrigger("Sad");
    }
    public void Leave()
    {
        ani.SetTrigger("WalkOut");
    }

    public void Idle()
    {
        ani.SetTrigger("Idle");
    }

    public void FastIn()
    {
        ani.SetTrigger("FastWalkIn");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerCtr : MonoBehaviour
{
    public static CustomerCtr instance;

    [SerializeField] private QuestionData[] allCustomerData;
    [SerializeField]
    private GameObject
        worker,
    lady,
    old,
    hostess,
    bookworm,
    doctor,
    servant,
    housekeeper;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    public GameObject GetPre(CustType custType)
    {
        Debug.Log(custType);
        GameObject _cust;
        switch (custType)
        {
            case CustType.worker:
            default:
                _cust = worker;
                break;
            case CustType.lady:
                _cust = lady;
                break;
            case CustType.old:
                _cust = old;
                break;
            case CustType.hostess:
                _cust = hostess;
                break;
            case CustType.bookworm:
                _cust = bookworm;
                break;
            case CustType.doctor:
                _cust = doctor;
                break;
            case CustType.servant:
                _cust = servant;
                break;
            case CustType.housekeeper:
                _cust = housekeeper;
                break;
        }
        return _cust;
    }

    public List<QuestionData> GetTagetCutomers()
    {
        var CustomerDataList = new List<QuestionData>();
        var goodTypes = StageControl.instance.GetGoodTypes();


        foreach (var Cust in allCustomerData)
        {
            if (goodTypes.Contains(Cust.goodType))
            {
                CustomerDataList.Add(Cust);
            }
        }
        return CustomerDataList;
    }

}

public enum CustType
{
    worker,
    lady,
    old,
    hostess,
    bookworm,
    doctor,
    servant,
    housekeeper
}

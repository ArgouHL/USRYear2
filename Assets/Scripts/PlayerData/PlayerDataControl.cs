using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerDataControl : MonoBehaviour
{
    public static PlayerDataControl instance; 
    public PlayerData playerData;

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

    private void Start()
    {
        LoadPlayer();
    }


    public void NewRec()
    {
        playerData.NewData();
        Save();
        LoadPlayer();
    }

    public bool LoadPlayer()
    {
        var _ac = Load();
        if (_ac == null)
        {
            Debug.LogWarning("No save");
            return false;
        }         
        playerData.Reverse(_ac);
        return true;
    }




    [ContextMenu("Save")]
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/Save.ept", FileMode.Create);
        Account account = new Account(playerData);
        bf.Serialize(stream, account);
        stream.Close();
        Debug.Log("Save Complete"+ Application.dataPath + "/Save.ept");
    }
    [ContextMenu("Load")]
    public Account Load()
    {
        if (File.Exists(Application.persistentDataPath + "/Save.ept"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/Save.ept", FileMode.Open);
            Account account = bf.Deserialize(stream) as Account;
            stream.Close();
            Debug.Log("Load");
            return account;
        }
        else
        {           
            return null;
        }
    }


}

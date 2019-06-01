using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class SaveLoadManager: MonoBehaviour {

   

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void SavePlayer(UI_Holder player) {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Create)  ;

        PlayerData data = new PlayerData(player);

        bf.Serialize(stream, data);
        stream.Close();

    }

    public static void LoadPlayer(UI_Holder main)
    {
        if (File.Exists(Application.persistentDataPath + "/player.sav"))
        {
           
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Open);

            PlayerData data = bf.Deserialize(stream) as PlayerData;
            
            main.isSetupComplete = data.SetupComplete;
            main.SlotNumber = data.SlotNumber;
            main.Username = data.Username;
            main.SpawnChildrenScroll(data.ChildNumber-1);
            for (int i = 0; i < data.ChildNumber; i++)
            {
              
                main.Children[i].GetComponent<ChildScrollContainer>().ChildName = data.ChildNames[i];
              main.Children[i].GetComponent<ChildScrollContainer>().ChildPoints = data.ChildrenPoints[i];
                main.Children[i].GetComponent<ChildScrollContainer>().ChildSelector.GetComponent<ChildSelectorContainer>().setInternalVars(data.ChildNames[i]);

            }
            
            main.createTask(true, data.TaskNumber);
            for (int i = 0; i < data.TaskNumber; i++)
            {
                var t = main.Tasks[i].GetComponent<ChildScrollContainer>();
                // ChildrenPoints[i] = player.Children[i].GetComponent<ChildScrollContainer>().ChildPoints;
                t.Task_SetVars(true,data.TaskPoints[i],data.TaskDescription[i]);


            }
            
            main.createReward(true, data.RewardNumber);

            for (int i = 0; i < data.RewardNumber; i++)
            {
                var t = main.Rewards[i].GetComponent<ChildScrollContainer>();
             
                t.Reward_SetVars(true, data.RewardPoints[i], data.RewardDescription[i]);


            }
            
            stream.Close();
            
            
        }else
        {
            Debug.LogError("File does not exist.");
            //return new int[1];
        }
    }

}

[Serializable]
public class PlayerData
{
    public int SlotNumber;
    public bool SetupComplete;
    public string Username;
    public int ChildNumber;
    public int[] ChildrenPoints;
    public string[] ChildNames;
    public int TaskNumber;
    public int RewardNumber;
    public int[] TaskPoints;
    public string[] TaskDescription;
    public int[] RewardPoints;
    public string[] RewardDescription;

  


    public PlayerData(UI_Holder player)
    {
        //Here you add the vars to save
        
        SetupComplete = player.isSetupComplete;
        SlotNumber = player.SlotNumber;
        Username = player.Username;
        ChildNumber = player.Children.Count ;
        TaskNumber = player.Tasks.Count ;
        RewardNumber = player.Rewards.Count ;
        ChildNames = new string[ChildNumber];
        ChildrenPoints = new int[ChildNumber];
        TaskPoints = new int[TaskNumber];
        TaskDescription = new string[TaskNumber];
        RewardPoints = new int[RewardNumber];
        RewardDescription = new string[RewardNumber];
        for( int i=0; i < ChildNumber; i++)
        {
           ChildrenPoints[i] = player.Children[i].GetComponent<ChildScrollContainer>().ChildPoints;
            ChildNames[i] = player.Children[i].GetComponent<ChildScrollContainer>().ChildName;
            
        }
        for (int i = 0; i < TaskNumber; i++)
        {
            TaskPoints[i] = player.Tasks[i].GetComponent<ChildScrollContainer>().ChildPoints;
            TaskDescription[i] = player.Tasks[i].GetComponent<ChildScrollContainer>().ChildName;

        }

        for (int i = 0; i < RewardNumber; i++)
        {
            RewardPoints[i] = player.Rewards[i].GetComponent<ChildScrollContainer>().ChildPoints;
            RewardDescription[i] = player.Rewards[i].GetComponent<ChildScrollContainer>().ChildName;

        }
        //Children = player.Children;
    }
}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ui_deletetask : MonoBehaviour {

    public GameObject ui_Holder;

	// Use this for initialization
	void Start () {
        Transform tyesBtn = this.transform.Find("yesbtn");
        Button yesBtn = tyesBtn.GetComponent<Button>();
        yesBtn.GetComponent<Button>().onClick.AddListener(btn_Yes);
        Transform tnoBtn = this.transform.Find("nobtn");
        Button noBtn = tnoBtn.GetComponent<Button>();
        noBtn.GetComponent<Button>().onClick.AddListener(btn_No);
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    //Add THere are no Tasks Text here.  Add con
    public void btn_Yes()
    {
        Debug.Log("Yes");
        var ui_par = ui_Holder.GetComponent<UI_Holder>();
        
        for (int i = 0; i < ui_Holder.GetComponent<UI_Holder>().Tasks.Count; i++) {
            Debug.Log(ui_Holder.GetComponent<UI_Holder>().current_TaskReward);
         if(ui_Holder.GetComponent<UI_Holder>().Tasks[i] == ui_Holder.GetComponent<UI_Holder>().current_TaskReward)
            {

                //enabled doesnt work, get component doesnt work
                // ui_Holder.GetComponent<UI_Holder>().Tasks[i].GetComponent<Button>().enabled 

                Destroy(ui_Holder.GetComponent<UI_Holder>().current_TaskReward.gameObject);
                ui_Holder.GetComponent<UI_Holder>().Tasks.RemoveAt(i);
               
                break;
            }
                }
        ui_par.con_DeleteTask.SetActive(false);
        ui_par.con_TaskHolder.SetActive(true);
        ui_Holder.GetComponent<UI_Holder>().con_HUD_newtask.SetActive(true);
        if (ui_par.Tasks.Count == 0)
        {
            ui_par.con_Str_NoTasks.SetActive(true);
            ui_Holder.GetComponent<UI_Holder>().con_Str_NoTasks.GetComponent<Text>().text = ui_par.getLanguage(62);
        }else
        {
            ui_par.con_Str_NoTasks.SetActive(false);
        }
    }

    public void btn_No()
    {
        var ui_par = ui_Holder.GetComponent<UI_Holder>();
        ui_Holder.GetComponent<UI_Holder>().con_DeleteTask.SetActive(false);
        ui_Holder.GetComponent<UI_Holder>().con_TaskHolder.SetActive(false);
        ui_Holder.GetComponent<UI_Holder>().con_DeleteTask.SetActive(false);
        ui_Holder.GetComponent<UI_Holder>().con_TaskHolder.SetActive(true);
        ui_Holder.GetComponent<UI_Holder>().con_HUD_newtask.SetActive(true);

        if (ui_Holder.GetComponent<UI_Holder>().Tasks.Count == 0)
        {
            ui_par.con_Str_NoTasks.SetActive(true);
            ui_Holder.GetComponent<UI_Holder>().con_Str_NoTasks.GetComponent<Text>().text = ui_Holder.GetComponent<UI_Holder>().getLanguage(62);
        }else
        {
            ui_par.con_Str_NoTasks.SetActive(false);
        }

    }
}

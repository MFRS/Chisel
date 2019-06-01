using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChildScrollContainer : MonoBehaviour {

    public string ChildName;
    public int ChildPoints;
    public int ChildID;
    public Button ChildSelector;
    public GameObject OnRewardsCompletion;
    public GameObject UI_Holder;
    public bool isPlus;
    public bool isTask;
    public bool isReward;

    
    

	// Use this for initialization
	void Start () {
        //Debug.Log(UI_Holder);
        this.GetComponent<Button>().onClick.AddListener(TaskClick);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TaskClick()
    {
        if (isTask)
        {
            this.UI_Holder.GetComponent<UI_Holder>().con_TaskHolder.SetActive(false);
            this.UI_Holder.GetComponent<UI_Holder>().con_HUD_newtask.SetActive(false);
            this.UI_Holder.GetComponent<UI_Holder>().current_TaskReward = this.gameObject.GetComponent<Button>() ;
            for (int i=0;i < this.UI_Holder.GetComponent<UI_Holder>().Children.Count; i++)
            {
                if (this.UI_Holder.GetComponent<UI_Holder>().Children[i].GetComponent<ChildScrollContainer>().ChildSelector.GetComponent<ChildSelectorContainer>().Pressed == true)
                {
                    this.UI_Holder.GetComponent<UI_Holder>().Children[i].GetComponent<ChildScrollContainer>().ChildSelector.GetComponent<ChildSelectorContainer>().Btn_Pressed();

                }
                else
                {
                    this.UI_Holder.GetComponent<UI_Holder>().Children[i].GetComponent<ChildScrollContainer>().ChildSelector.GetComponent<ChildSelectorContainer>().setInitialColor();
                }
            }

            this.UI_Holder.GetComponent<UI_Holder>().con_children_selector.SetActive(true);
            this.UI_Holder.GetComponent<UI_Holder>().str_Child_Selector_header.text = this.UI_Holder.GetComponent<UI_Holder>().getLanguage(46);
            this.UI_Holder.GetComponent<UI_Holder>().BtnText.text = this.UI_Holder.GetComponent<UI_Holder>().getLanguage(67) ;
            this.UI_Holder.GetComponent<UI_Holder>().con_Btn.SetActive(true);
            this.UI_Holder.GetComponent<UI_Holder>().ui_tasks3 = true;
        }

        if (isReward)
        {
            
            var Parent = UI_Holder.GetComponent<UI_Holder>();

            this.UI_Holder.GetComponent<UI_Holder>().con_RewardHolder.SetActive(false);
            this.UI_Holder.GetComponent<UI_Holder>().con_HUD_newtask.SetActive(false);
            this.UI_Holder.GetComponent<UI_Holder>().current_TaskReward = this.gameObject.GetComponent<Button>();
            this.UI_Holder.GetComponent<UI_Holder>().con_RewardCompletion.SetActive(true);
            this.UI_Holder.GetComponent<UI_Holder>().str_ReComp_description.text = this.UI_Holder.GetComponent<UI_Holder>().getLanguage(41);
            this.UI_Holder.GetComponent<UI_Holder>().con_Btn.SetActive(true);
            this.UI_Holder.GetComponent<UI_Holder>().Result = this.UI_Holder.GetComponent<UI_Holder>().current_TaskReward.GetComponent<ChildScrollContainer>().ChildPoints;
            this.UI_Holder.GetComponent<UI_Holder>().BtnText.text = this.UI_Holder.GetComponent<UI_Holder>().getLanguage(99) + " : " + this.UI_Holder.GetComponent<UI_Holder>().Result;
            this.UI_Holder.GetComponent<UI_Holder>().ui_rewards1 = false;
            this.UI_Holder.GetComponent<UI_Holder>().ui_rewards2 = true;

            for (int i = 0; i < Parent.Children.Count; i++)
            {
                var ParentCompletion = this.UI_Holder.GetComponent<UI_Holder>().Children[i].GetComponent<ChildScrollContainer>().OnRewardsCompletion.GetComponent<OnRewardsChildCompletion>();
                ParentCompletion.setInternalVars(this.UI_Holder.GetComponent<UI_Holder>().Children[i].GetComponent<ChildScrollContainer>().ChildPoints, false, "a");
            }

            for (int i = 0; i < UI_Holder.GetComponent<UI_Holder>().Children.Count; i++)
            {
                var ParentCompletion = this.UI_Holder.GetComponent<UI_Holder>().Children[i].GetComponent<ChildScrollContainer>().OnRewardsCompletion.GetComponent<OnRewardsChildCompletion>();
               Transform IF = ParentCompletion.transform.Find("InputField");
                string Iff = IF.GetComponent<InputField>().text.ToString();
                Iff = "";
                ParentCompletion.CurrentNumber = 0;
                ParentCompletion.PointsTaken = 0;


            }
        }

    }

  


    public void SetInternalVars(bool loaded)
    {
        if (loaded)
        {
            var AccessUIHolder = UI_Holder.GetComponent<UI_Holder>();
            Transform tstrName = this.transform.Find("strName");
            Text strName = tstrName.GetComponent<Text>();
            strName.text = AccessUIHolder.getLanguage(68);
            Transform tstrPoints = this.transform.Find("StrPoints");
            Text strPoints = tstrPoints.GetComponent<Text>();
            strPoints.text = AccessUIHolder.getLanguage(25);
            Transform tinputPoints = this.transform.Find("Points");
            Text inputPoints = tinputPoints.GetComponent<Text>();
            inputPoints.text = this.ChildPoints.ToString();


            Transform tinputName = this.transform.Find("Name");
            Text inputName = tinputName.GetComponent<Text>();
            inputName.text = this.ChildName;

            this.ChildSelector.GetComponent<ChildSelectorContainer>().GetComponentInChildren<Text>().text = this.ChildName;
            this.OnRewardsCompletion.GetComponent<OnRewardsChildCompletion>().setInternalVars(this.ChildPoints, true, this.ChildName);
        }
        else
        {
            var AccessUIHolder = UI_Holder.GetComponent<UI_Holder>();
            Transform tstrName = this.transform.Find("strName");
            Text strName = tstrName.GetComponent<Text>();
            strName.text = AccessUIHolder.getLanguage(68);
            Transform tstrPoints = this.transform.Find("StrPoints");
            Text strPoints = tstrPoints.GetComponent<Text>();
            strPoints.text = AccessUIHolder.getLanguage(25);
            Transform tinputPoints = this.transform.Find("Points");
            Text inputPoints = tinputPoints.GetComponent<Text>();
            inputPoints.text = this.ChildPoints.ToString();


            Transform tinputName = this.transform.Find("Name");
            Text inputName = tinputName.GetComponent<Text>();
            inputName.text = this.ChildName;
           
            //this.OnRewardsCompletion.GetComponent
        }
    }

    public void Task_SetVars(bool Loaded, int Points, string desc)
    {
        if (Loaded)
        {
            var AccessUIHolder = UI_Holder.GetComponent<UI_Holder>();
            Transform tstrName = this.transform.Find("strName");
            Text strName = tstrName.GetComponent<Text>();
            strName.text = AccessUIHolder.getLanguage(80);
            Transform tstrPoints = this.transform.Find("StrPoints");
            Text strPoints = tstrPoints.GetComponent<Text>();
            strPoints.text = AccessUIHolder.getLanguage(45);
            Transform tinputPoints = this.transform.Find("Points");
            Text inputPoints = tinputPoints.GetComponent<Text>();
            inputPoints.text = Points.ToString();


            Transform tinputName = this.transform.Find("Name");
            Text inputName = tinputName.GetComponent<Text>();
            inputName.text = desc;
        }
        else
        {
            var AccessUIHolder = UI_Holder.GetComponent<UI_Holder>();
            Transform tstrName = this.transform.Find("strName");
            Text strName = tstrName.GetComponent<Text>();
            strName.text = AccessUIHolder.getLanguage(80);
            Transform tstrPoints = this.transform.Find("StrPoints");
            Text strPoints = tstrPoints.GetComponent<Text>();
            strPoints.text = AccessUIHolder.getLanguage(45);
            Transform tinputPoints = this.transform.Find("Points");
            Text inputPoints = tinputPoints.GetComponent<Text>();
            inputPoints.text = this.ChildPoints.ToString();


            Transform tinputName = this.transform.Find("Name");
            Text inputName = tinputName.GetComponent<Text>();
            inputName.text = this.ChildName;
        }
        

    }

      public void Reward_SetVars(bool loaded, int Points, string Desc)
    {
        if (loaded)
        {
            var AccessUIHolder = UI_Holder.GetComponent<UI_Holder>();
            Transform tstrName = this.transform.Find("strName");
            Text strName = tstrName.GetComponent<Text>();
            strName.text = AccessUIHolder.getLanguage(80);
            Transform tstrPoints = this.transform.Find("StrPoints");
            Text strPoints = tstrPoints.GetComponent<Text>();
            strPoints.text = AccessUIHolder.getLanguage(45);
            Transform tinputPoints = this.transform.Find("Points");
            Text inputPoints = tinputPoints.GetComponent<Text>();
            inputPoints.text = Points.ToString();


            Transform tinputName = this.transform.Find("Name");
            Text inputName = tinputName.GetComponent<Text>();
            inputName.text = Desc;
        }else
        {
            var AccessUIHolder = UI_Holder.GetComponent<UI_Holder>();
            Transform tstrName = this.transform.Find("strName");
            Text strName = tstrName.GetComponent<Text>();
            strName.text = AccessUIHolder.getLanguage(80);
            Transform tstrPoints = this.transform.Find("StrPoints");
            Text strPoints = tstrPoints.GetComponent<Text>();
            strPoints.text = AccessUIHolder.getLanguage(45);
            Transform tinputPoints = this.transform.Find("Points");
            Text inputPoints = tinputPoints.GetComponent<Text>();
            inputPoints.text = this.ChildPoints.ToString();


            Transform tinputName = this.transform.Find("Name");
            Text inputName = tinputName.GetComponent<Text>();
            inputName.text = this.ChildName;
        }
    }

    

    public void CalculateEarnings(int DT_Points)
    {
        //Debug.Log("Calculating");
       
            if (isPlus)
            {
                this.ChildPoints = this.ChildPoints + DT_Points;
                Transform tinputPoints = this.transform.Find("Points");
                Text inputPoints = tinputPoints.GetComponent<Text>();
                inputPoints.text = this.ChildPoints.ToString();
            }else
            {
                this.ChildPoints = this.ChildPoints - DT_Points;
                Transform tinputPoints = this.transform.Find("Points");
                Text inputPoints = tinputPoints.GetComponent<Text>();
                inputPoints.text = this.ChildPoints.ToString();
            }
        

        
    }

    public void CalculateTaskEarnings(int DT_Points)
    {
        //Debug.Log("Calculating");

        if (isPlus)
        {
            this.ChildPoints = this.ChildPoints + DT_Points;
            Transform tinputPoints = this.transform.Find("Points");
            Text inputPoints = tinputPoints.GetComponent<Text>();
            inputPoints.text = this.ChildPoints.ToString();
        }
       


    }


    public void CalculateRewardEarnings(int DT_Points)
    {
        //Debug.Log("Calculating");

        if (isPlus)
        {
            this.ChildPoints = this.ChildPoints - DT_Points;
            Transform tinputPoints = this.transform.Find("Points");
            Text inputPoints = tinputPoints.GetComponent<Text>();
            inputPoints.text = this.ChildPoints.ToString();
        }
        



    }


}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnRewardsChildCompletion : MonoBehaviour
{

    public Text str_ChildName;
    public Text str_Points;
    public Text PlaceHolderText;
    public int ChildID;
    public int PointsTaken;
    public int CurrentNumber;
    public GameObject UI_Holder;
    public bool RewardCalculate;

   
    

    // Use this for initialization
    void Start()
    {
        setInternalVars(20, false, "a");
      /*  Transform tInput = this.transform.Find("ChildName");
        Text inputPoints = tInput.GetComponent<InputField>().text;
        inputPoints = int.ParseChildPoints.ToString();*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TextCommited()
    {
        var Parent = UI_Holder.GetComponent<UI_Holder>();
        var tt = UI_Holder.GetComponent<UI_Holder>().getLanguage(99) + " : ";
        Transform tInput = this.transform.Find("InputField");
        string strcurrentint = tInput.GetComponent<InputField>().text;
        Debug.Log(this.PointsTaken);
        int outputNumber;
        bool isNumber = int.TryParse(strcurrentint, out outputNumber);
       // Debug.Log(UI_Holder.GetComponent<UI_Holder>().Children[this.ChildID].GetComponent<ChildScrollContainer>().ChildPoints);
        if (isNumber && outputNumber > -1 && outputNumber <= UI_Holder.GetComponent<UI_Holder>().Children[this.ChildID].GetComponent<ChildScrollContainer>().ChildPoints)
        {
            if (outputNumber == 0)
            {
                UI_Holder.GetComponent<UI_Holder>().Result = UI_Holder.GetComponent<UI_Holder>().Result + this.PointsTaken;
               Parent.BtnText.text = tt + Parent.Result.ToString();
                this.PointsTaken = int.Parse(strcurrentint);

            }else
            {
                this.CurrentNumber = outputNumber;
                if(this.CurrentNumber <= this.PointsTaken)
                {
                    Parent.Result = Parent.Result + (this.PointsTaken -this.CurrentNumber);
                    Parent.BtnText.text = tt + Parent.Result.ToString();
                    this.PointsTaken = outputNumber;
                    this.CurrentNumber = 0;
                }else
                {
                    Parent.Result = Parent.Result - (this.CurrentNumber - this.PointsTaken);
                    Parent.BtnText.text = tt + Parent.Result.ToString();
                    


                    if(Parent.Result <= 0)
                    {
                        if(Parent.Result < 0)
                        {
                            this.PointsTaken = this.CurrentNumber - (Parent.Result * -1);
                           for (int i= 0; i<Parent.Children.Count; i++)
                            {
                                this.RewardCalculate = true; 
                                
                            }
                            this.CurrentNumber = 0;
                            Parent.BtnText.text = Parent.getLanguage(44);
                            Parent.Result = 0;
                        }else
                        {
                            this.PointsTaken = this.CurrentNumber;
                            for (int i = 0; i < Parent.Children.Count; i++)
                            {
                                this.RewardCalculate = true;

                            }
                            this.CurrentNumber = 0;
                            Parent.BtnText.text = Parent.getLanguage(44);
                            Parent.Result = 0;
                        }

                    }else
                    {
                        this.PointsTaken = this.CurrentNumber;
                        this.CurrentNumber = 0;
                        for (int i = 0; i < Parent.Children.Count; i++)
                        {
                            this.RewardCalculate = false;
                       
                           

                        }
                    }
                }


            }
        }
        else
        {
           tInput.GetComponent<InputField>().text = "";
        }

    }

    public void setInternalVars(int ParentPoints, bool loaded, string desc)
    {
        if (loaded)
        {
            Transform tName = this.transform.Find("Points");
            Text SName = tName.GetComponent<Text>();
            SName.text = ParentPoints.ToString();
            Transform tCn = this.transform.Find("Name");
            Text ttCN = tCn.GetComponent<Text>();
            ttCN.text = desc;
        }else
        {
            Transform tName = this.transform.Find("Points");
            Text SName = tName.GetComponent<Text>();
            SName.text = UI_Holder.GetComponent<UI_Holder>().getLanguage(25) + " : " + UI_Holder.GetComponent<UI_Holder>().Children[this.ChildID].GetComponent<ChildScrollContainer>().ChildPoints;
            Transform tCn = this.transform.Find("Name");
            Text ttCN = tCn.GetComponent<Text>();
            ttCN.text = UI_Holder.GetComponent<UI_Holder>().Children[ChildID].GetComponent<ChildScrollContainer>().ChildName;
        }


    }
  

}

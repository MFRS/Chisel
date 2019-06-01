using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChildSelectorContainer : MonoBehaviour
{

    public GameObject Parent;
    public bool Pressed;
    public int SelfId;
    //public Color Wrongcolor;
    //public Button 

    // Use this for initialization
    void Start()
    {

    }

    public void setInitialColor()
    {


        this.GetComponent<Image>().color = Color.red;
        /*ColorBlock ColBtn = selfBtn.colors;
        ColBtn.normalColor = Color.green;*/
    }

    public void Btn_Pressed()
    {
        this.Pressed = !this.Pressed;
        Debug.Log(Pressed);
        if (Pressed)
        {
            this.GetComponent<Image>().color = Color.green;
        }
        else
        {
            this.GetComponent<Image>().color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setInternalVars(string Name)
    {
        Transform tstrName = this.transform.Find("Text");
        Text strName = tstrName.GetComponent<Text>();
        strName.text = Name;
    }

}

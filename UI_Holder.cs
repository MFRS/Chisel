using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using ChartboostSDK;
using UnityEngine.Advertisements;
//using System.IO;
using UnityEngine.UI;

//CURRENTLY THE ISSUE LIES IN Hide notasks when adding new task
//Check Points, its giving way too much

public class UI_Holder : MonoBehaviour
{
    //VARS
    #region

    [Header("UI_Bools")]
    public bool ui_opscreen;
    public bool ui_questions;
    public bool ui_MainMenu;
    public bool ui_tasks;
    public bool ui_rewards;
    public bool ui_scroll;
    public bool ui_rewardcompletion;
    public bool ui_dinnertime;
    public bool ui_dinnertime2;
    public bool ui_dinnertime3;
    public bool ui_tutorial;
    public bool ui_children;
    public bool ui_moreslots;


    [Header("Dinner Time")]
    public Text str_DT_SetTimer;
    public int DT_int_Points;
    public float DT_TimeSet;
    public bool DT_start;
    public GameObject DT_img;
    public float originaly;


    [Header("ChildContainers")]
    public List<Button> Children;
    public Button con_Children_scroll;
    public GameObject con_ConOfChildScroll;
    public Text strName;
    public Text ChildName;
    public Text strPoints;
    public int Points;
    public Text str_child_back;

    [Header("Task/Rewards")]
    public List<Button> Tasks;
    public List<Button> Rewards;
    public List<GameObject> List_RewardsChildren;
    public GameObject con_RewardsChildren;
    public Text str_HUD_create;
    public Text str_HUD_moreSlots;
    public Text str_SlotNumber;
    public bool ui_tasks1;
    public bool ui_tasks2;
    public bool ui_tasks3;
    public string str_TaskDesc;
    public int str_TaskCost;
    public Button current_TaskReward;
    public bool ui_tasks4;
    public Text Str_DeleteTask;
    public Text Str_Delete_Yes;
    public Text Str_Delete_No;
    public Text str_Task_back;
    public GameObject con_Str_NoTasks;

    [Header("Rewards")]
    public bool ui_rewards1;
    public bool ui_rewards2;
    public bool ui_rewards3;
    public string str_RewardsDesc;
    public int str_RewardsCost;
    public Text Str_DeleteReward;
    public Text Str_RewardDelete_Yes;
    public Text Str_RewardDelete_No;
    public Text str_Reward_back;
    public GameObject con_Str_NoRewards;
    public GameObject con_ConOfRewards;
    public GameObject con_ConOfRewardsCompletion;
    //public Text str_ReComp_purchase;
    public Text str_ReComp_description;
    public int Result;

    [Header("Scroll")]
    public Text str_scroll_MainMenu;
    public Text str_scroll_Tasks;
    public Text str_scroll_Rewards;
    public Text str_scroll_DinnerTime;
    public Text str_scroll_Children;
    public Text str_scroll_Tutorial;
    public Text str_scroll_back;










     [Header("Child Selector")]
    public Text str_Child_Selector_header;
    

    [Header("Game vars")]
    public int SlotNumber;
    public bool isSetupComplete;
    public string Username;
    public int ChildNum;
    public int currentChildInt = 0;
    public string currentChildName;
    public Camera ChiselCamera;
    public int count;


    [Header("UI Containers")]
    public GameObject con_opscreen;
    public GameObject con_settext;
    public GameObject con_settext_insertsection;
    public GameObject con_slots;
    public GameObject con_children_selector;
    public GameObject con_MainMenu;
    public GameObject con_Btn;
    public GameObject con_Tutorial;
    public GameObject con_HUD_newtask;
    public GameObject con_HUD;
    public GameObject con_explain;
    public GameObject con_achievements;
    public GameObject con_Children;
    public GameObject con_SetTimer;
    public GameObject con_ConofChildSelector;
    public GameObject con_DT_Timer;
    public Button Btn_ChildSelector;
    public GameObject con_ChildBackBtn;
    public GameObject con_TaskHolder;
    public GameObject con_ConOfTasks;
    public GameObject con_MoreSLots;
    public GameObject con_DeleteTask;
    public GameObject con_RewardHolder;
    public GameObject con_RewardCompletion;
    public GameObject con_Scroll;





    [Header("Lang Bools")]
    public List<string> LanguageHolder;
    public List<string> EN;
    public List<string> PT;
    public bool isEN;
    public bool isPT;


    [Header("OpScreen")]
    public Text BtnText;
    public Text SetLangText;

    [Header("con_settext")]
    public Text str_SetText_description;
    public Text str_SetText_Inputbox;
    public Text str_SetText_Placeholder;
    public string str_previousText;


    [Header("con_settextBools")]
    public bool isSetText_username;
    public bool isSetText_username2;
    public bool isSetText_childnum2;
    public bool isSetText_childnum;
    public bool isSetText_childnames;
    public bool isSetText_childnames2;
    public bool isText;
    public bool isNumbers;
    public bool iswrongInput;
    


    public InputField Set_Username;

    [Header("MenuButtonsText")]
    public Text str_Tasks;
    public Text str_Rewards;
    public Text str_DinnerTime;
    public Text str_Children;
    public Text str_Achievements;
    public Text str_Tutorial;

    [Header("Tutorial")]
    public Text str_tut_Tasks;
    public Text str_tut_Rewards;
    public Text str_tut_DinnerTime;
    public Text str_tut_Back;
    public GameObject img_Explain;
    public int currentslide;
    public Text str_Explain;
    public GameObject btn_backward;
    public GameObject btn_forward;
    public Text btn_explain_back;
    public bool tut_tasks;
    public bool tut_rewards;
    public bool tut_dinnertime;
    public List<Sprite> img_tutorials;



    [Header("HUDText")]
    public Text str_HUD;
    //public Text str_Rewards;


    #endregion



    //START

    #region
    void Start()
    {
        con_HUD_newtask.SetActive(false);
        originaly = DT_img.transform.localScale.x;
    

        con_opscreen.SetActive(true);
        ui_opscreen = true;
       con_Btn.SetActive(true);
        
        


        // ui_dinnertime = true;
        setArrayStrings();
        isEN = true;
        count = 0;
        Advertisement.Initialize("rewardedVideo", true);
        //StartCoroutine(WaitAd());
        //Btn_getmoreSlots();
        setOPScreenStrings();
        Load();
      
        

        if (isSetupComplete)
        {
          
        }
        else
        {
            SlotNumber = 3;
            str_SlotNumber.text = SlotNumber.ToString();
        }

      
        // Chartboost.cacheRewardedVideo(CBLocation.Default);
    }

    void Update()
    {
        if (DT_start)
        {
            // Debug.Log("Running");
           
            DT_startTimer();
        }
    }
    #endregion


    //Set UI Strings
    #region
    public void setOPScreenStrings()
    {
        BtnText.text = getLanguage(0);
        SetLangText.text = getLanguage(48);
    }

    public void setQuestionStrings()
    {

    }
    //Lang
    //Get Lang
    public string getLanguage(int strNum)
    {
        // string outputStr;
        if (isEN == true)
        {
            LanguageHolder[strNum] = EN[strNum];
            //outputStr = LanguageHolder[strNum]; 
        }

        if (isPT == true)
        {
            LanguageHolder[strNum] = PT[strNum];
            // outputStr = LanguageHolder[strNum];
        }



        return LanguageHolder[strNum];
    }

    public void setENlan()
    {
        // Debug.Log("pressed");
        isEN = true;
        isPT = false;

        if (ui_opscreen == true)
        {
            setOPScreenStrings();
        }
    }

    public void setPTlan()
    {
        //Debug.Log("pressed");
        isPT = true;
        isEN = false;

        if (ui_opscreen == true)
        {
            setOPScreenStrings();
        }
    }

    public void setArrayStrings()
    {


        EN[0] = "Start";
        EN[1] = "Welcome to Chisel!";
        EN[2] = "Lets get set up!";
        EN[3] = "What is your name?";
        EN[4] = "Welcome ";
        EN[5] = "How many children do you have?";
        EN[6] = "What is the name of children number";
        EN[7] = "Great! You're ready to use Chisel!";
        EN[8] = "Enter your name here";
        EN[9] = "Enter the number here";
        EN[10] = "Enter the child's name here";
        EN[11] = "That is not a number. Please enter a number above 0.";
        EN[12] = "Great!";
        EN[13] = "How many points does it reward each children with?";
        EN[14] = "Enter the number here";
        EN[15] = "What do you want them to do?";
        EN[16] = "Enter task";
        EN[17] = "Who do you want to assign the task to?";
        EN[18] = "Please enter a cost for this task. It must be a number above 0.";
        EN[19] = "Create Task";
        EN[20] = "Create a new Task";
        EN[21] = "Create Reward";
        EN[22] = "Create a new Reward";
        EN[23] = "All Children";
        EN[24] = "Name of Child";
        EN[25] = "Points";
        EN[26] = "Level";
        EN[27] = "XP till next level";
        EN[28] = "Tasks";
        EN[29] = "Rewards";
        EN[30] = "Dinner Time";
        EN[31] = "Set your time";
        EN[32] = "Start";
        EN[33] = "Stop";
        EN[34] = "Done";
        EN[35] = "How many points would you like to give away?";
        EN[36] = "Next";
        EN[37] = "What do you want the prize to be?";
        EN[38] = "Enter prize name here";
        EN[39] = "How much do you want it to cost?";
        EN[40] = "Enter cost here";
        EN[41] = "How many points do you want to take from each child?";
        EN[42] = "Enter the points here";
        EN[43] = "Reward purchased!";
        EN[44] = "Purchase Reward";
        EN[45] = "Points Awarded:";
        EN[46] = "Who completed the task so far?";
        EN[47] = "Main Menu";
        EN[48] = "Select the language";
        EN[49] = "Please enter a name.";
        EN[50] = "Please insert a number.";
        EN[51] = "5 min";
        EN[52] = "10 min";
        EN[53] = "15 min";
        EN[54] = "How much XP would you like to give away?";
        EN[55] = "XP";
        EN[56] = "earned";
        EN[57] = "Level up!";
        EN[58] = "Congratulations,";
        EN[59] = "you are now level ";
        EN[60] = "Enter XP here";
        EN[61] = "There are no rewards. Add one!";
        EN[62] = "There are no tasks. Add one!";
        EN[63] = "Please add a description";
        EN[64] = "Task";
        EN[65] = "Cost";
        EN[66] = "Must be completed by:";
        EN[67] = "Update Task";
        EN[68] = "Name";
        EN[69] = "Back";
        EN[70] = "has reached level";
        EN[71] = "Share";
        EN[72] = "Please Select at least one child.";
        EN[73] = "Achievements";
        EN[74] = "You don't have enough slots. Press the + Button on the top right corner to get more!";
        EN[75] = "Like Chisel on facebook!";
        EN[76] = "Create a new Reward!";
        EN[77] = "Create a new Task!";
        EN[78] = "Tell us what you think of the game!";
        EN[79] = "Use Dinner Time!";
        EN[80] = "Description";
        EN[81] = "Hello";
        EN[82] = "Skip tutorial";
        EN[83] = "Play Tutorial";
        EN[84] = "Create a task (uses 1 slot).";
        EN[85] = "In the tasks panel, you can press in your task slots. ";
        EN[86] = "There you can choose who has already finished the task. ";
        EN[87] = "They will get points which will allow them to use for rewards.";
        EN[88] = "Create a reward (uses 1 slot).";
        EN[89] = "In the rewards panel, you can press in your reward slots.";
        EN[90] = "You can choose how many points each child will spend! You are told in real time the remaining amount to buy that reward.";
        EN[91] = "You can choose how long your children have to come to dinner.";
        EN[92] = "You can choose how much points and XP they get if they get to dinner on time! ";
        EN[93] = "When you press start, the bar on the timer will drop. When it's over, you have to choose who got to the table on time!";
        EN[94] = "Help on";
        EN[95] = "Each of the achievements will give you 1 extra slot if you complete them!";
        EN[96] = "In the dropdown menu you can tap in each children's panel. ";
        EN[97] = "They will tell you how many points, which tasks they have assigned to them, and which level they are currently on!";
        EN[98] = "Tutorial";
        EN[99] = "Remaining";
        EN[100] = "Children";
        EN[101] = "Who made it on time?";
        EN[102] = "You must turn wi-fi on!";
        EN[103] = "Do you want to delete this task?";
        EN[104] = "Yes";
        EN[105] = "No";


        PT[0] = "Começar";
        PT[1] = "Bem vindo ao Chisel!";
        PT[2] = "Vamos começar!";
        PT[3] = "Qual é o seu nome?";
        PT[4] = "Bem vinda/o ";
        PT[5] = "Quantos filhos/as você tem?";
        PT[6] = "Qual é o nome do/a filho/a";
        PT[7] = "Excelente! Está tudo pronto para começar!";
        PT[8] = "Escreva o seu nome aqui.";
        PT[9] = "Escreva o número aqui";
        PT[10] = "Escreva o nome do filho/a número";
        PT[11] = "Isso não é um número. Por favor insira um número acima de 0.";
        PT[12] = "Fantástico!";
        PT[13] = "Quantos pontos irá dar a cada filho/a?";
        PT[14] = "Insira o número aqui";
        PT[15] = "O que quer que eles façam?";
        PT[16] = "Insira a tarefa";
        PT[17] = "Quem é que quer que faça esta tarefa?";
        PT[18] = "Por favor insira um custo para esta tarefa. Precisa de ser um número acima de 0.";
        PT[19] = "Criar Tarefa";
        PT[20] = "Criar uma nova tarefa";
        PT[21] = "Criar RecompPTsa";
        PT[22] = "Criar uma nova Recompensa";
        PT[23] = "Todos/as os/as filhos/as";
        PT[24] = "Nome do/a filho/a";
        PT[25] = "Pontos";
        PT[26] = "Nível";
        PT[27] = "XP até o próximo nível";
        PT[28] = "Tarefas";
        PT[29] = "Recompensas";
        PT[30] = "Hora de jantar";
        PT[31] = "Escolha o tempo";
        PT[32] = "Começar";
        PT[33] = "Parar";
        PT[34] = "Terminar";
        PT[35] = "Quantos pontos quer dar de recompensa?";
        PT[36] = "Próximo";
        PT[37] = "O que quer que seja a recompensa?";
        PT[38] = "Insira o prémio aqui";
        PT[39] = "Quanto é que quer que custe?";
        PT[40] = "Insira o custo aqui";
        PT[41] = "Quantos pontos quer retirar de cada filho/a?";
        PT[42] = "Insira os pontos aqui";
        PT[43] = "Recompensa comprada!";
        PT[44] = "Comprar recompensa";
        PT[45] = "Pontos recompensados:";
        PT[46] = "Quem completou a tarefa até agora?";
        PT[47] = "Menu principal";
        PT[48] = "Selecione a língua";
        PT[49] = "Por favor insira um nome";
        PT[50] = "Por favor insira um número";
        PT[51] = "5 min";
        PT[52] = "10 min";
        PT[53] = "15 min";
        PT[54] = "Quanta experiência quer oferecer?";
        PT[55] = "Experiência";
        PT[56] = "ganho";
        PT[57] = "Novo nível!";
        PT[58] = "Parabéns,";
        PT[59] = "alcançaste o nível ";
        PT[60] = "Insira a experiência aqui.";
        PT[61] = "Não há nenhuma recompensa. Adicione uma!";
        PT[62] = "Não há nenhuma tarefa. Adicione uma!";
        PT[63] = "Por favor adicione uma descrição";
        PT[64] = "Tarefa";
        PT[65] = "Custo";
        PT[66] = "Precisa de ser completada por:";
        PT[67] = "Actualizar tarefa";
        PT[68] = "Nome";
        PT[69] = "Voltar atrás";
        PT[70] = "chegou%20ao%20nível%20";
        PT[71] = "Partilhar";
        PT[72] = "Por favor seleccione pelo menos uma criança";
        PT[73] = "Objectivos";
        PT[74] = "Não possui espaços suficientes. Carregue no " + " no canto superior direito para obter mais!";
        PT[75] = "Faça Like no Facebook!";
        PT[76] = "Crie uma nova recompensa!";
        PT[77] = "Crie uma nova tarefa!";
        PT[78] = "Diga-nos o que pensa do jogo!";
        PT[79] = "Use a Hora de Jantar!";
        PT[80] = "Descrição";
        PT[81] = "Olá ";
        PT[82] = "Saltar o tutorial";
        PT[83] = "Ver Tutorial";
        PT[84] = "Crie uma tarefa (custa um espaço).";
        PT[85] = "No painel de tarefas, você pode carregar nas tarefas criadas.";
        PT[86] = "Neste painel poderá escolher quem já completou a tarefa.";
        PT[87] = "As crianças receberão pontos que poderão usar nas recompensas.";
        PT[88] = "Crie uma recompensa (Custa 1 espaço).";
        PT[89] = "No painel de recompensas, você pode carregar na recompensa.";
        PT[90] = "Você pode escolher quantos pontos cada criança gasta! O preço reduz em tempo real conforme a quantidade de pontos que quer que cada criança gaste.";
        PT[91] = "Você pode escolher quanto tempo as suas crianças têm para vir para a mesa.";
        PT[92] = "Pode escolher quantos pontos e experiência eles recebem quando chegam ao jantar a tempo!";
        PT[93] = "Quando você carrega em começar, a barra no temporizador baixa. Quando terminar, tem de escolher quem chegou a tempo!.";
        PT[94] = "Ajuda em ";
        PT[95] = "Cada dos objectivos dá-lhe 1 espaço extra se os completar!";
        PT[96] = "No menu no canto superior direito pode carregar em cada criança.";
        PT[97] = "Neste painel sabe os pontos que a criança tem, que tarefas tem de fazer, e em que nível está!";
        PT[98] = "Tutorial";
        PT[99] = "Faltam";
        PT[100] = "Crianças";
        PT[101] = "Quem chegou a tempo?";
        PT[102] = "Precisa de ligar o acesso à internet para poder obter mais espaços!";
        PT[103] = "Deseja apagar esta tarefa?";
        PT[104] = "Sim";
        PT[105] = "Não";
    }
    #endregion
    

    public void btn_functions()
    {
      

        int cnumquestion = currentChildInt + 1;
        //opscreen
        
      
        if (ui_opscreen == true)
        {
            ui_opscreen = false;
            con_Btn.SetActive(false);
            con_opscreen.SetActive(false);

            if (isSetupComplete == false)
            {
                ui_questions = true;
                isSetText_username = true;
                con_settext_insertsection.SetActive(false);
                con_settext.SetActive(true);
            }
            else
            {
                con_settext.SetActive(false);
                con_MainMenu.SetActive(true);
                str_Tasks.text = getLanguage(28);
                str_Rewards.text = getLanguage(29);
                str_DinnerTime.text = getLanguage(30);
                str_Children.text = getLanguage(100);
                str_Tutorial.text = getLanguage(98);
                // str_Achievements.text = getLanguage(73);
                isSetText_childnames2 = false;
                ui_MainMenu = true;
                con_HUD.SetActive(true);
            }
        }

        if (ui_questions == true)
        {
            if (isSetText_username == true)
            {
                str_SetText_description.text = getLanguage(1);
                StartCoroutine(stringChange());

            }

            if (isSetText_childnum == true)
            {
                //Debug.Log("0Chils");
                con_Btn.SetActive(false);
                isNumbers = true;
                con_settext_insertsection.SetActive(true);
                str_SetText_description.text = getLanguage(5);
                con_settext_insertsection.GetComponent<InputField>().placeholder.GetComponent<Text>().text = getLanguage(9);
            }

            if (isSetText_childnames == true)
            {
                if(currentChildInt < Children.Count) {
                    
                   
                    
                    con_Btn.SetActive(false);
                    isSetText_childnum2 = false;
                    isSetText_childnames = true;
                    isNumbers = false;
                    isText = true;
                    con_settext_insertsection.SetActive(true);
                    str_SetText_description.text = getLanguage(6) + " " + cnumquestion + " ?";
                   

                }
                else
                {
                    con_Btn.SetActive(false);
                    isSetText_childnames = false;
                    isSetText_childnames2 = true;
                    isSetupComplete = true;
                    str_SetText_description.text = getLanguage(7);
                    StartCoroutine(stringChange());

                }
                

                // con_settext_insertsection.GetComponent<InputField>().placeholder.GetComponent<Text>().text = getLanguage(10);
            }

            if (isSetText_childnum2 == true)
            {

                con_Btn.SetActive(false);
                isSetText_childnum2 = false;
                isSetText_childnames = true;
                isNumbers = false;
                isText = true;
                con_settext_insertsection.SetActive(true);
                str_SetText_description.text = getLanguage(6) + " " + cnumquestion + " ?";
                con_settext_insertsection.GetComponent<InputField>().placeholder.GetComponent<Text>().text = getLanguage(10);
            }

         


        }

        if (ui_dinnertime2 == true)
        {
            con_children_selector.SetActive(false);
            

            con_Children.SetActive(true);
            con_ChildBackBtn.SetActive(false);



             for (int i = 0; i < Children.Count; i++)
             {
                 Children[i].GetComponent<ChildScrollContainer>().SetInternalVars(false);
                

             }


            for (int i = 0; i < Children.Count; i++)
             {
               

                 if (Children[i].GetComponent<ChildScrollContainer>().ChildSelector.GetComponent<ChildSelectorContainer>().Pressed == true)
                 {
                    Children[i].GetComponent<ChildScrollContainer>().isPlus = true;
                     Children[i].GetComponent<ChildScrollContainer>().CalculateEarnings(DT_int_Points);

                }else
                {
                    Children[i].GetComponent<ChildScrollContainer>().isPlus = false;
                    Children[i].GetComponent<ChildScrollContainer>().CalculateEarnings(DT_int_Points);
                }

                ui_dinnertime2 = false;
                StartCoroutine(stringChange());
                ui_dinnertime3 = true;
               
             }

            con_Btn.SetActive(false);
            Save();
            ShowAd();
        }

        if (ui_dinnertime == true)
        {
            DT_start = !DT_start;

            if (DT_start)
            {
                BtnText.text = getLanguage(33);
            }
            if (DT_start==false)
            {
                BtnText.text = getLanguage(32);
                con_DT_Timer.SetActive(false);
                con_children_selector.SetActive(true);
                con_Btn.SetActive(true);
                ui_dinnertime = false;
                ui_dinnertime2 = true;
                str_Child_Selector_header.text = getLanguage(101);
                BtnText.text = getLanguage(36);

                for (int i = 0; i < Children.Count; i++)
                {


                    if (Children[i].GetComponent<ChildScrollContainer>().ChildSelector.GetComponent<ChildSelectorContainer>().Pressed == true)
                    {
                        Children[i].GetComponent<ChildScrollContainer>().ChildSelector.GetComponent<ChildSelectorContainer>().Btn_Pressed();

                    }else
                    {
                        Children[i].GetComponent<ChildScrollContainer>().ChildSelector.GetComponent<ChildSelectorContainer>().setInitialColor();
                    }
                }
            }

        }
        //Calculates Task Rewards
        if (ui_tasks3)
        {
            

            con_children_selector.SetActive(false);
            con_Btn.SetActive(false);
            con_Children.SetActive(true);
         
            for (int i = 0; i < Children.Count; i++)
            {
                Children[i].GetComponent<ChildScrollContainer>().SetInternalVars(false);
            }

                for (int i = 0; i < Children.Count; i++)
            {


                if (Children[i].GetComponent<ChildScrollContainer>().ChildSelector.GetComponent<ChildSelectorContainer>().Pressed == true)
                {
                    Children[i].GetComponent<ChildScrollContainer>().isPlus = true;
                    Children[i].GetComponent<ChildScrollContainer>().CalculateTaskEarnings(current_TaskReward.GetComponent<ChildScrollContainer>().ChildPoints);
                    
                }
                else
                {
                    
                }

            }
            for (int i = 0; i < Children.Count; i++)
            {
                Children[i].GetComponent<ChildScrollContainer>().isPlus = false;
            }

                ui_tasks3 = false;
            ui_tasks4 = true;
            StartCoroutine(stringChange());
        }
        //ADD PURCHASE REWARD HERE
        if (ui_rewards2 == true)
        {
            if (Result <= 0)
            {
                con_Btn.SetActive(false);
                con_ChildBackBtn.SetActive(false);
                con_RewardCompletion.SetActive(false);
                ui_rewards2 = false;
                con_Children.SetActive(true);
                ui_rewards3 = true;
                for (int i = 0; i < Children.Count; i++)
                {


                    if (Children[i].GetComponent<ChildScrollContainer>().OnRewardsCompletion.GetComponent<OnRewardsChildCompletion>().RewardCalculate == true)
                    {
                        Children[i].GetComponent<ChildScrollContainer>().isPlus = true;
                        Children[i].GetComponent<ChildScrollContainer>().CalculateRewardEarnings(Children[i].GetComponent<ChildScrollContainer>().OnRewardsCompletion.GetComponent<OnRewardsChildCompletion>().PointsTaken);
                        break;
                    }


                   
                }

                for (int i = 0; i < Children.Count; i++)
                {
                    Children[i].GetComponent<ChildScrollContainer>().isPlus = false;
                }
                StartCoroutine(stringChange());
            }
        }
    }

    public void Save()
    {
      
        SaveLoadManager.SavePlayer(this);
    }

    public void Load()
    {
        SaveLoadManager.LoadPlayer(this);
        
         Debug.Log(SlotNumber);
         str_SlotNumber.text = SlotNumber.ToString();
      
    }


    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

    IEnumerator stringChange()
    {
        yield return new WaitForSeconds(1.5f);

        if (isSetText_childnames2 == true)
        {
            con_settext.SetActive(false);
            con_MainMenu.SetActive(true);
            str_Tasks.text = getLanguage(28);
            str_Rewards.text = getLanguage(29);
            str_DinnerTime.text = getLanguage(30);
            str_Children.text = getLanguage(100);
            str_Tutorial.text = getLanguage(98);
            Save();

            
            // str_Achievements.text = getLanguage(73);
            isSetText_childnames2 = false;
            ui_MainMenu = true;
            con_HUD.SetActive(true);
           
        }




        if (isSetText_username2 == true)
        {
            //Please enter a name
            str_SetText_description.text = getLanguage(3);
            con_settext_insertsection.GetComponent<InputField>().placeholder.GetComponent<Text>().text = getLanguage(8);
            con_settext_insertsection.SetActive(true);
            isText = true;

            //StartCoroutine(stringChange());

        }
        if (isSetText_username == true)
        {
            //Debug.Log(getLanguage(2));
            str_SetText_description.text = getLanguage(2);
            isSetText_username = false;
            isSetText_username2 = true;
            StartCoroutine(stringChange());
        }
        //Run so that this is always unset
        if (iswrongInput == true)
        {
            //Debug.Log("nottrue");
            str_SetText_description.text = str_previousText;
            iswrongInput = false;
            con_settext_insertsection.GetComponent<InputField>().text = "";
        }

        if (ui_dinnertime3)
        {
            ui_dinnertime3 = false;
            con_Children.SetActive(false);
            con_MainMenu.SetActive(true);
            ui_MainMenu = true;
        }

        if (ui_rewards1)
        {
            ui_rewards1 = false;
            ui_rewards2 = true;
            isText = false;
            isNumbers = true;

            str_SetText_description.text = getLanguage(39);
            con_settext_insertsection.SetActive(true);
            BtnText.text = getLanguage(44);
            con_settext_insertsection.GetComponent<InputField>().placeholder.GetComponent<Text>().text = getLanguage(9);
        }

        if (ui_tasks1)
        {
            ui_tasks1 = false;
            ui_tasks2 = true;
            isText = false;
            isNumbers = true;
           
            str_SetText_description.text = getLanguage(35);
            con_settext_insertsection.SetActive(true);
            BtnText.text = getLanguage(44);
            con_settext_insertsection.GetComponent<InputField>().placeholder.GetComponent<Text>().text = getLanguage(9);
        }
        //Runs after Giving points in taskcompletion and opens Task Delete
        if (ui_tasks4)
        {
            ui_tasks4 = false;
            con_Children.SetActive(false);
            con_DeleteTask.SetActive(true);
            Str_DeleteTask.text = getLanguage(103);
            Str_Delete_Yes.text = getLanguage(105);
            Str_Delete_No.text = getLanguage(104);
            //add yes no container
        }

        if (ui_rewards3)
        {
            for (int i = 0; i < Rewards.Count; i++)
            {
                if (Rewards[i] == current_TaskReward)
                {
                    Destroy(current_TaskReward.gameObject);
                    Rewards.RemoveAt(i);
                }
            }
            if (Rewards.Count == 0)
            {
                con_Str_NoRewards.SetActive(true);
                con_Str_NoRewards.GetComponent<Text>().text = getLanguage(61);
            }
            else
            {
                con_Str_NoRewards.SetActive(false);
            }
            con_Children.SetActive(false);
            con_RewardHolder.SetActive(true);
            ui_rewards3 = false;
            con_HUD_newtask.SetActive(true);
            
            

        }

        if (ui_moreslots)
        {
            ui_moreslots = false;
            con_MoreSLots.SetActive(false);
            count = 0;
        }

    }
    //Input Box
    public void setTextChanged()
    {
        //I will use this for when Calculating Rewards
    }

    public void setTextCommit()
    {
       

        if (isText == true)
        {
            if (con_settext_insertsection.GetComponent<InputField>().text != "")
            {
                //Set Username
                if (isSetText_username2 == true)
                {
                    Username = con_settext_insertsection.GetComponent<InputField>().text;
                    Debug.Log(Username);
                    isSetText_username2 = false;
                    isSetText_childnum = true;
                    //Great!
                    str_SetText_description.text = getLanguage(4) + Username + " !";
                    con_settext_insertsection.GetComponent<InputField>().text = "";
                    con_settext_insertsection.SetActive(false);
                    BtnText.text = getLanguage(36);
                    con_Btn.SetActive(true);

                    isText = false;
                }

                if (isSetText_childnames == true)
                {

                    
                        
                        //REPLACE LATER FOR CHILD ARRAY
                    currentChildName = con_settext_insertsection.GetComponent<InputField>().text;
                    Children[currentChildInt].GetComponent<ChildScrollContainer>().ChildName = currentChildName;
                    Children[currentChildInt].GetComponent<ChildScrollContainer>().ChildSelector.GetComponent<ChildSelectorContainer>().GetComponentInChildren<Text>().text = currentChildName;
                    Transform currentOnRewardChildComp = Children[currentChildInt].GetComponent<ChildScrollContainer>().OnRewardsCompletion.GetComponent<OnRewardsChildCompletion>().transform.Find("Name");
                    Text strChildName = currentOnRewardChildComp.GetComponent<Text>();
                    strChildName.text = currentChildName;

                    //Great!
                    str_SetText_description.text = getLanguage(12);
                        con_settext_insertsection.GetComponent<InputField>().text = "";
                        con_settext_insertsection.SetActive(false);
                        BtnText.text = getLanguage(36);
                        con_Btn.SetActive(true);
                        currentChildInt += 1;

                    


                }

               

                if (ui_tasks1)
                {
                   
                    str_SetText_description.text = getLanguage(12);
                    con_settext_insertsection.SetActive(false);
                    str_TaskDesc = con_settext_insertsection.GetComponent<InputField>().text;
                    con_settext_insertsection.GetComponent<InputField>().text = "";
                    StartCoroutine(stringChange());

                   
                }

                if (ui_rewards1)
                {

                    str_SetText_description.text = getLanguage(12);
                    con_settext_insertsection.SetActive(false);
                    str_RewardsDesc = con_settext_insertsection.GetComponent<InputField>().text;
                    con_settext_insertsection.GetComponent<InputField>().text = "";
                    StartCoroutine(stringChange());


                }

            }
            else
            {
                Debug.Log("false");
                iswrongInput = true;
                str_previousText = str_SetText_description.text;
                //Debug.Log(str_previousText);
                str_SetText_description.text = getLanguage(49);
                StartCoroutine(stringChange());

            }
        }

        if (isNumbers == true)
        {
            string strcurrentint = con_settext_insertsection.GetComponent<InputField>().text;
            int outputNumber;
            bool isNumber = int.TryParse(strcurrentint, out outputNumber);

            if (isNumber || outputNumber > 0 && outputNumber < 100000)
            {

                if (isSetText_childnum == true)
                {
                    if (outputNumber > 0 && outputNumber < 10)
                    {
                        //NotHere

                        isSetText_childnum = false;
                        isSetText_childnum2 = true;
                        ChildNum = int.Parse(con_settext_insertsection.GetComponent<InputField>().text);
                        ChildNum = ChildNum - 1;
                        SpawnChildrenScroll(ChildNum);
                        
                        con_settext_insertsection.GetComponent<InputField>().text = "";
                        str_SetText_description.text = getLanguage(12);
                        con_settext_insertsection.SetActive(false);
                        con_Btn.SetActive(true);
                        con_settext_insertsection.GetComponent<InputField>().placeholder.GetComponent<Text>().text = getLanguage(50);
                        isNumbers = false;
                        //SET CHILD SLOT CREATION HERE
                       

                    }
                    else
                    {
                        //Debug.Log("false");
                        iswrongInput = true;
                        str_previousText = str_SetText_description.text;
                        str_SetText_description.text = getLanguage(50);
                        StartCoroutine(stringChange());
                    }

                }

                if (ui_dinnertime)
                {
                    DT_int_Points = int.Parse(con_settext_insertsection.GetComponent<InputField>().text);
                    con_settext_insertsection.GetComponent<InputField>().text = "";
                    con_settext.SetActive(false);
                    con_DT_Timer.SetActive(true);
                    con_Btn.SetActive(true);

                }

                if (ui_rewards2)
                {

                    ui_rewards2 = false;
                    isText = false;
                    isNumbers = false;
                    str_RewardsCost = int.Parse(con_settext_insertsection.GetComponent<InputField>().text);
                    con_settext.SetActive(false);
                    con_ChildBackBtn.SetActive(false);
                    con_RewardHolder.SetActive(true);
                    SlotNumber = SlotNumber - 1;
                    if (Rewards.Count == 0)
                    {
                        con_Str_NoRewards.SetActive(false);
                    }
                    str_SlotNumber.text = SlotNumber.ToString();
                    createReward(false, 0);
                    
                    con_settext_insertsection.GetComponent<InputField>().placeholder.GetComponent<Text>().text = getLanguage(9);
                    Save();

                }

                if (ui_tasks2)
                {
                   
                    ui_tasks2 = false;
                    isText = false;
                    isNumbers = false;
                    str_TaskCost = int.Parse(con_settext_insertsection.GetComponent<InputField>().text);
                    con_settext.SetActive(false);
                    con_ChildBackBtn.SetActive(false);
                    con_TaskHolder.SetActive(true);
                    SlotNumber = SlotNumber -1;
                    if (Tasks.Count == 0)
                    {
                        con_Str_NoTasks.SetActive(false);
                    }
                    str_SlotNumber.text = SlotNumber.ToString();
                    createTask(false,0);
                    
                    con_settext_insertsection.GetComponent<InputField>().placeholder.GetComponent<Text>().text = getLanguage(9);
                    Save();

                }

            }
            else
            {
                //Debug.Log("false");
                iswrongInput = true;
                str_previousText = str_SetText_description.text;
                str_SetText_description.text = getLanguage(50);
                StartCoroutine(stringChange());
            }

        }
    }

    //HUD SECTION
    #region
    // Update is called once per frame
    public void Btn_getmoreSlots()
    {
        Advertisement.Initialize("rewardedVideo", true);
        Debug.Log("Clicked");
       /* SlotNumber++;
        str_SlotNumber.text = SlotNumber.ToString();*/
       
         StartCoroutine(WaitAd());




    }



    IEnumerator WaitAd(string zone = "rewardedVideo")
    {
        
        while (!Advertisement.IsReady("rewardedVideo"))
        {
            count++;
            Debug.Log(count);
            if (count == 50)
            {
                
                con_Str_NoTasks.SetActive(true);
                con_Str_NoTasks.GetComponent<Text>().text = getLanguage(102);
                ui_moreslots = true;
                StartCoroutine(stringChange());
            }
            yield return null;
            /*SlotNumber++;
            str_SlotNumber.text = SlotNumber.ToString();*/
        }
        if (Advertisement.IsReady(zone))
        {

            ShowOptions options = new ShowOptions();
            options.resultCallback = AdCallbackhanler;
            if (Advertisement.IsReady(zone))
            {
                Advertisement.Show(zone, options);
            }



        }
    }

   

    void AdCallbackhanler(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Ad Finished. Rewarding player...");
                SlotNumber = SlotNumber+ 2;
                str_SlotNumber.text = SlotNumber.ToString();
                Save();
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad Skipped");
                break;
            case ShowResult.Failed:
                Debug.Log("Ad failed");
              
               
                break;
        }


    }


    public void HUD_Scroll_Tutorial()
    {
        TurnOffCheck();
        con_Scroll.SetActive(false);

        ui_tutorial = true;
        VisibilityCheck();
    }

    public void HUD_Scroll_MainMenu()
    {
        TurnOffCheck();
        con_Scroll.SetActive(false);

        ui_MainMenu = true;
        VisibilityCheck();
    }

    public void HUD_Scroll_Children()
    {
        TurnOffCheck();
        con_Scroll.SetActive(false);

        ui_children = true;
        VisibilityCheck();
    }

    public void HUD_Scroll_Tasks()
    {
        TurnOffCheck();
        con_Scroll.SetActive(false);

        ui_tasks = true;
        VisibilityCheck();
    }

    public void HUD_Scroll_Rewards()
    {
        TurnOffCheck();
        con_Scroll.SetActive(false);

        ui_rewards = true;
        VisibilityCheck();
    }

    public void HUD_Scroll_DinnerTime()
    {
        TurnOffCheck();
        con_Scroll.SetActive(false);
        
        ui_dinnertime = true;
        VisibilityCheck();
    }

    public void TurnOffCheck()
    {
       /* if (ui_tasks)
        {*/
            ui_tasks = false;
            con_TaskHolder.SetActive(false);
            con_settext.SetActive(false);
            con_settext_insertsection.SetActive(false);
            con_children_selector.SetActive(false);
            con_Btn.SetActive(false);

            
        /*}
        if (ui_rewards)
        {*/
            ui_rewards = false;
            con_RewardHolder.SetActive(false);
            con_settext_insertsection.SetActive(false);
            con_settext.SetActive(false);
            con_RewardCompletion.SetActive(false);
            con_Btn.SetActive(false);
      /*  }
        if (ui_dinnertime)
        {*/
            ui_dinnertime = false;
            if (DT_start)
            {
                originaly = 1;
                DT_start = !DT_start;
            }
            con_settext.SetActive(false);
            con_settext_insertsection.SetActive(false);
            con_DT_Timer.SetActive(false);
            con_Btn.SetActive(false);
            con_SetTimer.SetActive(false);
      /*  }
        if (ui_children)
        {*/
            ui_children = false;
            con_Children.SetActive(false);
            con_Btn.SetActive(false);
     /*   }
        if (ui_tutorial)
        {*/
            ui_tutorial = false;
            con_Tutorial.SetActive(false);
            con_explain.SetActive(false);
            con_Btn.SetActive(false);
       /* }
        if (ui_MainMenu)
        {*/
            con_MainMenu.SetActive(false);
       // }
    }

    public void VisibilityCheck()
    {
        con_HUD_newtask.SetActive(false);
        if (ui_tasks)
        {
        
            Btn_Task();


        }
        if (ui_rewards)
        {
            Btn_Reward();
        }
        if (ui_dinnertime)
        {

            DinnerTime();
        }
        if (ui_children)
        {

            btn_Children();
            
        }
        if (ui_tutorial)
        {

            btn_tutorial();
        }

        if (ui_MainMenu)
        {
            con_MainMenu.SetActive(true);
        }
    }

    public void HUD_Scroll_Back()
    {
        con_Scroll.SetActive(false);
    }

    public void HUD_Scroll_Open()
    {
        con_Scroll.SetActive(true);
        str_scroll_MainMenu.text = getLanguage(47);
        str_scroll_Tasks.text = getLanguage(28);
        str_scroll_Rewards.text = getLanguage(29);
        str_scroll_DinnerTime.text = getLanguage(30);
        str_scroll_Children.text = getLanguage(100);
        str_scroll_Tutorial.text = getLanguage(98);
        str_scroll_back.text = getLanguage(69);
}


    #endregion
    //REWARDS SECTION

    #region

    public void Btn_Reward()
    {
        ui_MainMenu = false;
        ui_rewards = true;
        ui_tasks = false;
        con_MainMenu.SetActive(false);
        con_RewardHolder.SetActive(true);
        con_HUD_newtask.SetActive(true);
        str_HUD_create.text = getLanguage(22);
        str_Reward_back.text = getLanguage(69);

        if (Rewards.Count == 0)
        {
            //
            con_Str_NoRewards.SetActive(true);
            con_Str_NoRewards.GetComponent<Text>().text = getLanguage(61);
        }
        else
        {
            con_Str_NoRewards.SetActive(false);
        }
    }

    public void Btn_reward_back()
    {
        con_RewardHolder.SetActive(false);
        con_MainMenu.SetActive(true);
        con_HUD_newtask.SetActive(false);
    }

    

    public void createReward(bool Loaded, int RewardNum)
    {
        if (Loaded)
        {
            Loaded = false;
            for (int i = 0; i < RewardNum; i++)
            {

                //con_Children_scroll.GetComponent<Text>.
                Button NewReward = Instantiate(con_Children_scroll);
                Rewards.Add(NewReward);
                Debug.Log(Rewards[0]);
                int currentReward = Rewards.Count - 1;
                var childVars = Rewards[currentReward].GetComponent<ChildScrollContainer>();
                childVars.ChildPoints = str_RewardsCost;
                childVars.ChildName = str_RewardsDesc;
                childVars.UI_Holder = this.gameObject;
                childVars.isReward = true;
                
                Rewards[currentReward].transform.SetParent(con_ConOfRewards.transform, false);
                childVars.UI_Holder = this.gameObject;
                Children[currentReward].GetComponent<ChildScrollContainer>().ChildID = currentReward;
            }
        }else
        {
            //con_Children_scroll.GetComponent<Text>.
            Button NewReward = Instantiate(con_Children_scroll);
            Rewards.Add(NewReward);
            Debug.Log(Rewards[0]);
            int currentReward = Rewards.Count - 1;
            var childVars = Rewards[currentReward].GetComponent<ChildScrollContainer>();
            childVars.ChildPoints = str_RewardsCost;
            childVars.ChildName = str_RewardsDesc;
            childVars.UI_Holder = this.gameObject;
            childVars.isReward = true;
            childVars.Reward_SetVars(false,0,"s");
            Rewards[currentReward].transform.SetParent(con_ConOfRewards.transform, false);
            childVars.UI_Holder = this.gameObject;
            Children[currentReward].GetComponent<ChildScrollContainer>().ChildID = currentReward;
        }



    }

    #endregion

    //TASK SECTION

    #region

    public void Btn_task_back()
    {
        con_TaskHolder.SetActive(false);
        con_MainMenu.SetActive(true);
        con_HUD_newtask.SetActive(false);
    }

    public void Btn_Task()
    {
        ui_MainMenu = false;
        ui_tasks = true;
        ui_rewards = false;
        con_MainMenu.SetActive(false);
        con_TaskHolder.SetActive(true);
        con_HUD_newtask.SetActive(true);
        str_HUD_create.text = getLanguage(20);
        str_Task_back.text = getLanguage(69);

        if (Tasks.Count == 0)
        {
            //
            con_Str_NoTasks.SetActive(true);
            con_Str_NoTasks.GetComponent<Text>().text = getLanguage(62);
        }
        else
        {
            con_Str_NoTasks.SetActive(false);
        }
    }

    public void Btn_newTaskReward()
    {
        if (SlotNumber == 0)
        {
            con_MoreSLots.SetActive(true);
            str_HUD_moreSlots.text = getLanguage(74);
            StartCoroutine(stringChange());
            ui_moreslots = true;
        }
        else
        {
            if (ui_tasks)
            {
                ui_tasks1 = true;
                con_TaskHolder.SetActive(false);
                con_settext.SetActive(true);
                con_settext_insertsection.SetActive(true);
                con_HUD_newtask.SetActive(false);
                str_SetText_description.text = getLanguage(15);
                con_settext_insertsection.GetComponent<InputField>().text = "";
                con_settext_insertsection.GetComponent<InputField>().placeholder.GetComponent<Text>().text = getLanguage(16);
                isText = true;
                isNumbers = false;
            }
            if (ui_rewards)
            {
                ui_rewards1 = true;
                con_RewardHolder.SetActive(false);
                con_settext.SetActive(true);
                con_settext_insertsection.SetActive(true);
                con_HUD_newtask.SetActive(false);
                str_SetText_description.text = getLanguage(37);
                con_settext_insertsection.GetComponent<InputField>().text = "";
                con_settext_insertsection.GetComponent<InputField>().placeholder.GetComponent<Text>().text = getLanguage(38);
                isText = true;
                isNumbers = false;
            }
        }
    }

    public void createTask(bool loading, int TaskNum)
    {
        

            //con_Children_scroll.GetComponent<Text>.
            


        if (loading)
        {
            loading = false;
            for(int i=0; i< TaskNum; i++)
            {
                Button NewTask = Instantiate(con_Children_scroll);
                Tasks.Add(NewTask);
                int currentTask = Tasks.Count - 1;
                var childVars = Tasks[currentTask].GetComponent<ChildScrollContainer>();
                childVars.ChildPoints = str_TaskCost;
                childVars.ChildName = str_TaskDesc;
                childVars.UI_Holder = this.gameObject;
                childVars.isTask = true;
                childVars.Task_SetVars(false, 0, "s");
                Tasks[currentTask].transform.SetParent(con_ConOfTasks.transform, false);
                childVars.UI_Holder = this.gameObject;
                Children[currentTask].GetComponent<ChildScrollContainer>().ChildID = currentTask;
            }
        }else
        {
            Button NewTask = Instantiate(con_Children_scroll);
            Tasks.Add(NewTask);
            int currentTask = Tasks.Count - 1;
            var childVars = Tasks[currentTask].GetComponent<ChildScrollContainer>();
            childVars.ChildPoints = str_TaskCost;
            childVars.ChildName = str_TaskDesc;
            childVars.UI_Holder = this.gameObject;
            childVars.isTask = true;
            childVars.Task_SetVars(false, 0, "s");
            Tasks[currentTask].transform.SetParent(con_ConOfTasks.transform, false);
            childVars.UI_Holder = this.gameObject;
            Children[currentTask].GetComponent<ChildScrollContainer>().ChildID = currentTask;
        }

        
    }
    #endregion
    //DINNERTIME SECTION
    #region
    public void DinnerTime()
    {
        con_MainMenu.SetActive(false);
        con_SetTimer.SetActive(true);
        ui_MainMenu = false;
        ui_dinnertime = true;
        isNumbers = true;
        str_DT_SetTimer.text = getLanguage(31);


    }

    public void fimins()
    {

        DT_setPoints(0.00005f);
    }

    public void tenmins()
    {
        DT_setPoints(0.000005f);
    }


    public void fifteenmins()
    {
        DT_setPoints(0.000005f);
    }

    public void DT_setPoints(float DT_time)
    {
        con_SetTimer.SetActive(false);
        con_settext.SetActive(true);
        isText = false;
        isNumbers = true;
        con_settext_insertsection.SetActive(true);
        DT_TimeSet = DT_time;
        str_SetText_description.text = getLanguage(35);
        BtnText.text = getLanguage(32);
        con_settext_insertsection.GetComponent<InputField>().placeholder.GetComponent<Text>().text = getLanguage(42);

    }

    public void DT_startTimer()
    {

        //DT_TimeSet = 3000;
        // 0.001 is 25 seconds
        //0.0005 53 seconds
        originaly = originaly - DT_TimeSet;
        //Vector3 original = new Vector3(1,1,1);
        Vector3 end = new Vector3(originaly, 1, 1);
        //Debug.Log(originaly);
        DT_img.transform.localScale = end; //Vector3.Lerp(original,end,1/DT_TimeSet);
        Debug.Log(originaly);
        if (originaly <= 0)
        {
            DT_start = false;
            con_DT_Timer.SetActive(false);
            //con_Btn.SetActive(true);
            BtnText.text = getLanguage(36);
            con_children_selector.SetActive(true);
            str_Child_Selector_header.text = getLanguage(101);

        }

    }

    public void DT_finishTimer()
    {
        con_children_selector.SetActive(true);
        
        str_Child_Selector_header.text = getLanguage(101);
    }

    #endregion
    //CHILDREN SECTION

    #region

    public void btn_Children()
    {
        con_MainMenu.SetActive(false);
        ui_MainMenu = false;
        ui_children = true;
        
        for (int i = 0; i < Children.Count; i++)
        {
            var childVars = Children[i].GetComponent<ChildScrollContainer>();
            childVars.SetInternalVars(false);
        }

        con_Children.SetActive(true);

        con_ChildBackBtn.SetActive(true);
        str_child_back.text = getLanguage(69);
        //SpawnChildrenScroll(10);
    }

    public void btn_Children_back()
    {
        con_Children.SetActive(false);
        con_ChildBackBtn.SetActive(false);
        con_MainMenu.SetActive(true);
    }

    public void btn_Achievements()
    {
        con_MainMenu.SetActive(false);
        con_achievements.SetActive(true);
    }

    //CHILDREN CONT SPAWNERS

    public void SpawnChildrenScroll(int numChild)
    {
        for (int i = 0; i <= numChild; i++)
        {

            //con_Children_scroll.GetComponent<Text>.
            Button spawnedChildScroll = Instantiate(con_Children_scroll);
            Children.Add(spawnedChildScroll);
            var childVars = Children[i].GetComponent<ChildScrollContainer>();
            Children[i].transform.SetParent(con_ConOfChildScroll.transform, false);
            childVars.UI_Holder = this.gameObject;
            Children[i].GetComponent<ChildScrollContainer>().ChildID = i;

            SpawnChildSelectors(i);
            SpawnRewardsCompletion(i);


        }
    }
    //ADD BOOL LOADED TO EACH FUNCTION SO THAT THEY SET THEMSELVES
    public void SpawnRewardsCompletion(int numChild)
    {
       



            //Debug.Log("Spawned");
            //con_Children_scroll.GetComponent<Text>.
            GameObject spawnedRewardScroll = Instantiate(con_RewardsChildren);
            List_RewardsChildren.Add(spawnedRewardScroll);
            Children[numChild].GetComponent<ChildScrollContainer>().OnRewardsCompletion = spawnedRewardScroll;
            var childVars = List_RewardsChildren[numChild].GetComponent<OnRewardsChildCompletion>();
            List_RewardsChildren[numChild].transform.SetParent(con_ConOfRewardsCompletion.transform, false);
            childVars.UI_Holder = this.gameObject;

            List_RewardsChildren[numChild].GetComponent<OnRewardsChildCompletion>().ChildID = numChild;

      

         
        
          


        
    }

    public void SpawnChildSelectors(int i)
    {

       
            

            Button spawnedChildSelector = Instantiate(Btn_ChildSelector);
            Children[i].GetComponent<ChildScrollContainer>().ChildSelector = spawnedChildSelector;

            spawnedChildSelector.transform.SetParent(con_ConofChildSelector.transform, false);
            var ChildF = spawnedChildSelector.GetComponent<ChildSelectorContainer>();
            //ChildF.GetComponent<Text>().text = Child
            ChildF.SelfId = i;

            //var ChildVars =

            ChildF.setInitialColor();
           
      
        
    }


    #endregion
    //TUTORIAL SECTION

    #region

    public void btn_tut_forward()
    {
        if (tut_tasks == true)
        {

            if (currentslide == 3)
            {

            }
            else
            {
                currentslide++;
                btn_backward.SetActive(true);
                checkCurrentDesc();
            }


        }

        if (tut_rewards == true)
        {
            if (currentslide == 2)
            {

            }
            else

            {
                currentslide++;
                btn_backward.SetActive(true);
                checkCurrentDesc();
            }
        }

        if (tut_dinnertime == true)
        {
            if (currentslide == 2)
            {

            }
            else

            {
                currentslide++;
                btn_backward.SetActive(true);
                checkCurrentDesc();
            }
        }
    }

    public void btn_tut_backward()
    {
        if (currentslide == 0)
        {

        }
        else
        {
            currentslide--;
            btn_forward.SetActive(true);
            checkCurrentDesc();
        }




    }

    public void checkCurrentDesc()
    {
        if (tut_tasks == true)
        {
            if (currentslide == 0)
            {
                str_Explain.text = getLanguage(84);
                //img_Explain.GetComponent<Sprite> = ;
                img_Explain.GetComponent<SpriteRenderer>().sprite = img_tutorials[6];
                btn_backward.SetActive(false);

            }
            if (currentslide == 1)
            {
                str_Explain.text = getLanguage(85);
                img_Explain.GetComponent<SpriteRenderer>().sprite = img_tutorials[7];


            }
            if (currentslide == 2)
            {
                str_Explain.text = getLanguage(86);
                img_Explain.GetComponent<SpriteRenderer>().sprite = img_tutorials[8];


            }
            if (currentslide == 3)
            {
                str_Explain.text = getLanguage(87);
                img_Explain.GetComponent<SpriteRenderer>().sprite = img_tutorials[9];
                btn_forward.SetActive(false);

            }
        }

        if (tut_rewards == true)
        {
            if (currentslide == 0)
            {
                str_Explain.text = getLanguage(88);
                //img_Explain.GetComponent<Sprite> = ;
                img_Explain.GetComponent<SpriteRenderer>().sprite = img_tutorials[3];
                btn_backward.SetActive(false);

            }
            if (currentslide == 1)
            {
                str_Explain.text = getLanguage(89);
                img_Explain.GetComponent<SpriteRenderer>().sprite = img_tutorials[4];


            }
            if (currentslide == 2)
            {
                str_Explain.text = getLanguage(90);
                img_Explain.GetComponent<SpriteRenderer>().sprite = img_tutorials[5];
                btn_forward.SetActive(false);

            }

        }

        if (tut_dinnertime == true)
        {
            if (currentslide == 0)
            {
                str_Explain.text = getLanguage(91);
                img_Explain.GetComponent<SpriteRenderer>().sprite = img_tutorials[0];
                btn_backward.SetActive(false);

            }
            if (currentslide == 1)
            {
                str_Explain.text = getLanguage(92);
                img_Explain.GetComponent<SpriteRenderer>().sprite = img_tutorials[1];


            }
            if (currentslide == 2)
            {
                str_Explain.text = getLanguage(93);
                img_Explain.GetComponent<SpriteRenderer>().sprite = img_tutorials[2];
                btn_forward.SetActive(false);

            }

        }
    }


    public void btn_tut_rewards()
    {
        con_Tutorial.SetActive(false);
        con_explain.SetActive(true);
        tut_rewards = true;
        btn_forward.SetActive(true);
        btn_backward.SetActive(false);
        btn_explain_back.text = getLanguage(69);
        str_Explain.text = getLanguage(88);
        img_Explain.GetComponent<SpriteRenderer>().sprite = img_tutorials[3];
    }

    public void btn_tut_tasks()
    {
        con_Tutorial.SetActive(false);
        con_explain.SetActive(true);
        btn_forward.SetActive(true);
        btn_backward.SetActive(false);
        tut_tasks = true;
        btn_explain_back.text = getLanguage(69);
        str_Explain.text = getLanguage(84);
        img_Explain.GetComponent<SpriteRenderer>().sprite = img_tutorials[6];
    }


    public void btn_tut_dinnertime()
    {
        con_Tutorial.SetActive(false);
        con_explain.SetActive(true);
        tut_dinnertime = true;
        btn_forward.SetActive(true);
        btn_backward.SetActive(false);
        btn_explain_back.text = getLanguage(69);
        str_Explain.text = getLanguage(91);
        img_Explain.GetComponent<SpriteRenderer>().sprite = img_tutorials[0];
    }

    public void btn_tut_back()
    {
        con_Tutorial.SetActive(false);
        con_MainMenu.SetActive(true);
    }

    public void btn_Explain_back()
    {
        con_explain.SetActive(false);
        con_Tutorial.SetActive(true);
        currentslide = 0;

        if (tut_tasks == true)
        {
            tut_tasks = false;
        }
        if (tut_rewards == true)
        {
            tut_rewards = false;
        }
        if (tut_dinnertime == true)
        {
            tut_dinnertime = false;
        }
    }

    public void btn_tutorial()
    {
        ui_MainMenu = false;
        ui_tutorial = true;
        con_MainMenu.SetActive(false);
        con_Tutorial.SetActive(true);
        str_tut_Tasks.text = getLanguage(28);
        str_tut_Rewards.text = getLanguage(29);
        str_tut_DinnerTime.text = getLanguage(30);
        str_tut_Back.text = getLanguage(69);
    }


    #endregion


}








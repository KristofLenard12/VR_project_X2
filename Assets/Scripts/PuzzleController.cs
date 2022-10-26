using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleController : MonoBehaviour
{
    public GameObject Drill_Red;
    public GameObject Drill_Yellow;
    public GameObject Drill_Blue;
    public GameObject Pliers;
    public GameObject Saw;
    public GameObject ScrewDriver_1;
    public GameObject ScrewDriver_2;
    public GameObject ScrewDriver_3;
    public GameObject Axe_Brown;
    public GameObject Axe_Red;
    public GameObject Hammer_Brown;
    public GameObject Hammer_Blue;
    public GameObject Hammer_Yellow;
    public GameObject Wrench;

    public GameObject Button_1;
    public GameObject Button_2;
    public GameObject Button_3;
    public GameObject Button_4;

    private float scenarioNum;

    private List<GameObject> allToolGameObjects;
    private List<GameObject> scenarioGameObjects;

    private GameObject correctButton;

    void Start()
    {
        allToolGameObjects = new List<GameObject>();
        allToolGameObjects.AddRange(new List<GameObject>()
        {
            Drill_Red, Drill_Yellow, Drill_Blue, Pliers, Saw, ScrewDriver_1, ScrewDriver_2, ScrewDriver_3, Axe_Brown,
            Axe_Red, Hammer_Brown, Hammer_Blue, Hammer_Yellow, Wrench
        });
        foreach (var gameObject in allToolGameObjects)
        {
            gameObject.SetActive(false);
        }
        scenarioGameObjects = new List<GameObject>();
        createScenario();
    }

    public void OnButtonPush(GameObject button)
    {
        if (correctButton.gameObject.name == button.gameObject.name)
        {
            Debug.Log("You win");
            changeScene();
        }
        else
        {
            Debug.Log("You lose - resetting scenario...");
            SetScenarioDisabled();
            createScenario();
        }
    }

    void changeScene()
    {
        OVRScreenFade fade = OVRScreenFade.instance;
        fade.FadeOut();
        SceneManager.LoadScene(1);
    }

    private void createScenario()
    {
        scenarioNum = Random.Range(1, 12);
        Debug.Log(scenarioNum);
        DetermineScenario();
    }

    private void DetermineScenario()
    {
        switch (scenarioNum)
        {
            case 1:
                InitializeScenario1();
                break;
            case 2:
                InitializeScenario2();
                break;
            case 3:
                InitializeScenario3();
                break;
            case 4:
                InitializeScenario4();
                break;
            case 5:
                InitializeScenario5();
                break;
            case 6:
                InitializeScenario6();
                break;
            case 7:
                InitializeScenario7();
                break;
            case 8:
                InitializeScenario8();
                break;
            case 9:
                InitializeScenario9();
                break;
            case 10:
                InitializeScenario10();
                break;
            case 11:
                InitializeScenario11();
                break;
            case 12:
                InitializeScenario12();
                break;
        }
        SetButtonsActive();
        SetScenarioActive();
    }

    private void SetScenarioActive()
    {
        foreach (var scenarioGameObject in scenarioGameObjects)
        {
            scenarioGameObject.SetActive(true);
        }
    }

    private void SetScenarioDisabled()
    {
        foreach (var scenarioGameObject in scenarioGameObjects)
        {
            scenarioGameObject.SetActive(false);
        }
    }

    private void InitializeScenario1()
    {
        //Initialize Buttons
        scenarioGameObjects.Add(Hammer_Blue);
        scenarioGameObjects.Add(Axe_Brown);
        scenarioGameObjects.Add(Drill_Yellow);
        scenarioGameObjects.Add(Drill_Blue);
        scenarioGameObjects.Add(Wrench);
        scenarioGameObjects.Add(ScrewDriver_2);
        scenarioGameObjects.Add(Saw);
        correctButton = Button_1;
    }

    private void InitializeScenario2()
    {
        //Initialize Buttons
        scenarioGameObjects.Add(Drill_Yellow);
        scenarioGameObjects.Add(Drill_Blue);
        scenarioGameObjects.Add(Wrench);
        scenarioGameObjects.Add(ScrewDriver_1);
        scenarioGameObjects.Add(ScrewDriver_3);
        scenarioGameObjects.Add(Saw);
        correctButton = Button_2;
    }

    private void InitializeScenario3()
    {
        //Initialize Buttons
        scenarioGameObjects.Add(Hammer_Blue);
        scenarioGameObjects.Add(Axe_Brown);
        scenarioGameObjects.Add(Drill_Yellow);
        scenarioGameObjects.Add(Drill_Blue);
        scenarioGameObjects.Add(Wrench);
        scenarioGameObjects.Add(ScrewDriver_2);
        correctButton = Button_1;
    }

    private void InitializeScenario4()
    {
        //Initialize Buttons
        scenarioGameObjects.Add(Hammer_Blue);
        scenarioGameObjects.Add(Axe_Brown);
        scenarioGameObjects.Add(Drill_Yellow);
        scenarioGameObjects.Add(Drill_Blue);
        scenarioGameObjects.Add(Drill_Red);
        scenarioGameObjects.Add(Wrench);
        scenarioGameObjects.Add(Saw);
        correctButton = Button_2;
    }

    private void InitializeScenario5()
    {
        //Initialize Buttons
        scenarioGameObjects.Add(Hammer_Blue);
        scenarioGameObjects.Add(Axe_Brown);
        scenarioGameObjects.Add(Axe_Red);
        scenarioGameObjects.Add(Drill_Yellow);
        scenarioGameObjects.Add(Drill_Red);
        scenarioGameObjects.Add(Wrench);
        scenarioGameObjects.Add(Saw);
        scenarioGameObjects.Add(ScrewDriver_2);
        correctButton = Button_3;
    }

    private void InitializeScenario6()
    {
        //Initialize Buttons
        scenarioGameObjects.Add(Hammer_Brown);
        scenarioGameObjects.Add(Axe_Brown);
        scenarioGameObjects.Add(Axe_Red);
        scenarioGameObjects.Add(Drill_Blue);
        scenarioGameObjects.Add(Wrench);
        scenarioGameObjects.Add(Pliers);
        scenarioGameObjects.Add(Saw);
        scenarioGameObjects.Add(ScrewDriver_1);
        scenarioGameObjects.Add(ScrewDriver_3);
        correctButton = Button_2;
    }

    private void InitializeScenario7()
    {
        //Initialize Buttons
        scenarioGameObjects.Add(Axe_Brown);
        scenarioGameObjects.Add(Axe_Red);
        scenarioGameObjects.Add(Drill_Blue);
        scenarioGameObjects.Add(Wrench);
        scenarioGameObjects.Add(Pliers);
        scenarioGameObjects.Add(Saw);
        scenarioGameObjects.Add(ScrewDriver_1);
        scenarioGameObjects.Add(ScrewDriver_3);
        correctButton = Button_1;
    }

    private void InitializeScenario8()
    {
        //Initialize Buttons
        scenarioGameObjects.Add(Hammer_Yellow);
        scenarioGameObjects.Add(Axe_Brown);
        scenarioGameObjects.Add(Axe_Red);
        scenarioGameObjects.Add(Drill_Blue);
        scenarioGameObjects.Add(Wrench);
        scenarioGameObjects.Add(Pliers);
        scenarioGameObjects.Add(Saw);
        scenarioGameObjects.Add(ScrewDriver_3);
        correctButton = Button_3;
    }

    private void InitializeScenario9()
    {
        //Initialize Buttons
        scenarioGameObjects.Add(Hammer_Yellow);
        scenarioGameObjects.Add(Hammer_Blue);
        scenarioGameObjects.Add(Axe_Red);
        scenarioGameObjects.Add(Drill_Blue);
        scenarioGameObjects.Add(Drill_Red);
        scenarioGameObjects.Add(Wrench);
        scenarioGameObjects.Add(Pliers);
        scenarioGameObjects.Add(Saw);
        scenarioGameObjects.Add(ScrewDriver_2);
        correctButton = Button_3;
    }

    private void InitializeScenario10()
    {
        //Initialize Buttons
        scenarioGameObjects.Add(Hammer_Yellow);
        scenarioGameObjects.Add(Axe_Red);
        scenarioGameObjects.Add(Axe_Brown);
        scenarioGameObjects.Add(Drill_Blue);
        scenarioGameObjects.Add(Pliers);
        scenarioGameObjects.Add(Saw);
        scenarioGameObjects.Add(ScrewDriver_2);
        scenarioGameObjects.Add(ScrewDriver_3);
        correctButton = Button_2;
    }

    private void InitializeScenario11()
    {
        //Initialize Buttons
        scenarioGameObjects.Add(Hammer_Yellow);
        scenarioGameObjects.Add(Axe_Red);
        scenarioGameObjects.Add(Drill_Blue);
        scenarioGameObjects.Add(Drill_Red);
        scenarioGameObjects.Add(Pliers);
        scenarioGameObjects.Add(Saw);
        scenarioGameObjects.Add(ScrewDriver_2);
        scenarioGameObjects.Add(ScrewDriver_1);
        correctButton = Button_1;
    }

    private void InitializeScenario12()
    {
        //Initialize Buttons
        scenarioGameObjects.Add(Hammer_Yellow);
        scenarioGameObjects.Add(Axe_Red);
        scenarioGameObjects.Add(Drill_Blue);
        scenarioGameObjects.Add(Drill_Yellow);
        scenarioGameObjects.Add(Pliers);
        scenarioGameObjects.Add(Saw);
        scenarioGameObjects.Add(ScrewDriver_2);
        scenarioGameObjects.Add(ScrewDriver_1);
        correctButton = Button_4;
    }

    private void SetButtonsActive()
    {
        Button_1.SetActive(false);
        Button_2.SetActive(true);
        Button_3.SetActive(true);
        Button_4.SetActive(false);
        if (scenarioNum is >= 5 and <= 8)
        {
            Button_1.SetActive(true);
        }
        if (scenarioNum is >= 9 and <= 12)
        {
            Button_1.SetActive(true);
            Button_4.SetActive(true);
        }
    }
}
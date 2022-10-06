using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{

    private int Turn = 0;
    private float TurnTimer = 15;

    public GameObject CurrentPlayer;
    public string CurrentPlayerString;


    private GameObject Teams;

    private GameObject BlueTeam;
    private GameObject RedTeam;
    private GameObject CyanTeam;
    private GameObject PurpleTeam;

    private GameObject BluePlayer1;
    private GameObject RedPlayer1;
    private GameObject CyanPlayer1;
    private GameObject PurplePlayer1;

    public GameObject Canvas;
    public GameObject UIHealth;
    public GameObject UITeam;
    public GameObject UITime;
    public Text TextUIHealth;
    public Text TextUITeam;
    public Text TextUITime;

    public void Start()
    {
        // GameObjects
        Teams = GameObject.Find("Teams");

        BlueTeam = Teams.transform.GetChild(0).gameObject;
        RedTeam = Teams.transform.GetChild(1).gameObject;
        CyanTeam = Teams.transform.GetChild(2).gameObject;
        PurpleTeam = Teams.transform.GetChild(3).gameObject;

        BluePlayer1 = BlueTeam.transform.GetChild(0).gameObject;
        RedPlayer1 = RedTeam.transform.GetChild(0).gameObject;
        CyanPlayer1 = CyanTeam.transform.GetChild(0).gameObject;
        PurplePlayer1 = PurpleTeam.transform.GetChild(0).gameObject;


        // UI
        Canvas = GameObject.Find("Canvas");

        UIHealth = Canvas.transform.GetChild(0).gameObject;
        UITeam = Canvas.transform.GetChild(1).gameObject;
        UITime = Canvas.transform.GetChild(2).gameObject;

        TextUIHealth = UIHealth.GetComponent<Text>();
        TextUITeam = UITeam.GetComponent<Text>();
        TextUITime = UITime.GetComponent<Text>();

        CurrentPlayer = BluePlayer1;
        CurrentPlayerString = "BluePlayer1";
        CurrentPlayer.GetComponent<ScriptWorm>().EnableControls();

    }

    public void NextTurn()
    {
        Turn += 1;
        TurnTimer = 15;
        CurrentPlayer.GetComponent<ScriptWorm>().DisableControls();

        switch (CurrentPlayerString)
        {
            case "BluePlayer1":
                CurrentPlayerString = "RedPlayer1";
                if (RedPlayer1)
                {
                    CurrentPlayer = RedPlayer1;
                    TextUITeam.text = "RED";
                    TextUITeam.color = new Color(1, 0, 0, 1);
                }
                else
                {
                    NextTurn();
                }
                break;

            case "RedPlayer1":
                CurrentPlayerString = "CyanPlayer1";
                if (CyanPlayer1)
                {
                    CurrentPlayer = CyanPlayer1;
                    TextUITeam.text = "CYAN";
                    TextUITeam.color = new Color(0, 0.4197531f, 0.4811321f, 1);
                }
                else
                {
                    NextTurn();
                }
                break;

            case "CyanPlayer1":
                CurrentPlayerString = "PurplePlayer1";
                if (PurplePlayer1)
                {
                    CurrentPlayer = PurplePlayer1;
                    TextUITeam.text = "Purple";
                    TextUITeam.color = new Color(0.4003641f, 0, 0.6320754f, 1);
                }
                else
                {
                    NextTurn();
                }
                break;

            case "PurplePlayer1":
                CurrentPlayerString = "BluePlayer1";
                if (BluePlayer1)
                {
                    CurrentPlayer = BluePlayer1;
                    TextUITeam.text = "BLUE";
                    TextUITeam.color = new Color(0, 0, 1, 1);
                }
                else
                {
                    NextTurn();
                }
                break;

            default:
                break;
        }
        CurrentPlayer.GetComponent<ScriptWorm>().EnableControls();
        TextUIHealth.text = (CurrentPlayer.GetComponent<ScriptWorm>().HitPoints).ToString();
    }

    void DisableAll()
    {
        BluePlayer1.GetComponent<ScriptWorm>().DisableControls();
        RedPlayer1.GetComponent<ScriptWorm>().DisableControls();
        CyanPlayer1.GetComponent<ScriptWorm>().DisableControls();
        PurplePlayer1.GetComponent<ScriptWorm>().DisableControls();
    }

    void Update()
    {
        // DEBUG manually changing players
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DisableAll();
            CurrentPlayerString = "BluePlayer1";
            CurrentPlayer = BluePlayer1;
            CurrentPlayer.GetComponent<ScriptWorm>().EnableControls();
            TextUITeam.text = "BLUE";
            TextUITeam.color = new Color(0, 0, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DisableAll();
            CurrentPlayerString = "RedPlayer1";
            CurrentPlayer = RedPlayer1;
            CurrentPlayer.GetComponent<ScriptWorm>().EnableControls();
            TextUITeam.text = "RED";
            TextUITeam.color = new Color(1, 0, 0, 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DisableAll();
            CurrentPlayerString = "CyanPlayer1";
            CurrentPlayer = CyanPlayer1;
            CurrentPlayer.GetComponent<ScriptWorm>().EnableControls();
            TextUITeam.text = "CYAN";
            TextUITeam.color = new Color(0, 0.4197531f, 0.4811321f, 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DisableAll();
            CurrentPlayerString = "PurplePlayer1";
            CurrentPlayer = PurplePlayer1;
            CurrentPlayer.GetComponent<ScriptWorm>().EnableControls();
            TextUITeam.text = "Purple";
            TextUITeam.color = new Color(0.4003641f, 0, 0.6320754f, 1);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            NextTurn();
        }

        if (TurnTimer > 0)
        {
            TurnTimer -= Time.deltaTime;
            TextUITime.text = Mathf.RoundToInt(TurnTimer).ToString();
        }
        if (TurnTimer < 0)
        {
            NextTurn();
            TurnTimer = 15;
        }


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameManager() { }
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }


    public enum GameStatuses
    {
        Begin,
        Main,
        Suspend,
        Success,
        Fault
    }
    public static GameStatuses gamestatus = GameStatuses.Begin;
    private void Start()
    {
        gamestatus = GameStatuses.Begin;
        SceneChange("Begin");
    }
    public static void StatusChange(GameStatuses status)
    {
        gamestatus = status;
    }
    public static void SceneChange(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    private void Update()
    {
        Debug.Log(gamestatus);
        isend();
        StatusCtl();
    }
    public void isend()
    {
        if (gamestatus == GameStatuses.Fault)
        {
            GameObject canvas = GameObject.Find("Canvas");
            canvas.transform.Find("Panel").gameObject.SetActive(true);
        }
    }
    public void StatusCtl()
    {
        if (gamestatus == GameStatuses.Main)
        {
            GameObject canvas = GameObject.Find("Canvas");
            if (canvas.transform.Find("Panel") != null)
            {
                canvas.transform.Find("Panel").gameObject.SetActive(false);
            }
        }
    }
}

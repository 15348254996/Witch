using System.Threading;
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
        Start,             //起始程序
        Begin,             //选择是否开始游戏
        Op,                //Op动画
        Guidance,          //指导场景
        TheFirstManager,   //第一次见面 
        Main,              //主游戏
        Choice,
        Go,
        GoResult,
        NotGo,
        Final,
        Suspend,
        Success,
        Fault              //游戏失败
    }
    public static GameStatuses gamestatus = GameStatuses.Start;
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
    }
    public void isend()
    {
        if (gamestatus == GameStatuses.Fault)
        {
            GameObject canvas = GameObject.Find("Canvas");
            canvas.transform.Find("Panel").gameObject.SetActive(true);
        }
    }

    public void CountdowntoNormal(Collider2D other)
    {
        StartCoroutine(counttonormal(other));
    }

    public IEnumerator counttonormal(Collider2D other)
    {
        yield return new WaitForSeconds(1);
        other.GetComponent<CtrlCharacter>().backtonormal();
    }
}

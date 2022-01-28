using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backtostart : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() => GameManager.SceneChange("Begin"));
        this.GetComponent<Button>().onClick.AddListener(gamestatuschange);
    }
    public void gamestatuschange()
    {
        GameManager.gamestatus = GameManager.GameStatuses.Begin;
    }
}

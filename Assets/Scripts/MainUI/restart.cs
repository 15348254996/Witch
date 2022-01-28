using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class restart : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() => GameManager.SceneChange("Main"));
        this.GetComponent<Button>().onClick.AddListener(gamestatuschange);
    }
    public void gamestatuschange()
    {
        GameManager.gamestatus = GameManager.GameStatuses.Main;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Startgame : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() => GameManager.SceneChange("Main"));
        this.GetComponent<Button>().onClick.AddListener(() => GameManager.StatusChange(GameManager.GameStatuses.Main));
    }

}

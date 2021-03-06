using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoButton : MonoBehaviour
{
    void Start()
    {
        GameManager.StatusChange(GameManager.GameStatuses.Choice);
        Button go = this.gameObject.GetComponent<Button>();
        go.onClick.AddListener(ChangeGo);
    }
    void Update()
    {

    }
    void ChangeGo()
    {
        GameManager.StatusChange(GameManager.GameStatuses.Go);
        GameManager.SceneChange("Go");
    }
}

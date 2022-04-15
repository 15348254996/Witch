using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoManager : MonoBehaviour
{
    public List<GameObject> Enemy;
    public DialogSystem dialogSystem;
    public bool sevendialog;
    void Start()
    {
        CtrlCharacter.status = CtrlCharacter.statuses.inAnime;
        GameManager.StatusChange(GameManager.GameStatuses.Go);
        dialogSystem = GameObject.Find("Canvas").GetComponent<DialogSystem>();
        dialogSystem.loadText(Resources.Load<TextAsset>("Txt/第六场"));
        GameObject Panel1 = dialogSystem.gameObject.transform.Find("Panel").gameObject;
        Panel1.SetActive(true);
        CtrlCharacter.islearnMagic = true;
    }
    void Update()
    {
        dialogSystem.showtext();
        if (dialogSystem.getisover() == true)
        {
            if (dialogSystem.GetDialogResources() == Resources.Load<TextAsset>("Txt/第六场"))
            {
                CtrlCharacter.status = CtrlCharacter.statuses.normal;
                CtrlCharacter.islearnMagic = true;
            }
            if (dialogSystem.GetDialogResources() == Resources.Load<TextAsset>("Txt/第七场"))
            {
                GameManager.StatusChange(GameManager.GameStatuses.GoResult);
                GameManager.SceneChange("GoResult");
            }
        }
        foreach (GameObject everyenemy in Enemy)
        {
            if (everyenemy == null)
            {
                Enemy.Remove(everyenemy);
                break;
            }
        }
        if (Enemy.Count == 0 && sevendialog == false)
        {
            dialogSystem.loadText(Resources.Load<TextAsset>("Txt/第七场"));
            GameObject Panel1 = dialogSystem.gameObject.transform.Find("Panel").gameObject;
            Panel1.SetActive(true);
            sevendialog = true;
        }
    }
}

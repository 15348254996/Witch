using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public DialogSystem dialogSystem;
    public List<GameObject> allEnemy;
    public bool fourdialog = false;
    void Start()
    {
        CtrlCharacter.status = CtrlCharacter.statuses.inAnime;
        GameManager.StatusChange(GameManager.GameStatuses.Main);
        dialogSystem = GameObject.Find("Canvas").GetComponent<DialogSystem>();
        dialogSystem.loadText(Resources.Load<TextAsset>("Txt/第四场"));
        GameObject Panel1 = dialogSystem.gameObject.transform.Find("Panel").gameObject;
        Panel1.SetActive(true);
        CtrlCharacter.islearnMagic = true;
    }

    // Update is called once per frame
    void Update()
    {
        dialogSystem.showtext();
        if (dialogSystem.getisover() == true)
        {
            if (dialogSystem.GetDialogResources() == Resources.Load<TextAsset>("Txt/第四场"))
            {
                CtrlCharacter.status = CtrlCharacter.statuses.normal;
            }
            if (dialogSystem.GetDialogResources() == Resources.Load<TextAsset>("Txt/第五场"))
            {
                GameManager.StatusChange(GameManager.GameStatuses.Choice);
                GameManager.SceneChange("Choice");
            }
        }
        foreach (GameObject everyenemy in allEnemy)
        {
            if (everyenemy == null)
            {
                allEnemy.Remove(everyenemy);
                break;
            }
        }
        if (allEnemy.Count == 0 && fourdialog == false)
        {
            dialogSystem.loadText(Resources.Load<TextAsset>("Txt/第五场"));
            GameObject Panel1 = dialogSystem.gameObject.transform.Find("Panel").gameObject;
            Panel1.SetActive(true);
            fourdialog = true;
        }
    }
}

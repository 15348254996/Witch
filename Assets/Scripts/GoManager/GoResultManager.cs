using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoResultManager : MonoBehaviour
{
    public DialogSystem dialogSystem;
    public Image resultimage;

    void Start()
    {
        resultimage = GameObject.Find("Canvas").transform.Find("Image").GetComponent<Image>();
        CtrlCharacter.status = CtrlCharacter.statuses.inAnime;
        GameManager.StatusChange(GameManager.GameStatuses.GoResult);
        dialogSystem = GameObject.Find("Canvas").GetComponent<DialogSystem>();
        dialogSystem.loadText(Resources.Load<TextAsset>("Txt/第八场"));
        GameObject Panel1 = dialogSystem.gameObject.transform.Find("Panel").gameObject;
        Panel1.SetActive(true);
        CtrlCharacter.islearnMagic = true;
    }
    void Update()
    {
        dialogSystem.showtext();
        if (dialogSystem.getisover() == true)
        {
            if (dialogSystem.GetDialogResources() == Resources.Load<TextAsset>("Txt/第八场"))
            {
                resultimage.gameObject.SetActive(true);
            }
        }
    }
}

using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotGoManager : MonoBehaviour
{
    public DialogSystem dialogSystem;
    // Start is called before the first frame update
    public Image image;
    void Start()
    {
        GameManager.StatusChange(GameManager.GameStatuses.NotGo);
        dialogSystem = GameObject.Find("Canvas").GetComponent<DialogSystem>();
        dialogSystem.loadText(Resources.Load<TextAsset>("Txt/第九场")); GameObject Panel1 = dialogSystem.gameObject.transform.Find("Panel").gameObject;
        Panel1.SetActive(true);
        image = GameObject.Find("Canvas").transform.Find("Image").gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        dialogSystem.showtext();
        if (dialogSystem.getisover() == true)
        {
            if (dialogSystem.GetDialogResources() == Resources.Load<TextAsset>("Txt/第九场"))
            {
                image.gameObject.SetActive(true);
            }
        }
    }
}

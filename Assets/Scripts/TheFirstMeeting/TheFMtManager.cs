using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TheFMtManager : MonoBehaviour
{
    [Header("对话系统")]
    public DialogSystem dialogSystem;
    private GameObject Timeline;
    private PlayableDirector playableDirector;
    public CtrlCharacter ctrlCharacter;
    void Start()
    {
        GameManager.StatusChange(GameManager.GameStatuses.TheFirstManager);
        dialogSystem = GameObject.Find("Canvas").GetComponent<DialogSystem>();
        dialogSystem.loadText(Resources.Load<TextAsset>("Txt/第二场"));
        CtrlCharacter.status = CtrlCharacter.statuses.inAnime;
        Timeline = GameObject.Find("TimelineCtl");
        playableDirector = Timeline.GetComponent<PlayableDirector>();
        ctrlCharacter = GameObject.Find("Character").GetComponent<CtrlCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        dialogSystem.showtext();
        if (dialogSystem.getisover() == true)
        {
            playableDirector.Play();
            if (dialogSystem.GetDialogResources() == Resources.Load<TextAsset>("Txt/第三场"))
            {
                CtrlCharacter.status = CtrlCharacter.statuses.normal;
            }
        }
    }
    public void TheSecondDialog()
    {
        dialogSystem.loadText(Resources.Load<TextAsset>("Txt/第三场"));
    }
}

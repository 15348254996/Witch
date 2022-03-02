using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideManager : MonoBehaviour
{
    [Header("游戏组件")]
    public GameObject Character;
    public DialogSystem dialogSystem;
    public TextAsset textAsset;
    public Text dialogtext;
    public GameObject Panel;
    private bool istextover = false;
    void Start()
    {
        Character = GameObject.Find("Character");
        CtrlCharacter.status = CtrlCharacter.statuses.inAnime;
        dialogSystem = GameObject.Find("Canvas").GetComponent<DialogSystem>();
        textAsset = Resources.Load("Txt/第一场") as TextAsset;
        Panel = GameObject.Find("Canvas").transform.Find("Panel").gameObject;
        dialogtext = Panel.transform.Find("DialogText").
              transform.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Animator CarAniCtl = Character.GetComponent<Animator>();
        AnimatorStateInfo Isidle = CarAniCtl.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo Ismoveover = CarAniCtl.GetCurrentAnimatorStateInfo(1);
        if (Ismoveover.normalizedTime >= 0.9f)
        {
            CarAniCtl.SetTrigger("MoveIsOver");
        }
        Debug.Log(Isidle.IsName("Idle"));
        Debug.Log(Isidle.normalizedTime >= 0.9f);
        if (Isidle.IsName("Idle") && Isidle.normalizedTime >= 0.9f)
        {
            if (istextover == false)
            {
                Panel.SetActive(true);
            }
            dialogSystem.showtext(textAsset, dialogtext);
            istextover = true;
        }
    }

}

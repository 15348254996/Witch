using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideManager : MonoBehaviour
{
    [Header("游戏组件")]
    public GameObject Character;
    public DialogSystem dialogSystem;
    public Text dialogtext;
    public GameObject Panel;
    private bool istextover = false;
    private void Start()
    {
        GameManager.StatusChange(GameManager.GameStatuses.Guidance);
        Character = GameObject.Find("Character");
        CtrlCharacter.status = CtrlCharacter.statuses.inAnime;
        dialogSystem = GameObject.Find("Canvas").GetComponent<DialogSystem>();
        dialogSystem.loadText(Resources.Load<TextAsset>("Txt/第一场"));
        Panel = GameObject.Find("Canvas").transform.Find("Panel").gameObject;//找到画布
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
        if (Isidle.IsName("Idle") && Isidle.normalizedTime >= 0.9f)
        {
            if (istextover == false)
            {
                Panel.SetActive(true);
            }
            dialogSystem.showtext();
            istextover = true;
        }
        if (dialogSystem.getisover() == true)
        {
            CtrlCharacter.status = CtrlCharacter.statuses.normal;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpManager : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject OpenText;
    private Animator Opanime;
    void Start()
    {
        OpenText = GameObject.Find("OpText");
        Opanime = OpenText.GetComponent<Animator>();
    }
    private void Update()
    {
        AnimatorStateInfo sinf = Opanime.GetCurrentAnimatorStateInfo(0);
        if (sinf.normalizedTime >= 1.0f)
        {
            GameManager.StatusChange(GameManager.GameStatuses.Guidance);
            GameManager.SceneChange("Guidance");
        }
    }


}

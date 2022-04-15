using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoFinal : MonoBehaviour
{
    public Animator animator;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();

    }
    private void Update()
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime >= 1.0f)
        {
            GameManager.StatusChange(GameManager.GameStatuses.Final);
            GameManager.SceneChange("Final");
        }
    }

}

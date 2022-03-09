using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlCharacter : BaseCharacter
{
    public Rigidbody2D rigidbody2d;
    private float inputx;
    private float inputy;
    public Animator animatorCtl;
    public bool islearnMagic;
    public float getinputx()
    {
        return inputx;
    }
    public float getinputy()
    {
        return inputy;
    }
    private void Start()
    {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        animatorCtl = this.GetComponent<Animator>();
        grandFa = GetComponentsInChildren<Transform>(true);
        islearnMagic = false;
        HP = 100;
    }
    private void FixedUpdate()
    {
        Debug.Log(status);
        if (status != statuses.inAnime)
        {
            inputx = Input.GetAxis("Horizontal");
            inputy = Input.GetAxis("Vertical");
            MoveUpdate();
            AnimateUpdate();
        }
        Isdie();
        StatusCtl(status);
    }
    public void MoveUpdate()
    {
        if (status != BaseCharacter.statuses.frozen && status != BaseCharacter.statuses.die)
        {
            rigidbody2d.MovePosition(new Vector2(rigidbody2d.transform.position.x + inputx * speed * Time.fixedDeltaTime,
            rigidbody2d.transform.position.y + inputy * speed * Time.fixedDeltaTime));//刚体控制移动防止撞墙疯狂抖动
        }
        if (inputx < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (inputx > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    public void AnimateUpdate()
    {
        {//控制移动动画的播放
            if (Math.Abs(inputx - 0) < 0.001 && Math.Abs(inputy - 0) < 0.001)
            {
                animatorCtl.SetBool("isRun", false);
            }
            else
            {
                animatorCtl.SetBool("isRun", true);
            }
        }

        {//控制攻击动作，此处只判断了按键和cd，还应该判断人物状态
            if (Input.GetKeyDown(KeyCode.J) && attackIsAlready() == true &&
                    status == statuses.normal && islearnMagic == true)
            {
                animatorCtl.SetTrigger("isAttack");
                Fire();
            }
        }
    }

    public void Fire()
    {
        GameObject fire = new GameObject();
        Fireball fireball = fire.AddComponent<Fireball>();
        fireball.Init(this);
        Destroy(fire, 0.5f);
    }
    public void Takedamage(int damage)
    {
        HP = Mathf.Clamp(HP - damage, 0, 100);
    }
    private void Isdie()
    {
        if (HP == 0)
        {
            status = BaseCharacter.statuses.die;
            GameManager.StatusChange(GameManager.GameStatuses.Fault);
        }
        else if (status != statuses.frozen && status != statuses.inAnime)
        {
            status = BaseCharacter.statuses.normal;
        }
    }
    private void StatusCtl(statuses status)
    {
        if (status == statuses.normal)
        {
            return;
        }
        else if (status == statuses.frozen)
        {
            foreach (Transform gameObject in grandFa)
            {
                if (gameObject.GetComponent<SpriteRenderer>() != null)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                }
            }

        }
        else if (status == statuses.die)
        {
            foreach (Transform gameObject in grandFa)
            {
                if (gameObject.GetComponent<SpriteRenderer>() != null)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                    GameManager.gamestatus = GameManager.GameStatuses.Fault;
                }
            }
        }
    }

    public void backtonormal()
    {
        status = statuses.normal;
        foreach (Transform gameObject in grandFa)
        {
            if (gameObject.GetComponent<SpriteRenderer>() != null)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

}

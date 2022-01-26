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
    }
    private void FixedUpdate()
    {
        MoveUpdate();
        AnimateUpdate();
        inputx = Input.GetAxis("Horizontal");
        inputy = Input.GetAxis("Vertical");
    }
    public void MoveUpdate()
    {
        rigidbody2d.MovePosition(new Vector2(rigidbody2d.transform.position.x + inputx * speed * Time.fixedDeltaTime,
        rigidbody2d.transform.position.y + inputy * speed * Time.fixedDeltaTime));//刚体控制移动防止撞墙疯狂抖动
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
            if (Input.GetKeyDown(KeyCode.J) && attackIsAlready == true)
            {
                animatorCtl.SetTrigger("isAttack");
                attackIsAlready = false;
                Fire();
                //Debug.Log(Time.time);
                StartCoroutine(Timer(cd));
            }
        }
    }

    public void Fire()
    {
        GameObject fire = new GameObject();
        Fireball fireball = fire.AddComponent<Fireball>();
        fireball.Init(this);
        //Destroy(fire, 0.5f);
    }

    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        attackIsAlready = true;
    }

}

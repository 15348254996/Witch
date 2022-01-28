using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    protected int Hp;
    protected GameObject skin;
    protected Rigidbody2D rigidbody2d;
    protected GameObject character;
    protected float bulletspeed;
    protected float attackcd = 1.0f;
    protected float lasttime = 0.0f;
    protected float attackdistance = 10.0f;
    public enum statuses
    {
        normal,
        attack,
        die
    }
    public statuses status = statuses.normal;
    protected float speed = 3.0f;
    public virtual void Start()
    {
        character = GameObject.Find("Character");
        rigidbody2d = this.gameObject.GetComponent<Rigidbody2D>();
    }
    public virtual void Update() { }
    public virtual void Fire() { }
    public bool IsinDistance()
    {
        float distance = (this.transform.position - character.transform.position).magnitude;
        if (distance < attackdistance)
        {
            return true;
        }
        return false;
    }
    public bool attackIsAlready()
    {
        if (Time.time - lasttime > attackcd)
        {
            lasttime = Time.time;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Takedamage(int damage)
    {
        Hp = Mathf.Clamp(Hp - damage, 0, 100);
    }
    public void StatusCtl(statuses status)
    {
        if (status == statuses.normal)
        {
            return;
        }
        else if (status == statuses.attack)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("backtonormal", 0.3f);
        }
        else if (status == statuses.die)
        {
            Destroy(this.gameObject);
        }
    }
    public void IsDie()
    {
        if (Hp == 0)
        {
            status = statuses.die;
        }
    }
    public void backtonormal()
    {
        status = statuses.normal;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}

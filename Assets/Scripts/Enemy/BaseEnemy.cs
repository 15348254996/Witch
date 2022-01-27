using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    private int Hp = 100;
    protected GameObject skin;
    protected Rigidbody2D rigidbody2d;
    protected GameObject character;
    protected float bulletspeed;
    protected float attackcd = 1.0f;
    protected float lasttime = 0.0f;
    protected float attackdistance = 10.0f;
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
}

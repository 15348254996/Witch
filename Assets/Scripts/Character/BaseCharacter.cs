using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    private GameObject skin;
    public int HP;
    public int SP;
    public enum status//角色的状态
    {
        normal,//正常状态
        frozen,//冻结状态
        burn,//烧伤状态
        dizziness,//催眠状态
        die
    }
    public float speed = 5;
    public float cd = 0.5f;
    public bool attackIsAlready = true;
    public virtual void Init(string path)
    {
        GameObject skinres = Resources.Load<GameObject>(path);
        skin = (GameObject)Instantiate(skinres);
        skin.transform.parent = this.transform.parent;
        skin.transform.position = Vector3.zero;
        skin.transform.localEulerAngles = Vector3.zero;
    }

    private void Start()
    {

    }
    private void Update()
    {

    }

}

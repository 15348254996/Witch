using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceball : MonoBehaviour
{
    public float Speed = 3f;
    private GameObject character;
    private GameObject bluebird;
    public Vector3 unit;
    private GameObject skin;
    private Rigidbody2D rigidbody2d;
    private void Update()
    {
        MoveUpdate();
    }
    public void Init(GameObject thecharacter, GameObject thebluebird)
    {
        character = thecharacter;
        GameObject skinres = ResManager.LoadPrefab("Prefab/Bullet/Iceball");
        bluebird = thebluebird;
        skin = (GameObject)Instantiate(skinres);
        rigidbody2d = skin.GetComponent<Rigidbody2D>();
        skin.transform.localPosition = bluebird.transform.position;
        skin.transform.parent = this.transform;
        unit = UnitVector();
        Destroy(this.gameObject, 3f);
    }
    public void MoveUpdate()
    {
        rigidbody2d.transform.position += unit * Speed * Time.deltaTime;
    }
    public Vector3 UnitVector()//计算单位向量
    {
        Vector3 apart = (character.transform.position - bluebird.transform.position).normalized;
        return apart;
    }
}

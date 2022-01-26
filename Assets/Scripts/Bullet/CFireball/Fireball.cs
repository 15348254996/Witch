using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed = 6.0f;
    private CtrlCharacter character;
    private GameObject skin;
    private float direct;//人物朝向 0时向右  180时向左
    Rigidbody2D rigidbody2d;

    private void Update()
    {

        if (direct - 0 < 0.001f)
        {
            rigidbody2d.MovePosition(new Vector2(rigidbody2d.transform.position.x + Speed * Time.fixedDeltaTime,
            rigidbody2d.transform.position.y));
            Debug.Log(rigidbody2d.transform.position.x);
        }
        if (direct - 180 < 0.001f)
        {
            rigidbody2d.MovePosition(new Vector2(rigidbody2d.transform.position.x - Speed * Time.fixedDeltaTime,
            rigidbody2d.transform.position.y));
        }
    }
    public void Init(CtrlCharacter ctrlCharacter)//需要传入调用的角色
    {
        character = ctrlCharacter;
        direct = character.transform.rotation.eulerAngles.y;//获取角色方向
        GameObject skinRes = ResManager.LoadPrefab("Prefab/Bullet/Fireball");
        skin = (GameObject)Instantiate(skinRes);
        rigidbody2d = skin.GetComponent<Rigidbody2D>();
        skin.transform.localPosition = GameObject.Find("FirePoint").transform.position;
        skin.transform.parent = this.transform;
        if (Math.Abs(direct - 0) < 0.001)
        {
            skin.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (Math.Abs(direct - 180) < 0.001)
        {
            skin.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

}

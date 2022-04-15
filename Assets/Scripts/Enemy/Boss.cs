using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : IceBird
{
    new float attackcd = 0.2f;
    new float attackdistance = 20.0f;
    new void Start()
    {
        base.Start();
        skin = Resources.Load<GameObject>("Prefab/Enemy/Bluebird");
        Hp = 100;
    }

    // Update is called once per frame
    new void Update()
    {
        Fire();
        IsDie();
        StatusCtl(status);
        //Debug.Log(Hp);
        //Debug.Log(status);
    }
    new void Fire()
    {
        if (IsinDistance() == true && attackIsAlready())
        {
            GameObject ice = new GameObject();
            Iceball iceball = ice.AddComponent<Iceball>();
            iceball.Init(character, this.gameObject);
        }
    }
}

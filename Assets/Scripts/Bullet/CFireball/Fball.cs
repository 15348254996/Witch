using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fball : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.transform.parent.gameObject);
        other.GetComponent<BaseEnemy>().Takedamage(25);
        other.GetComponent<BaseEnemy>().status = BaseEnemy.statuses.attack;
    }
}

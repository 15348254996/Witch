using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iball : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CtrlCharacter.status != BaseCharacter.statuses.die &&
        CtrlCharacter.status != BaseCharacter.statuses.frozen)
        {
            Destroy(this.transform.parent.gameObject);
            CtrlCharacter.status = BaseCharacter.statuses.frozen;
            other.GetComponent<CtrlCharacter>().Takedamage(25);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefinitionMaskAnimeEvent : MonoBehaviour
{
    public CtrlCharacter ctrlCharacter;
    public TheFMtManager theFMtManager;
    private void Awake()
    {
        ctrlCharacter = GameObject.Find("Character").GetComponent<CtrlCharacter>();
        theFMtManager = GameObject.Find("TheFMtManager").GetComponent<TheFMtManager>();
    }
    public void LetCharacterBacktoNormal()
    {
        theFMtManager.TheSecondDialog();
        theFMtManager.dialogSystem.Panel.SetActive(true);
    }
}

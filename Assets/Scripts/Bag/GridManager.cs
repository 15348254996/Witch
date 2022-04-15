using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class GridManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GridShow();
    }
    void GridShow()
    {
        Image[] allChild = GetComponentsInChildren<Image>(true);
        foreach (Image grid in allChild)
        {
            if (grid.GetComponent<Image>().sprite == null)
            {
                grid.gameObject.SetActive(false);
            }
            else if (grid.sprite != null && grid != this.GetComponent<Image>())
            {
                grid.gameObject.SetActive(true);
                grid.preserveAspect = true;
            }
        }
    }
    void AddObject(Sprite resourceimage)
    {
        Image[] allChild = GetComponentsInChildren<Image>(true);
        foreach (Image grid in allChild)
        {
            if (grid.GetComponent<Image>().sprite == null)
            {
                grid.sprite = resourceimage;
                break;
            }
        }
    }
}

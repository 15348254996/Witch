using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("对话系统组件")]
    public Text DialogText;//对话框
    public TextAsset DialogResources;//对话资源
    public TextAsset GetDialogResources()
    {
        return DialogResources;
    }
    public Image People1;//对话第一人
    public Image People2;//对话第二人
    public Text Peolpename;
    public GameObject Panel;
    List<string> Textlist = new List<string>();
    private bool isget = false;
    private bool isover;
    public bool getisover()
    {
        return isover;
    }
    private static int index = 0;

    private void Awake()
    {
        Panel = this.transform.Find("Panel").gameObject;
        DialogText = Panel.transform.Find("DialogText").Find("Text").GetComponent<Text>();
        Peolpename = Panel.transform.Find("DialogText").Find("Peoplename").GetComponent<Text>();
        People1 = Panel.transform.Find("People1").GetComponent<Image>();
        People2 = Panel.transform.Find("People2").GetComponent<Image>();
    }
    public void loadText(TextAsset textresources)
    {
        DialogResources = textresources;
        DialogText.text = "";
        Peolpename.text = "";
        Textlist.Clear();
        isget = false;
        Debug.Log("有用");
        GetListfromFile();
        index = 0;
        isover = false;
    }
    public void showtext()
    {
        //Debug.Log(Textlist.Count);
        if (Input.GetKeyDown(KeyCode.Space) && index == Textlist.Count)
        {
            index = 0;
            Panel.SetActive(false);
            isover = true;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (Textlist[index].Trim())
            {
                case "小魔女":
                    Peolpename.text = Textlist[index];
                    index++;
                    break;
                case "村民":
                    Peolpename.text = Textlist[index];
                    index++;
                    break;
                case "老师":
                    Peolpename.text = Textlist[index];
                    index++;
                    break;
                case "影子":
                    Peolpename.text = Textlist[index];
                    index++;
                    break;
            }
            DialogText.text = Textlist[index];
            index++;
        }
    }
    void GetListfromFile()
    {
        Debug.Log(isget);
        if (isget == false)
        {
            Debug.Log(DialogResources.name);
            if (DialogResources != null)
            {
                var alltext = DialogResources.text.Split('\n');
                foreach (var everytext in alltext)
                {
                    Textlist.Add(everytext);
                }
            }
            isget = true;
        }
    }
}

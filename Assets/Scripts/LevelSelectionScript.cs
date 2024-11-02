using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelSelectionScript : MonoBehaviour
{

    public int pagenumber;

    private int numbertoshow;

    public Transform buttons;

    public string[] listpaths;

    public string[] listnames;

    public TextMeshProUGUI pagetext;

    private void Start()
    {

        pagenumber = 1;
        numbertoshow = buttons.childCount;

        if (System.IO.Directory.Exists(Application.persistentDataPath + "/SavedLevels/"))
        {
            listpaths = System.IO.Directory.GetFiles(Application.persistentDataPath + "/SavedLevels/");
            listnames = new string[listpaths.Count()];
            int indice = 0;
            foreach(string path in listpaths)
            {
                string newname = path;
                string abstractpath = Application.persistentDataPath + "/SavedLevels/";
                newname=newname.Substring((int)(abstractpath.Length), newname.Length-abstractpath.Length);
                //newname = newname.Split('.')[0];
                listnames[indice]=newname;
                indice++;
            }

            AffectNames();
        }
        
        
    }

    private void FixedUpdate()
    {
        pagetext.text = pagenumber + "/" + ((int)(listpaths.Length / numbertoshow) + 1);
    }

    void AffectNames()
    {

        int buttonID = 0;

        for(int i = numbertoshow*(pagenumber-1); i < Mathf.Min(listnames.Count(),numbertoshow*pagenumber); i++)
        {
            buttons.GetChild(buttonID).gameObject.SetActive(true);
            buttons.GetChild(buttonID).GetComponentInChildren<TextMeshProUGUI>().text = listnames[i];
            buttons.GetChild(buttonID).GetComponentInChildren<ButtonScript>().levelname = listnames[i];
            buttonID++;
        }

        for (int i = buttonID;i<numbertoshow;i++)
        {

            buttons.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void nextpage()
    {
        if(listnames.Count()>(pagenumber)*numbertoshow)
        {
            pagenumber++;
            AffectNames();
        }
    }

    public void previouspage()
    {
        if(pagenumber>1)
        {
            pagenumber--;
            AffectNames();
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public GameObject[] prefablist;

    public string[] ShortcutList;
    void Start()
    {
        ShortcutList = new string[prefablist.Length];
        for(int i=0; i<prefablist.Length;i++)
        {
            ShortcutList[i] = prefablist[i].GetComponent<prefabinfo>().shortcut;
            prefablist[i].GetComponent<prefabinfo>().id = i;
        }
    }
}

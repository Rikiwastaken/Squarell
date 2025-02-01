using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{

    private GameObject Info;
    public GameObject floor;
    void Start()
    {
        Info = GameObject.Find("Info");
        Info.GetComponent<Info>().HeldKeys = 0;

        if (Info!=null)
        {
            string listtoinstantiate = Info.GetComponent<Info>().leveltoload;

            GenerateRoom(listtoinstantiate);
        }
        

    }

    void GenerateRoom(string listtoinstantiate)
    {
        string[] listalllines = listtoinstantiate.Split('%');
        GameObject[] prefabList = Info.GetComponent<PrefabManager>().prefablist;
        string[] shortculist = Info.GetComponent<PrefabManager>().ShortcutList;

        for (int y = 0; y < listalllines.Length; y++)
        {
            string[] listinside = listalllines[y].Split(',');
            for (int x = 0; x < listinside.Length; x++)
            {

                Vector2 position = new Vector2(x, -y);
                int index = getIndex(shortculist,listinside[x]);
                if (index != -1)
                {
                    GameObject newobj = Instantiate(prefabList[index], position, Quaternion.identity);
                    if (prefabList[index].GetComponent<prefabinfo>().needsfloorunderneath)
                    {
                        GameObject newfloor = Instantiate(floor, position, Quaternion.identity);
                        newfloor.transform.SetParent(GameObject.Find("Floors").transform);
                    }
                    if (listinside[x]=="F")
                    {
                        newobj.transform.SetParent(GameObject.Find("Floors").transform);
                    }
                    if (listinside[x] == "W")
                    {
                        newobj.transform.SetParent(GameObject.Find("Walls").transform);
                    }

                }
            }
        }
    }

    int getIndex(string[] list, string obj)
    {
        int index = -1;

        for(int i = 0;i<list.Length;i++)
        {
            if(list[i].Equals(obj))
            {
                return i;
            }
        }

        return index;
    }


   

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public ArrayList listtoinstantiate;

    public GameObject player;
    public GameObject wall;
    public GameObject movable;

    void Start()
    {
        listtoinstantiate = ExampleInitializer();
        GenerateRoom(listtoinstantiate);

    }

    void GenerateRoom(ArrayList list)
    {

        for (int y = 0; y < list.Count; y++)
        {

            ArrayList listinside = (ArrayList)list[y];
            for (int x = 0; x < listinside.Count; x++)
            {

                Vector2 position = new Vector2(x, -y);

                if(listinside[x].Equals('W'))
                {
                    GameObject newwall =Instantiate(wall, position,Quaternion.identity);
                    newwall.transform.SetParent(GameObject.Find("Walls").transform);
                }
                if (listinside[x].Equals('P'))
                {
                    Instantiate(player, position, Quaternion.identity);
                }
                if (listinside[x].Equals('M'))
                {
                    Instantiate(movable, position, Quaternion.identity);
                }

            }
        }

    }



    ArrayList ExampleInitializer()
    {
        ArrayList finallist = new ArrayList();

        ArrayList list = new ArrayList();
        list.Add('W');
        list.Add('W');
        list.Add('W');
        list.Add('W');
        list.Add('W');
        list.Add('W');
        list.Add('W');
        list.Add('W');

        finallist.Add(list);

        list = new ArrayList();
        list.Add('W');
        list.Add('%');
        list.Add('%');
        list.Add('%');
        list.Add('%');
        list.Add('%');
        list.Add('%');
        list.Add('W');

        finallist.Add(list);

        list = new ArrayList();
        list.Add('W');
        list.Add('%');
        list.Add('%');
        list.Add('%');
        list.Add('%');
        list.Add('%');
        list.Add('%');
        list.Add('W');

        finallist.Add(list);

        list = new ArrayList();
        list.Add('W');
        list.Add('P');
        list.Add('%');
        list.Add('W');
        list.Add('M');
        list.Add('%');
        list.Add('%');
        list.Add('W');

        finallist.Add(list);

        list = new ArrayList();
        list.Add('W');
        list.Add('%');
        list.Add('%');
        list.Add('%');
        list.Add('%');
        list.Add('%');
        list.Add('%');
        list.Add('W');

        finallist.Add(list);

        list = new ArrayList();
        list.Add('W');
        list.Add('%');
        list.Add('%');
        list.Add('%');
        list.Add('%');
        list.Add('%');
        list.Add('%');
        list.Add('W');

        finallist.Add(list);

        list = new ArrayList();
        list.Add('W');
        list.Add('W');
        list.Add('W');
        list.Add('W');
        list.Add('W');
        list.Add('W');
        list.Add('W');
        list.Add('W');

        finallist.Add(list);

        return finallist;

    }

}

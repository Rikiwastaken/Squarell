using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public ArrayList listtoinstantiate;

    public GameObject player;
    public GameObject wall;
    public GameObject movable;
    public GameObject floor;
    public GameObject victory;

    void Start()
    {
        //listtoinstantiate = ExampleInitializer();
        listtoinstantiate = ExampleInitializerSimple();
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
                    GameObject newfloor = Instantiate(floor, position, Quaternion.identity);
                    newfloor.transform.SetParent(GameObject.Find("Floors").transform);
                }
                if (listinside[x].Equals('M'))
                {
                    Instantiate(movable, position, Quaternion.identity);
                    GameObject newfloor = Instantiate(floor, position, Quaternion.identity);
                    newfloor.transform.SetParent(GameObject.Find("Floors").transform);
                }
                if (listinside[x].Equals('F'))
                {
                    GameObject newfloor = Instantiate(floor, position, Quaternion.identity);
                    newfloor.transform.SetParent(GameObject.Find("Floors").transform);
                }
                if (listinside[x].Equals('V'))
                {
                    Instantiate(victory, position, Quaternion.identity);

                }

            }
        }

    }



    ArrayList ExampleInitializerSimple()
    {
        ArrayList finallist = new ArrayList();

        ArrayList list = new ArrayList();
        list.Add('W');
        list.Add('W');
        list.Add('W');
        list.Add('W');
        list.Add('W');

        finallist.Add(list);

        list = new ArrayList();
        list.Add('W');
        list.Add('P');
        list.Add('F');
        list.Add('W');
        list.Add('W');

        finallist.Add(list);

        list = new ArrayList();
        list.Add('W');
        list.Add('W');
        list.Add('M');
        list.Add('F');
        list.Add('W');

        finallist.Add(list);

        list = new ArrayList();
        list.Add('W');
        list.Add('W');
        list.Add('F');
        list.Add('V');
        list.Add('W');

        finallist.Add(list);

        list = new ArrayList();
        list.Add('W');
        list.Add('W');
        list.Add('W');
        list.Add('W');
        list.Add('W');

        finallist.Add(list);

        return finallist;

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
        list.Add('F');
        list.Add('F');
        list.Add('F');
        list.Add('F');
        list.Add('F');
        list.Add('F');
        list.Add('W');

        finallist.Add(list);

        list = new ArrayList();
        list.Add('W');
        list.Add('F');
        list.Add('F');
        list.Add('F');
        list.Add('F');
        list.Add('F');
        list.Add('F');
        list.Add('W');

        finallist.Add(list);

        list = new ArrayList();
        list.Add('W');
        list.Add('P');
        list.Add('F');
        list.Add('W');
        list.Add('M');
        list.Add('F');
        list.Add('F');
        list.Add('W');

        finallist.Add(list);

        list = new ArrayList();
        list.Add('W');
        list.Add('F');
        list.Add('F');
        list.Add('F');
        list.Add('F');
        list.Add('F');
        list.Add('F');
        list.Add('W');

        finallist.Add(list);

        list = new ArrayList();
        list.Add('W');
        list.Add('F');
        list.Add('F');
        list.Add('F');
        list.Add('F');
        list.Add('F');
        list.Add('F');
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{


    public GameObject player;
    public GameObject wall;
    public GameObject movable;
    public GameObject horizontal;
    public GameObject vertical;
    public GameObject floor;
    public GameObject victory;
    public GameObject seethrough;
    public GameObject Cable;
    public GameObject Alimentation;
    public GameObject FloorCable;
    public GameObject ConveyerNorth;
    public GameObject ConveyerSouth;
    public GameObject ConveyerWest;
    public GameObject ConveyerEast;

    void Start()
    {
        if(GameObject.Find("Info")!=null)
        {
            string listtoinstantiate = GameObject.Find("Info").GetComponent<Info>().leveltoload;

            GenerateRoom(listtoinstantiate);
        }
        

    }

    void GenerateRoom(string list)
    {
        string[] listalllines=list.Split('%');

        for (int y = 0; y < listalllines.Length; y++)
        {
;           string[] listinside =listalllines[y].Split(',');
            for (int x = 0; x < listinside.Length; x++)
            {

                Vector2 position = new Vector2(x, -y);

                if(listinside[x].Equals("W")) //mur
                {
                    GameObject newwall =Instantiate(wall, position,Quaternion.identity);
                    newwall.transform.SetParent(GameObject.Find("Walls").transform);
                }
                if (listinside[x].Equals("P")) //joueur
                {
                    Instantiate(player, position, Quaternion.identity);
                    GameObject newfloor = Instantiate(floor, position, Quaternion.identity);
                    newfloor.transform.SetParent(GameObject.Find("Floors").transform);
                }
                if (listinside[x].Equals("M")) //objet qui bouge dans toutes les direction
                {
                    Instantiate(movable, position, Quaternion.identity);
                    GameObject newfloor = Instantiate(floor, position, Quaternion.identity);
                    newfloor.transform.SetParent(GameObject.Find("Floors").transform);
                }
                if (listinside[x].Equals("H")) //objet qui bouge que selon x
                {
                    Instantiate(horizontal, position, Quaternion.identity);
                    GameObject newfloor = Instantiate(floor, position, Quaternion.identity);
                    newfloor.transform.SetParent(GameObject.Find("Floors").transform);
                }
                if (listinside[x].Equals("V")) //objet qui bouge que selon y
                {
                    Instantiate(vertical, position, Quaternion.identity);
                    GameObject newfloor = Instantiate(floor, position, Quaternion.identity);
                    newfloor.transform.SetParent(GameObject.Find("Floors").transform);
                }
                if (listinside[x].Equals("F")) //sol
                {
                    GameObject newfloor = Instantiate(floor, position, Quaternion.identity);
                    newfloor.transform.SetParent(GameObject.Find("Floors").transform);
                }
                if (listinside[x].Equals("Vic")) // victory 
                {
                    Instantiate(victory, position, Quaternion.identity);

                }
                if (listinside[x].Equals("S")) // cube that objects can be pulled through
                {
                    Instantiate(seethrough, position, Quaternion.identity);
                    GameObject newfloor = Instantiate(floor, position, Quaternion.identity);
                    newfloor.transform.SetParent(GameObject.Find("Floors").transform);
                }
                if (listinside[x].Equals("C")) // Cable 
                {
                    Instantiate(Cable, position, Quaternion.identity);

                }
                if (listinside[x].Equals("A")) // Alimentation 
                {
                    Instantiate(Alimentation, position, Quaternion.identity);

                }
                if (listinside[x].Equals("FC")) // Floor Cable 
                {
                    Instantiate(FloorCable, position, Quaternion.identity);

                }
                if (listinside[x].Equals("CN")) // Conveyor North 
                {
                    Instantiate(ConveyerNorth, position, Quaternion.identity);

                }
                if (listinside[x].Equals("CS")) // Conveyor South 
                {
                    Instantiate(ConveyerSouth, position, Quaternion.identity);

                }
                if (listinside[x].Equals("CE")) // Conveyor East 
                {
                    Instantiate(ConveyerEast, position, Quaternion.identity);

                }
                if (listinside[x].Equals("CW")) // Conveyor West 
                {
                    Instantiate(ConveyerWest, position, Quaternion.identity);

                }


            }
        }

    }

}

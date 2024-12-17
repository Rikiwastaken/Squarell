using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class buttonmovement : MonoBehaviour
{

    private Vector2 bascoord;
    public Vector2 movementperframe;
    public float maxdistancefromorigin;
    private Vector2 direction;
    private int movedelay;

    // Start is called before the first frame update
    void Start()
    {
        bascoord = GetComponent<RectTransform>().position;
        direction = new Vector2((int)(Random.Range(0, 100) % 2), (int)(Random.Range(0, 100) % 2));
        if(direction.x==0)
        {
            direction.x = -1;
        }
        if(direction.y==0)
        {
            direction.y = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        movedelay++;
        if(movedelay>=2)
        {
            movedelay = 0;
            GetComponent<RectTransform>().position += new Vector3(direction.x * movementperframe.x, direction.y * movementperframe.y, 0);
            if (Vector2.Distance(GetComponent<RectTransform>().position, bascoord) > maxdistancefromorigin)
            {
                if (Mathf.Abs(GetComponent<RectTransform>().position.x - bascoord.x) > Mathf.Abs(GetComponent<RectTransform>().position.y - bascoord.y))
                {
                    direction.x = -direction.x;
                }
                else
                {
                    direction.y = -direction.y;
                }
            }
        }
        

    }
}

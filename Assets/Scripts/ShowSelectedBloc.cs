using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowSelectedBloc : MonoBehaviour
{

    public GameObject selectedsprite;

    public GameObject movable;
    public GameObject horizontal;
    public GameObject vertical;
    public GameObject FloorCable;
    public GameObject Alimentation;
    public GameObject PressurePlate;
    public GameObject Movablecable;
    public GameObject HorizontalMovableCable;
    public GameObject VerticalMovableCable;

    public TextMeshProUGUI text;

    private Vector3 initialscale;

    private void Start()
    {
        initialscale = transform.localScale;
    }

    private void FixedUpdate()
    {
        transform.localScale = initialscale;
        selectedsprite = GameObject.Find("PlayerCursor").GetComponent<PlayerCursorEditorScript>().objectlist[GameObject.Find("PlayerCursor").GetComponent<PlayerCursorEditorScript>().IndiceSelection];


        if(selectedsprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = selectedsprite.GetComponent<SpriteRenderer>().sprite;
            GetComponent<SpriteRenderer>().color = selectedsprite.GetComponent<SpriteRenderer>().color;

            if(selectedsprite == movable || selectedsprite == Movablecable)
            {
                DisableChildren();
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if(selectedsprite == vertical || selectedsprite == VerticalMovableCable)
            {
                DisableChildren();
                transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (selectedsprite == horizontal || selectedsprite == HorizontalMovableCable)
            {
                DisableChildren();
                transform.GetChild(2).gameObject.SetActive(true);
            }
            else if (selectedsprite == FloorCable)
            {
                DisableChildren();
                transform.GetChild(3).gameObject.SetActive(true);
            }
            else if (selectedsprite == Alimentation)
            {
                DisableChildren();
                transform.GetChild(4).gameObject.SetActive(true);
            }
            else if (selectedsprite == PressurePlate)
            {
                DisableChildren();
                transform.GetChild(5).gameObject.SetActive(true);
            }
            else
            {
                DisableChildren();
            }
            if (selectedsprite.GetComponent<ConveyorBelt>() != null)
            {
                
                if (selectedsprite.GetComponent<ConveyorBelt>().direction == 1)
                {
                    transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.z, transform.localScale.z);
                }
                if (selectedsprite.GetComponent<ConveyorBelt>().direction == 3)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.z, transform.localScale.z);
                }
            }

            text.text = selectedsprite.name;

        }
        else
        {
            text.text = "No Selection";
        }



       
        
    }

    void DisableChildren()
    {
        int i = transform.childCount-1;
        for(int j = 0; j < i; j++)
        {
            transform.GetChild(j).gameObject.SetActive(false);
        }
    }

}

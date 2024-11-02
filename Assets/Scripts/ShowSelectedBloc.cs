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

    public TextMeshProUGUI text;

    private void FixedUpdate()
    {

        selectedsprite = GameObject.Find("PlayerCursor").GetComponent<PlayerCursorEditorScript>().objectlist[GameObject.Find("PlayerCursor").GetComponent<PlayerCursorEditorScript>().IndiceSelection];


        if(selectedsprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = selectedsprite.GetComponent<SpriteRenderer>().sprite;
            GetComponent<SpriteRenderer>().color = selectedsprite.GetComponent<SpriteRenderer>().color;

            if(selectedsprite == movable)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild (2).gameObject.SetActive(false);
            }
            else if(selectedsprite == vertical)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(2).gameObject.SetActive(false);
            }
            else if (selectedsprite == horizontal)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
            }

            text.text = selectedsprite.name;

        }
        else
        {
            text.text = "No Selection";
        }



       
        
    }

}

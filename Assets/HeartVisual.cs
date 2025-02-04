using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartVisual : MonoBehaviour
{
    private PlayerMovement PM;
    private GameObject Heart1;
    private GameObject Heart2;
    private GameObject Heart3;
    private int HPold;

    private void Start()
    {
        PM = FindAnyObjectByType<PlayerMovement>();
        Heart1 = transform.GetChild(0).gameObject;
        Heart2 = transform.GetChild(1).gameObject;
        Heart3 = transform.GetChild(2).gameObject;
    }

    private void FixedUpdate()
    {
        if (PM == null)
        {
            PM = FindAnyObjectByType<PlayerMovement>();
        }
        else if (HPold!=PM.HP)
        {
            UpdateHearts();
            HPold = PM.HP;
        }
        
    }

    private void UpdateHearts()
    {

        

        Heart1.GetComponent<Image>().enabled = false;
        Heart1.transform.GetChild(0).gameObject.SetActive(true);
        Heart2.GetComponent<Image>().enabled = false;
        Heart2.transform.GetChild(0).gameObject.SetActive(true);
        Heart3.GetComponent<Image>().enabled = false;
        Heart3.transform.GetChild(0).gameObject.SetActive(true);
        if (PM.HP>=1)
        {
            Heart1.GetComponent<Image>().enabled = true;
            Heart1.transform.GetChild(0).gameObject.SetActive(false);
        }
        if (PM.HP >= 2)
        {
            Heart2.GetComponent<Image>().enabled = true;
            Heart2.transform.GetChild(0).gameObject.SetActive(false);
        }
        if (PM.HP >= 3)
        {
            Heart3.GetComponent<Image>().enabled = true;
            Heart3.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyGettter : MonoBehaviour
{
    private Info Info;

    private void Start()
    {
        Info = GameObject.Find("Info").GetComponent<Info>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<TextMeshProUGUI>().text=": "+ Info.HeldKeys;
    }
}

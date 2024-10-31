using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ErrorMessageScript : MonoBehaviour
{
    public TextMeshProUGUI MessageText;

    public string messagetodisplay;

    private void Start()
    {
        Time.timeScale = 0.0f;
    }

    private void Update()
    {
        MessageText.text = messagetodisplay;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1.0f;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{

    public string leveltoload;
    public string levelname;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullerScript : MonoBehaviour
{

    private bool grippressed;

    public GameObject target;

    public float direction; // -1 horizontal(x), 1 vertical(y); 

    public int range;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grippressed = GetComponent<PlayerMovement>().gripping;





    }
}

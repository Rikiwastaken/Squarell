using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCursorEditorScript : MonoBehaviour
{

    public InputActionAsset Inputcompo;

    private Vector2 movementinput;

    private Vector2 visioninput;

    public float gripinput;

    public bool gripping;

    private bool moved;

    private bool switchedactive;

    private bool pressedgrip;

    private GameObject cam;

    public float cammovespeed;

    public GameObject[] objectlist;

    public GameObject errormessage;

    public int IndiceSelection;

    public int minxplaced;

    public int minyplaced;

    public int maxxplaced;

    public int maxyplaced;

    private Transform ObjectsPlaced;

    private bool FirstPlaced = true;

    private string scenename;

    



    // Start is called before the first frame update
    void Start()
    {
        Inputcompo.FindAction("Move").performed += OnMove;
        Inputcompo.FindAction("Grip").performed += OnGrip;
        Inputcompo.FindAction("Movevision").performed += OnVision;
        cam = GameObject.Find("Main Camera");
        ObjectsPlaced = GameObject.Find("ObjectsPlaced").transform;

    }

    public void OnMove(InputAction.CallbackContext context)
    {

        movementinput = context.ReadValue<Vector2>();
    }

    public void OnVision(InputAction.CallbackContext context)
    {

        visioninput = context.ReadValue<Vector2>();
    }

    public void OnGrip(InputAction.CallbackContext context)
    {
        gripinput = context.ReadValue<float>();
    }

    private void FixedUpdate()
    {

        scenename = GameObject.Find("NameSelector").GetComponent<TMP_InputField>().text;

        if(Vector2.Distance(cam.transform.position, transform.position)>5)
        {
            cam.transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), cam.transform.position.z);
        }
        

        if (!Inputcompo.FindAction("Move").IsPressed())
        {
            movementinput = Vector2.zero;
            moved = false;
        }

        if (!Inputcompo.FindAction("Movevision").IsPressed())
        {
            visioninput = Vector2.zero;
            switchedactive = false;
        }

        if (!Inputcompo.FindAction("Grip").IsPressed())
        {
            gripinput = 0f;
            pressedgrip = false;
        }

        if (gripinput != 0f)
        {
            gripping = true;
        }
        else
        {
            gripping = false;
        }


        transform.position = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));

        if(!moved && movementinput != Vector2.zero)
        {
            moved = true;
            Vector3 movement = new Vector3(Mathf.Round(movementinput.x), Mathf.Round(movementinput.y),0);
            transform.position += movement;
        }

        ChangeIcon();


        if(gripping)
        {

            PlaceObject();

        }

       

    }

    void ChangeIcon()
    {
        if (!switchedactive && visioninput != Vector2.zero)
        {

            if (visioninput.x > 0.9f && visioninput.y == 0f || visioninput.y > 0.9f && visioninput.x == 0f)
            {
                if (IndiceSelection < objectlist.Count() - 1)
                {
                    IndiceSelection++;
                }
                else
                {
                    IndiceSelection = 0;
                }
                switchedactive = true;
            }

            if (visioninput.x < -0.9f && visioninput.y == 0f || visioninput.y < -0.9f && visioninput.x == 0f)
            {
                if (IndiceSelection > 0)
                {
                    IndiceSelection--;
                }
                else
                {
                    IndiceSelection = objectlist.Count() - 1;
                }
                switchedactive = true;
            }

        }
    }

    void PlaceObject()
    {
        if(!pressedgrip)
        {
            int nbchildren = ObjectsPlaced.childCount;

            for (int i = 0; i < nbchildren; i++)
            {
                Transform acttransform = ObjectsPlaced.GetChild(i);
                if (Mathf.Round(acttransform.position.x) == transform.position.x && Mathf.Round(acttransform.position.y) == transform.position.y)
                {
                    Destroy(acttransform.gameObject); //on détruit la transform qui se trouve là où on veut mettre un objet
                }
            }

            GameObject newObject = Instantiate(objectlist[IndiceSelection], transform.position, Quaternion.identity);
            if (newObject.GetComponent<MovableCube>() != null)
            {
                newObject.GetComponent<MovableCube>().enabled = false;
            }
            if (newObject.GetComponent<wallscript>() != null)
            {
                newObject.GetComponent<wallscript>().enabled = false;
            }
            if (newObject.GetComponent<PlayerMovement>() != null)
            {
                DeleteDuplicates(objectlist[IndiceSelection], transform.position);
                newObject.GetComponent<PlayerMovement>().enabled = false;
            }
            if (newObject.GetComponent<PullerScript>() != null)
            {
                newObject.GetComponent<PullerScript>().enabled = false;
            }
            //ajouter victory script

            newObject.transform.SetParent(ObjectsPlaced);

            if(FirstPlaced)
            {
                maxxplaced = (int)Mathf.Round(transform.position.x);
                maxyplaced = (int)Mathf.Round(transform.position.y);
                minxplaced = (int)Mathf.Round(transform.position.x);
                minyplaced = (int)Mathf.Round(transform.position.y);
                FirstPlaced = false;
            }


            if((int)Mathf.Round(transform.position.x)>maxxplaced)
            {
                maxxplaced = (int)Mathf.Round(transform.position.x);
            }

            if ((int)Mathf.Round(transform.position.y) > maxyplaced)
            {
                maxyplaced = (int)Mathf.Round(transform.position.y);
            }

            if ((int)Mathf.Round(transform.position.x) < minxplaced)
            {
                minxplaced = (int)Mathf.Round(transform.position.x);
            }

            if ((int)Mathf.Round(transform.position.y) < minyplaced)
            {
                minyplaced = (int)Mathf.Round(transform.position.y);
            }

            pressedgrip = true;
        }
    }

    void DeleteDuplicates(GameObject type, Vector2 coordinates)
    {
        int nbchildren = ObjectsPlaced.childCount;

        for (int i = 0; i < nbchildren; i++)
        {
            Transform acttransform = ObjectsPlaced.GetChild(i);
            if ((Mathf.Round(acttransform.position.x) != coordinates.x || Mathf.Round(acttransform.position.y) == coordinates.y) && acttransform.name.Contains(type.transform.name))
            {
                Vector2 newpos = acttransform.transform.position;
                Destroy(acttransform.gameObject); //on détruit la transform qui se trouve là où on veut mettre un objet
                Instantiate(objectlist[7], newpos, Quaternion.identity);
            }
        }
    }
    string GenerateSaveString()
    {

        int nbchildren = ObjectsPlaced.childCount;

        string SaveString = "";

        for (int y=minyplaced; y<=maxyplaced; y++)
        {
            for(int x=minxplaced; x<=maxxplaced; x++)
            {
                string next = "F";
                for (int i = 0; i < nbchildren; i++)
                {
                    Transform acttransform = ObjectsPlaced.GetChild(i);
                    if (Mathf.Round(acttransform.position.x) == x && Mathf.Round(acttransform.position.y) == y)
                    {
                        next = GetCorrespondingChar(acttransform);
                    }
                }
                SaveString += next;
            }
            if(y!=maxyplaced)
            {
                SaveString += "%";
            }
        }

        return SaveString;
    }

    void GenerateError(string message)
    {
        Transform CanvasParent = GameObject.Find("Canvas").transform;
        GameObject newerror = Instantiate(errormessage,Vector3.zero, Quaternion.identity);
        newerror.GetComponent<ErrorMessageScript>().messagetodisplay = message;
        newerror.transform.SetParent(CanvasParent);
        newerror.transform.localScale = Vector3.one;
    }

    public void SaveLevel()
    {

        if(scenename == "Name" || scenename =="")
        {
            GenerateError("You have to enter a name.");
        }
        else
        {
            if (!System.IO.Directory.Exists(Application.persistentDataPath + "/SavedLevels"))
            {
                System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/SavedLevels");
            }
            string Levelstring = GenerateSaveString();

            if (Levelstring == "")
            {
                GenerateError("Level is empty.");
            }
            else if (!Levelstring.Contains("P"))
            {
                GenerateError("You have to place a Player.");
            }
            else if (!Levelstring.Contains("I"))
            {
                GenerateError("You have to place a Victory Square.");
            }
            else
            {
                System.IO.File.WriteAllText(Application.persistentDataPath + "/SavedLevels/" + scenename + ".txt", Levelstring);
            }
        }
    }

    string GetCorrespondingChar(Transform target)
    {
        string name = target.name;

        string res = "F";

        if(name.Contains("Horizontal"))
        {
            res = "H";
        }
        else if (name.Contains("Vertical"))
        {
            res = "V";
        }
        else if (name.Contains("Movable"))
        {
            res = "M";
        }
        else if (name.Contains("Player"))
        {
            res = "P";
        }
        else if (name.Contains("Wall"))
        {
            res = "W";
        }
        else if (name.Contains("Victory"))
        {
            res = "I";
        }
        else if (name.Contains("See"))
        {
            res = "S";
        }
        return res;

    }

}


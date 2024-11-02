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

    public GameObject[] objectlist;

    public GameObject errormessage;

    public int IndiceSelection;

    public int minxplaced;

    public int minyplaced;

    public int maxxplaced;

    public int maxyplaced;

    private Transform ObjectsPlaced;

    private bool FirstPlaced = true;

    public string scenename;

    public GameObject[] Shortcuts;

    public Transform ShortcutsTransform;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        ObjectsPlaced = GameObject.Find("ObjectsPlaced").transform;
        InitializeInputs();


        if(GameObject.Find("Info").GetComponent<Info>().leveltoload != "")
        {
            GameObject.Find("NameSelector").GetComponent<TMP_InputField>().text = GameObject.Find("Info").GetComponent<Info>().levelname;
            GenerateRoomInEditor(GameObject.Find("Info").GetComponent<Info>().leveltoload);

        }
        

        

    }
    

    private void FixedUpdate()
    {

        scenename = GameObject.Find("NameSelector").GetComponent<TMP_InputField>().text;

        if(Vector2.Distance(cam.transform.position, transform.position)>10)
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

            PlaceObject(IndiceSelection,true,transform.position);

        }

       

    }


    private void InitializeInputs()
    {
        Inputcompo.FindAction("Move").performed += OnMove;
        Inputcompo.FindAction("Grip").performed += OnGrip;
        Inputcompo.FindAction("Movevision").performed += OnVision;
        Inputcompo.FindAction("Select0").performed += OnShortcut;
        Inputcompo.FindAction("Select1").performed += OnShortcut;
        Inputcompo.FindAction("Select2").performed += OnShortcut;
        Inputcompo.FindAction("Select3").performed += OnShortcut;
        Inputcompo.FindAction("Select4").performed += OnShortcut;
        Inputcompo.FindAction("Select5").performed += OnShortcut;
        Inputcompo.FindAction("Select6").performed += OnShortcut;
        Inputcompo.FindAction("Select7").performed += OnShortcut;
        Inputcompo.FindAction("Select8").performed += OnShortcut;
        Inputcompo.FindAction("Select9").performed += OnShortcut;


    }

    public void OnShortcut(InputAction.CallbackContext context)
    {
        string number = context.action.name[context.action.name.Length - 1]+"";
        int shortcutnumber = int.Parse(number);
        if(Shortcuts.Length > shortcutnumber)
        {
            for (int i = 0;i<objectlist.Length;i++)
            {
                if (objectlist[i]==Shortcuts[shortcutnumber])
                {
                    IndiceSelection = i;
                }
            }
        }
    }

    void GenerateRoomInEditor(string list)
    {
        string[] listalllines = list.Split('%');

        for (int y = 0; y < listalllines.Length; y++)
        {
            ; string listinside = listalllines[y];
            for (int x = 0; x < listinside.Length; x++)
            {

                Vector2 position = new Vector2(x, -y);

                if (listinside[x].Equals('W')) //mur
                {
                    PlaceObject(5, false,position);
                }
                if (listinside[x].Equals('P')) //joueur
                {
                    PlaceObject(0, false, position);
                }
                if (listinside[x].Equals('M')) //objet qui bouge dans toutes les direction
                {
                    PlaceObject(2, false, position);
                }
                if (listinside[x].Equals('H')) //objet qui bouge que selon x
                {
                    PlaceObject(3, false, position);
                }
                if (listinside[x].Equals('V')) //objet qui bouge que selon y
                {
                    PlaceObject(4, false, position);
                }
                if (listinside[x].Equals('F')) //sol
                {
                    PlaceObject(7, false, position);
                }
                if (listinside[x].Equals('I')) // victory 
                {
                    PlaceObject(1, false, position);

                }
                if (listinside[x].Equals('S')) // cube that objects can be pulled through
                {
                    PlaceObject(6, false, position);
                }


            }
        }

    }

    void ChangeShortCutIcons()
    {
        for(int i =0; i<Shortcuts.Length;i++)
        {

            if(ShortcutsTransform.GetChild(i).childCount>0)
            {
                Destroy(ShortcutsTransform.GetChild(i).GetChild(0).gameObject);
            }

            if (Shortcuts[i]!=null)
            {
                GameObject newObject = Instantiate(Shortcuts[i], ShortcutsTransform.GetChild(i).position, Quaternion.identity);
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
                    newObject.GetComponent<PlayerMovement>().enabled = false;
                }
                if (newObject.GetComponent<PullerScript>() != null)
                {
                    newObject.GetComponent<PullerScript>().enabled = false;
                }
                if(newObject.GetComponent<VictoryScript>() != null)
                {
                    newObject.GetComponent<VictoryScript>().enabled = false;
                }
                newObject.transform.SetParent(ShortcutsTransform.GetChild(i));
            }
        }
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

    void UpdateShortcuts(GameObject lastplaced)
    {
        GameObject[] newlist = new GameObject[10];
        newlist[0]=lastplaced;
        int Indice = 1;
        for(int i = 0; i < 10; i++)
        {
            if(Shortcuts.Length > i)
            {
                if (Shortcuts[i] != lastplaced && Indice <= 9)
                {
                    newlist[Indice] = Shortcuts[i];
                    Indice++;
                }
            }
        }
        Shortcuts = newlist;
        ChangeShortCutIcons();
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

    void PlaceObject(int Indice, bool updateshortcuts, Vector2 positiontoplace)
    {
        if(!pressedgrip || !updateshortcuts)
        {
            int nbchildren = ObjectsPlaced.childCount;

            for (int i = 0; i < nbchildren; i++)
            {
                Transform acttransform = ObjectsPlaced.GetChild(i);
                if (Mathf.Round(acttransform.position.x) == positiontoplace.x && Mathf.Round(acttransform.position.y) == positiontoplace.y)
                {
                    Destroy(acttransform.gameObject); //on détruit la transform qui se trouve là où on veut mettre un objet
                }
            }

            GameObject newObject = Instantiate(objectlist[Indice], positiontoplace, Quaternion.identity);
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
                DeleteDuplicates(objectlist[Indice], positiontoplace);
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
                maxxplaced = (int)Mathf.Round(positiontoplace.x);
                maxyplaced = (int)Mathf.Round(positiontoplace.y);
                minxplaced = (int)Mathf.Round(positiontoplace.x);
                minyplaced = (int)Mathf.Round(positiontoplace.y);
                FirstPlaced = false;
            }


            if((int)Mathf.Round(positiontoplace.x)>maxxplaced)
            {
                maxxplaced = (int)Mathf.Round(positiontoplace.x);
            }

            if ((int)Mathf.Round(positiontoplace.y) > maxyplaced)
            {
                maxyplaced = (int)Mathf.Round(positiontoplace.y);
            }

            if ((int)Mathf.Round(positiontoplace.x) < minxplaced)
            {
                minxplaced = (int)Mathf.Round(positiontoplace.x);
            }

            if ((int)Mathf.Round(positiontoplace.y) < minyplaced)
            {
                minyplaced = (int)Mathf.Round(positiontoplace.y);
            }
            if(updateshortcuts)
            {
                UpdateShortcuts(objectlist[Indice]);
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
                GameObject newfloor =Instantiate(objectlist[7], newpos, Quaternion.identity);
                newfloor.transform.SetParent(ObjectsPlaced);
            }
        }
    }
    public string GenerateSaveString()
    {

        int nbchildren = ObjectsPlaced.childCount;

        string SaveString = "";

        for (int y=maxyplaced; y>=minyplaced; y--)
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
            if(y!=minyplaced)
            {
                SaveString += "%";
            }
        }

        return SaveString;
    }

    public void GenerateError(string message, bool toMainMenu)
    {
        Transform CanvasParent = GameObject.Find("Canvas").transform;
        GameObject newerror = Instantiate(errormessage,Vector3.zero, Quaternion.identity);
        newerror.GetComponent<ErrorMessageScript>().messagetodisplay = message;
        newerror.transform.SetParent(CanvasParent);
        newerror.transform.localScale = Vector3.one;
        if(toMainMenu)
        {
            newerror.transform.GetChild(1).gameObject.SetActive(false);
            newerror.transform.GetChild(2).gameObject.SetActive(true);
            newerror.transform.GetChild(3).gameObject.SetActive(true);
        }
    }

    public bool SaveLevel()
    {
        bool worked = true;
        if(scenename == "Name" || scenename =="")
        {
            worked = false;
            GenerateError("You have to enter a name.",false);
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
                GenerateError("Level is empty.", false);
                worked = false;
            }
            else if (!Levelstring.Contains("P"))
            {
                GenerateError("You have to place a Player.", false);
                worked = false;
            }
            else if (!Levelstring.Contains("I"))
            {
                GenerateError("You have to place a Victory Square.", false);
                worked = false;
            }
            else
            {
                if (scenename[scenename.Length-1]=='t' && scenename[scenename.Length - 2]=='x' && scenename[scenename.Length - 3] == 't' && scenename[scenename.Length - 4] == '.')
                {
                    System.IO.File.WriteAllText(Application.persistentDataPath + "/SavedLevels/" + scenename, Levelstring);
                }
                else
                {
                    System.IO.File.WriteAllText(Application.persistentDataPath + "/SavedLevels/" + scenename + ".txt", Levelstring);
                }
                
            }
        }
        return worked;
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


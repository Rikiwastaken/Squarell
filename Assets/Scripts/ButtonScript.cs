using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{

    public string levelname;

    public void DestroyParent()
    {
        if(transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    public void NextPage()
    {
        GameObject.Find("LevelSelector").GetComponent<LevelSelectionScript>().nextpage();
    }

    public void PrevPage()
    {
        GameObject.Find("LevelSelector").GetComponent<LevelSelectionScript>().previouspage();
    }

    public void SaveScene()
    {
        GameObject.Find("PlayerCursor").GetComponent<PlayerCursorEditorScript>().SaveLevel();
    }

    public void LoadEditor()
    {
        SceneManager.LoadScene("LevelEditor");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }

    public void LoadMainMenuFromEditor()
    {
        GameObject.Find("PlayerCursor").GetComponent<PlayerCursorEditorScript>().GenerateError("Return to Main Menu ?",true);
    }


    public void LoadLevelSelector()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void selectlevel()
    {
        GameObject.Find("Info").GetComponent<Info>().levelname = levelname;
        GameObject.Find("Info").GetComponent<Info>().leveltoload = System.IO.File.ReadAllText(Application.persistentDataPath + "/SavedLevels/"+levelname);
        SceneManager.LoadScene("InGameScene");
    }

}

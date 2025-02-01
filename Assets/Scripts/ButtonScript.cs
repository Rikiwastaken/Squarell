using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class ButtonScript : MonoBehaviour
{

    public string levelname;

    public GameObject LevelDetailsPanel;

    private Info info;

    public void Start()
    {
        info = GameObject.Find("Info").GetComponent<Info>();
    }

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
        info.levelname = "";
        info.leveltoload = "";
        info.editorplaymode = false;
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
        info.levelname = levelname;
        info.leveltoload = System.IO.File.ReadAllText(Application.persistentDataPath + "/SavedLevels/"+levelname);
        transform.parent.parent.gameObject.SetActive(false);
        LevelDetailsPanel.SetActive(true);
        LevelDetailsPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = levelname;
    }

    public void PlaySelectedLevel()
    {
        SceneManager.LoadScene("InGameScene");
    }

    public void DeleteLevel()
    {
        System.IO.File.Delete(Application.persistentDataPath + "/SavedLevels/"+info.levelname);
        LoadMainMenu();
    }

    public void LoadMainMenuFromPlayMode()
    {
        if(info.editorplaymode)
        {
            SceneManager.LoadScene("LevelEditor");
        }
        else
        {
            info.levelname = "";
            info.leveltoload = "";
            info.editorplaymode = false;
            SceneManager.LoadScene("MainMenu");
        }
        Time.timeScale = 1.0f;
    }

    public void Replay()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("InGameScene");
    }

    public void PlayLevelFromEditor()
    {
        if(GameObject.Find("PlayerCursor").GetComponent<PlayerCursorEditorScript>().SaveLevel())
        {
            info.leveltoload = GameObject.Find("PlayerCursor").GetComponent<PlayerCursorEditorScript>().GenerateSaveString();
            info.levelname = GameObject.Find("PlayerCursor").GetComponent<PlayerCursorEditorScript>().scenename;
            info.editorplaymode = true;
            SceneManager.LoadScene("InGameScene");
        }
        
    }

    public void ImportFile()
    {
        string pathtofile = EditorUtility.OpenFilePanel("Select .txt Puzzle File.", Application.persistentDataPath + "/SavedLevels/", "txt");
        string filename = pathtofile.Split('/')[pathtofile.Split('/').Length-1];
        FileUtil.CopyFileOrDirectory(pathtofile, Application.persistentDataPath + "/SavedLevels/"+filename);
        SceneManager.LoadScene("LevelSelector");

    }

}

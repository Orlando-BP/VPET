using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.IO;

public class UIControlerMainMenuScene : MonoBehaviour
{

    //private readonly string path = "Assets/Resources/Saves/";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        
    }

    public void ButtonPlayPressed()
    {
        if (File.Exists(Application.persistentDataPath + "/"+ "Pet" + ".json"))
        {
            SceneManager.LoadScene("Juego");
        }
        else
        {
            SceneManager.LoadScene("SelectionInitial");
        }
        
    }
    //public void ButtonSettingsPressed()
    //{
    //    SceneManager.LoadScene("SettingsScene");
    //}
    public void ButtonAboutPressed()
    {
        SceneManager.LoadScene("AboutScene");
    }
}

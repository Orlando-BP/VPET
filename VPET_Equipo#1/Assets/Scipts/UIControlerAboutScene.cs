using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class UIControlerAboutScene : MonoBehaviour
{
    private DataBase dataBase;
    // Start is called before the first frame update
    private void Awake()
    {
        dataBase = new DataBase();
    }
    void Start()
    {
        
    }
    public void ButtonClosePressed()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void ButtonMuerte()
    {
        dataBase.DeleteData("Pet");
        SceneManager.LoadScene("MainMenuScene");
    }
    public void ButtonReencarnacion()
    {
        SceneManager.LoadScene("Juego");
    }
}

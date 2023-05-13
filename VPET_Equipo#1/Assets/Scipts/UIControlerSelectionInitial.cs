using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class UIControlerSelectionInitial : MonoBehaviour
{
    private DataBase dataBase;

    private void Awake()
    {
        dataBase = new DataBase();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void ButtonPet1Pressed()
    {
        dataBase.SaveData("Pet", petInicial(1));
        SceneManager.LoadScene("Juego");
    }
    public void ButtonPet2Pressed()
    {
        dataBase.SaveData("Pet", petInicial(5));
        SceneManager.LoadScene("Juego");
    }
    public void ButtonPet3Pressed()
    {
        dataBase.SaveData("Pet", petInicial(9));
        SceneManager.LoadScene("Juego");
    }

    public Pet petInicial(int eleccion)
    {
        Pet pet = new Pet(100, 100, 100,"s", 0, 0, 0, 0, eleccion,0);
        return pet;
    }
}

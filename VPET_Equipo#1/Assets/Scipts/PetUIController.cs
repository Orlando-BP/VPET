using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetUIController : MonoBehaviour
{
    public Image BarraHambre, BarraLimpieza, BarraEnergia;
    public GameObject MenuStats, MenuComida;

    //public AudioClip boton, alimentar, muerte, evolucion, reencarnacion;
    //private AudioSource sonido;
    public static PetUIController instance;
    private void Start()
    {
        //sonido = GetComponent<AudioSource>();
    }
    private void Awake()
    {
        MenuStats.SetActive(false);
        MenuComida.SetActive(false);
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("Mas de un PetUIController en la escena");
    }
    public void ActualizarBarra(int Hambre, int Energia, int Higiene)
    {
        BarraHambre.fillAmount = (float) Hambre / 100;
        BarraLimpieza.fillAmount = (float) Higiene / 100;
        BarraEnergia.fillAmount = (float) Energia / 100;
    }
    public void MostrarEntrenamientos()
    {
        if(MenuStats.activeSelf == true)
        {
            MenuStats.SetActive(false);
        }
        else
        {
            MenuStats.SetActive(true);
            MenuComida.SetActive(false);
        }
        //sonido.PlayOneShot(boton, 1.0f);
    }
    public void MostrarAlimentos()
    {
        if (MenuComida.activeSelf == true)
        {
            MenuComida.SetActive(false);
        }
        else
        {
            MenuComida.SetActive(true);
            MenuStats.SetActive(false);
        }
        //sonido.PlayOneShot(boton, 1.0f);
    }
}

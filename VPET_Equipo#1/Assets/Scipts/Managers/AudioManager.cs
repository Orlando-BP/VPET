using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip boton, alimentar, muerte, evolucion, reencarnacion;
    private AudioSource sonido;
    private void Start()
    {
        sonido = GetComponent<AudioSource>();
    }
    public void Sonido_boton()
    {
        sonido.PlayOneShot(boton);
    }
    public void Sonido_alimentar()
    {
        sonido.PlayOneShot(alimentar, 1);
    }
    public void Sonido_muerte()
    {
        sonido.PlayOneShot(muerte, 1);
    }
    public void Sonido_evolucion()
    {
        sonido.PlayOneShot(evolucion, 1);
    }
    public void Sonido_reencarnacion()
    {
        sonido.PlayOneShot(reencarnacion, 1);
    }
}

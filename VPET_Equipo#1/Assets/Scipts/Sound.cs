using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioSource;

    private void Start()
    {
        // Busca el AudioSource en el mismo objeto o en un objeto relacionado
        audioSource = GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(ReproducirSonido);
        // Asigna el método ReproducirSonido al evento onClick del botón
        
    }

    private void ReproducirSonido()
    {
        // Reproduce el sonido a través del AudioSource
        audioSource.Play();
    }

}

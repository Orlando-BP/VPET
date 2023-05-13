using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PetManager : MonoBehaviour
{
    public PetController pet;
    public NeedsController needController;
    public float petMoveTimer, originalpetMoveTimer;
    public Transform[] waypoints;

    public static PetManager instance;

    private void Awake()
    {
        originalpetMoveTimer = petMoveTimer;

        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("Mas de un petmanager en la escena");
    }
    private void Update()
    {
        if (petMoveTimer > 0)
        {
            petMoveTimer -= Time.deltaTime;

        }
        else
        {
            MovePetToRandomWaypoint();
            petMoveTimer = originalpetMoveTimer;
        }
    }

    private void MovePetToRandomWaypoint()
    {
        int RandomWaypoint = Random.Range(0, waypoints.Length);
        pet.Move(waypoints[RandomWaypoint].position);
    }
    public void Muerte()
    {
        SceneManager.LoadScene("Muerte");
        //Debug.Log("Se te murio el pokimon compa");
    }
}

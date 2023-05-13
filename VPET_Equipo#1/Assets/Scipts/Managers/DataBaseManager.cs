using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataBaseManager : MonoBehaviour
{
    public static DataBaseManager instance;
    private DataBase dataBase;
    public NeedsController needsController;
    private void Awake()
    {
        dataBase = new DataBase();
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("Mas de un DataBaseManager en la escena");
    }
    
    private void Update()
    {
        if(TimingManager.gameHour < 0)
        {
            Pet pet = new Pet(
                //needsController.lastTimeAlimentado.ToString(), 
                //needsController.lastTimeLimpiado.ToString(), 
                //needsController.lastTimeDescansdo.ToString(),
                needsController.Hambre,
                needsController.Energia,
                needsController.Higiene,"s",
                needsController.stat_1,
                needsController.stat_2,
                needsController.stat_3,
                needsController.tiempo,
                needsController.IDpet,
                needsController.reencarnacion
                );
            SavePet(pet);
        }
    }

    private void Start()
    {
        Pet pet = LoadPet();
        if (pet != null)
        {
            needsController.Initialize
                (
                    pet.Hambre,
                    pet.Energia,
                    pet.Higiene,
                    //needsController.HambreTickRate,
                    //needsController.EnergiaTickRate,
                    //needsController.HigieneTickRate,
                    5,0,1,
                    "s",
                    pet.stat_1,pet.stat_2,pet.stat_3,pet.tiempo,
                    pet.IDpet, pet.reencarnacion
                    );
        }
        
    }
    public void SavePet(Pet pet)
    {
        dataBase.SaveData("Pet",pet);
    }
    public Pet LoadPet()
    {
        Pet returnValue = null;
        dataBase.LoadData<Pet>("Pet", (pet) =>
        {
            returnValue = pet;
        });
        return returnValue;
    }
}

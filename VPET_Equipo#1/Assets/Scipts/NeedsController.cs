
//using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NeedsController : MonoBehaviour
{
    public int Hambre, Energia, Higiene, stat_1, stat_2, stat_3, tiempo, IDpet, reencarnacion;
    public int HambreTickRate, EnergiaTickRate, HigieneTickRate;
    //public DateTime lastTimeAlimentado,
    //    lastTimeLimpiado,
    //    lastTimeDescansdo;
    private SpriteRenderer rend;
    private Sprite pet1, pet2, pet3, pet4, pet5, pet6, pet7, pet8, pet9, pet10, pet11, pet12;

    public Text stat1_text, stat2_text, stat3_text;

    private DataBase dataBase;
    //public AudioClip boton, alimentar, muerte, evolucion, reencarnacion;
    //private AudioSource sonido;
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        SetSprites();
        //sonido = GetComponent<AudioSource>();
    }
    private void Awake()
    {
        Initialize(100,100,100,5,0,1,0,0,0,0,1,0);//cuando se crea la mascota por primera vez
        dataBase = new DataBase();
    }
    public void Initialize(int Hambre, int Energia, int Higiene,
        int HambreTickRate, int EnergiaTickRate, int HigieneTickRate,
        int stat_1, int stat_2, int stat_3, int tiempo, int IDpet, int reencarnacion)
    {
        //lastTimeAlimentado = DateTime.Now;
        //lastTimeLimpiado = DateTime.Now;
        //lastTimeDescansdo = DateTime.Now;
        this.Hambre = Hambre;
        this.Energia = Energia;
        this.Higiene = Higiene;
        this.HambreTickRate = HambreTickRate;
        this.EnergiaTickRate = EnergiaTickRate;
        this.HigieneTickRate = HigieneTickRate;
        this.stat_1 = stat_1;
        this.stat_2 = stat_2;
        this.stat_3 = stat_3;
        this.tiempo = tiempo;
        this.IDpet = IDpet;
        this.reencarnacion = reencarnacion;
        LoadSprite();
    }
    public void Initialize(int Hambre, int Energia, int Higiene,
        int HambreTickRate, int EnergiaTickRate, int HigieneTickRate,

        string lastTimeAlimentado,
        int stat_1, int stat_2, int stat_3, int tiempo, int IDpet, int reencarnacion)
    {
        //this.lastTimeAlimentado = lastTimeAlimentado;
        //this.lastTimeLimpiado = lastTimeLimpiado;
        //this.lastTimeDescansdo = lastTimeDescansdo;
        this.Hambre = Hambre;
        this.Energia = Energia;
        this.Higiene = Higiene;
        this.HambreTickRate = HambreTickRate;
        this.EnergiaTickRate = EnergiaTickRate;
        this.HigieneTickRate = HigieneTickRate;
        this.stat_1 = stat_1;
        this.stat_2 = stat_2;
        this.stat_3 = stat_3;
        this.tiempo = tiempo;
        this.IDpet = IDpet;
        this.reencarnacion = reencarnacion;
        LoadSprite();
        PetUIController.instance.ActualizarBarra(Hambre, Energia, Higiene);
        ActualizarStats();
    }
    private void Update()
    {
        if(TimingManager.gameHour < 0)
        {
            UpdateHambre(-HambreTickRate);
            UpdateEnergia(-EnergiaTickRate);
            UpdateHigiene(-HigieneTickRate);
            UpdateTiempo();
            PetUIController.instance.ActualizarBarra(Hambre, Energia, Higiene);
            ActualizarStats();
        }
    }

    public void UpdateHambre(int amount)
    {
        //if(Hambre + amount > Hambre)
        //{
        //    sonido.PlayOneShot(alimentar);
        //}
        Hambre += amount;
        //if(amount > 0)
        //{
        //    lastTimeAlimentado = DateTime.Now;
        //}
        if (Hambre <= 0) PetManager.instance.Muerte();
        else if (Hambre > 100) Hambre = 100;
        PetUIController.instance.ActualizarBarra(Hambre, Energia, Higiene);
    }
    public void UpdateEnergia(int amount)
    {
        if(Energia + amount > 0)
        {
            Energia += amount;
        }
        //if (amount > 0)
        //{
        //    lastTimeDescansdo = DateTime.Now;
        //}
        if (Energia <= 0) { PetManager.instance.Muerte(); Energia = 0; }
        if (Energia > 100) Energia = 100;
        PetUIController.instance.ActualizarBarra(Hambre, Energia, Higiene);
    }
    public void UpdateHigiene(int amount)
    {
        Higiene += amount;
        //if (amount > 0)
        //{
        //    lastTimeLimpiado = DateTime.Now;
        //}
        if (Higiene <= 0) PetManager.instance.Muerte();
        else if (Higiene > 100) Higiene = 100;
        PetUIController.instance.ActualizarBarra(Hambre, Energia, Higiene);
        //sonido.PlayOneShot(boton,1.0f);
    }
    public void UpdateTiempo()
    {
        tiempo++;
        if (tiempo == 50) Evolucion();
        if (tiempo >= 55) Reencarnacion();
    }
    public void UpdateStat_1(int amount)
    {
        if (Energia > 25)
        {
            stat_1 += amount;
            stat_1 += BonusStats();
        }
            
        else Energia = Energia - 5;
    }
    public void UpdateStat_2(int amount)
    {
        if (Energia > 25)
        {
            stat_2 += amount;
            stat_2 += BonusStats();
        }
        else Energia = Energia - 5;
    }
    public void UpdateStat_3(int amount)
    {
        if (Energia > 25)
        {
            stat_3 += amount;
            stat_3 += BonusStats();
        }
        else
            Energia = Energia - 5;
    }
    public void Evolucion()
    {
        //sonido.PlayOneShot(evolucion, 1.0f);
        tiempo = 50;
        if(IDpet == 1)
        {
            if(stat_1 > stat_2 && stat_1 > stat_3)//evolucion 1
            {
                IDpet = 2;
            }
            else if (stat_2 > stat_1 && stat_2 > stat_3)//evolucion 2
            {
                IDpet = 3;
            }
            else if (stat_3 > stat_2 && stat_3 > stat_1)//evolucion 3
            {
                IDpet = 4;
            }
            else//evolucion Default
            {
                IDpet = 2;
            }
        }
        if (IDpet == 5)
        {
            if (stat_1 > stat_2 && stat_1 > stat_3)//evolucion 1
            {
                IDpet = 6;
            }
            else if (stat_2 > stat_1 && stat_2 > stat_3)//evolucion 2
            {
                IDpet = 7;
            }
            else if (stat_3 > stat_2 && stat_3 > stat_1)//evolucion 3
            {
                IDpet = 8;
            }
            else//evolucion Default
            {
                IDpet = 6;
            }
        }
        if (IDpet == 9)
        {
            if (stat_1 > stat_2 && stat_1 > stat_3)//evolucion 1
            {
                IDpet = 10;
            }
            else if (stat_2 > stat_1 && stat_2 > stat_3)//evolucion 2
            {
                IDpet = 11;
            }
            else if (stat_3 > stat_2 && stat_3 > stat_1)//evolucion 3
            {
                IDpet = 12;
            }
            else//evolucion Default
            {
                IDpet = 10;
            }
        }

        LoadSprite();
    }
    public void Reencarnacion()
    {
        reencarnacion++;
        dataBase.SaveData("Pet", obtenerPet());
        SceneManager.LoadScene("Reencarnacion");
        //Debug.Log("Reencarnacion");
        //sonido.PlayOneShot(reencarnacion, 1.0f);
    }

    private Pet obtenerPet()
    {
        int IDpet_base = 0;
        if(IDpet == 2 || IDpet == 3 || IDpet == 4)
        {
            IDpet_base = 1;
        }
        if (IDpet == 6 || IDpet == 7 || IDpet == 8)
        {
            IDpet_base = 5;
        }
        if (IDpet == 10 || IDpet == 11 || IDpet == 12)
        {
            IDpet_base = 9;
        }
        //string date = DateTime.Now.ToString();
        Pet pet = new Pet(100, 100, 100,"s", 0, 0, 0, 0, IDpet_base, reencarnacion);
        return pet;
    }

    public void ActualizarStats()
    {
        stat1_text.text = stat_1.ToString();
        stat2_text.text = stat_2.ToString();
        stat3_text.text = stat_3.ToString();
    }
    public int BonusStats()
    {
        int bonus = 5;
        bonus= bonus * reencarnacion;
        return bonus;
    }
    private void SetSprites()
    {
        pet1 = Resources.Load<Sprite>("Sprites/Pokemons/charmander");
        pet2 = Resources.Load<Sprite>("Sprites/Pokemons/charizard");
        pet3 = Resources.Load<Sprite>("Sprites/Pokemons/dragonite");
        pet4 = Resources.Load<Sprite>("Sprites/Pokemons/drapion");
        pet5 = Resources.Load<Sprite>("Sprites/Pokemons/elekid");
        pet6 = Resources.Load<Sprite>("Sprites/Pokemons/electabuzz");
        pet7 = Resources.Load<Sprite>("Sprites/Pokemons/eelektross");
        pet8 = Resources.Load<Sprite>("Sprites/Pokemons/magmar");
        pet9 = Resources.Load<Sprite>("Sprites/Pokemons/munchlax");
        pet10 = Resources.Load<Sprite>("Sprites/Pokemons/snorlax");
        pet11 = Resources.Load<Sprite>("Sprites/Pokemons/regigigas");
        pet12 = Resources.Load<Sprite>("Sprites/Pokemons/tyranitar");
    }

    private void LoadSprite()
    {
        int ID = IDpet;
        rend = GetComponent<SpriteRenderer>();
        switch (ID)
        {
            case 1:
                rend.sprite = pet1;
                break;
            case 2:
                rend.sprite = pet2;
                break;
            case 3:
                rend.sprite = pet3;
                break;
            case 4:
                rend.sprite = pet4;
                break;
            case 5:
                rend.sprite = pet5;
                break;
            case 6:
                rend.sprite = pet6;
                break;
            case 7:
                rend.sprite = pet7;
                break;
            case 8:
                rend.sprite = pet8;
                break;
            case 9:
                rend.sprite = pet9;
                break;
            case 10:
                rend.sprite = pet10;
                break;
            case 11:
                rend.sprite = pet11;
                break;
            case 12:
                rend.sprite = pet12;
                break;
            default:
                Debug.Log("Error al cargar spriteID");
                break;
        }
    }
}

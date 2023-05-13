using System;
public class Pet 
{
    //public string lastTimeAlimentado, 
    //    lastTimeLimpiado, 
    //    lastTimeDescansdo;

    public int Hambre, Energia, Higiene, stat_1, stat_2, stat_3, tiempo, IDpet, reencarnacion;

    public Pet
        (
        int Hambre,
        int Energia,
        int Higiene,string s,
        int stat_1, int stat_2, int stat_3, int tiempo, int IDpet, int reencarnacion)
    {
        //this.lastTimeAlimentado = lastTimeAlimentado;
        //this.lastTimeLimpiado = lastTimeLimpiado;
        //this.lastTimeDescansdo = lastTimeDescansdo;
        this.Hambre = Hambre;
        this.Energia = Energia;
        this.Higiene = Higiene;

        this.stat_1 = stat_1;
        this.stat_2 = stat_2;
        this.stat_3 = stat_3;
        this.tiempo = tiempo;
        this.IDpet = IDpet;
        this.reencarnacion = reencarnacion;
    }
}

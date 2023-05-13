using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public static float gameHour;

    public  float hourLenght;

    private void Update()
    {
        if(gameHour <= 0)
        {
            gameHour = hourLenght;
        }
        else
        {
            gameHour -= Time.deltaTime;
        }
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.Assertions.Must;

public class Timer : MonoBehaviour
{
    public float remainingTime = 300f;
    public TMP_Text textTimer;
    public DeathManager playerDeath;

    private void Update()
    {
        if (remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);

            textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            remainingTime = 0;
            textTimer.text = "00:00";
            playerDeath.isDeath = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamage : MonoBehaviour
{
    [SerializeField] private PlayerStats player;
    [SerializeField] private Timer timer;

    private void Awake()
    {
        player = GameObject.Find("Character").GetComponent<PlayerStats>();
    }

    private void Update()
    {


        if (timer.timeValue <= 0)
        {
            player.RemoveDoubleDamage();
            OnTimerEnd();
        }
    }

    public void StartPowerUpTimer(float time)
    {
        timer.timeValue += time;
        player.DoubleDamage();
    }



    public void OnTimerEnd()
    {
        gameObject.SetActive(false);
    }

}

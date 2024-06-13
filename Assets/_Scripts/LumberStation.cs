using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberStation : MonoBehaviour
{
    [SerializeField] private int multipler;
    [SerializeField] private PlayerStats player;
    [SerializeField] private LogsUiLogic logs;

    void Start()
    {
        multipler = 1;
        player = GameObject.Find("Character").GetComponent<PlayerStats>();
        logs = GameObject.Find("Logs").GetComponent<LogsUiLogic>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SellWood()
    {
        player.AddMoney(player.SellAllWood() * multipler);
        player.RemoveAllWood();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SellWood();
        }
    }

}

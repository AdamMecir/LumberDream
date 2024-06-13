using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowShop : MonoBehaviour
{
    public float radius = 5f;
    public GameObject shopPanel;
    private bool isPlayerNear = false;
    private Transform player;
    [SerializeField] public TextMeshProUGUI moneyDisplay;
    [SerializeField] public Axe axe;
    [SerializeField] private LogsUiLogic logs;

    public bool isOpen;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        logs = GameObject.Find("Logs").GetComponent<LogsUiLogic>();

    }

    private void Update()
    {
        if (shopPanel.activeSelf == true)
        {
            isOpen = true;
        }
        else
            isOpen = false;

        moneyDisplay.text = axe.upgradePrice.ToString();
        if (Vector3.Distance(player.position, transform.position) <= radius)
        {
            if (!isPlayerNear)
            {
                isPlayerNear = true;
                shopPanel.SetActive(true);
                logs.Hide();
            }
        }
        else
        {
            if (isPlayerNear)
            {
                isPlayerNear = false;
                shopPanel.SetActive(false);
                logs.Show();
            }
        }
    }

}

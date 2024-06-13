using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogsUiLogic : MonoBehaviour
{
    [SerializeField] private PlayerStats player;
    [SerializeField] private GameObject empty;
    [SerializeField] private GameObject OakLogs;
    [SerializeField] private TextMeshProUGUI OakCountDisplay;
    [SerializeField] private GameObject BirchLogs;
    [SerializeField] private TextMeshProUGUI BirchCountDisplay;
    [SerializeField] private GameObject PineLogs;
    [SerializeField] private TextMeshProUGUI PineCountDisplay;
    [SerializeField] private GameObject SakuraLogs;
    [SerializeField] private TextMeshProUGUI SakuraCountDisplay;

    private bool isHide = false;


    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Character").GetComponent<PlayerStats>();
        Show();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isInventoryEmpty())
            empty.SetActive(true);

        if (player.GetWood(WoodType.Oak) != 0)
        {
            OakLogs.SetActive(true);
            OakCountDisplay.text = player.GetWood(WoodType.Oak).ToString();
            empty.SetActive(false);
        }
        else
        {
            OakLogs.SetActive(false);
        }

        if (player.GetWood(WoodType.Birch) != 0)
        {
            BirchLogs.SetActive(true);
            BirchCountDisplay.text = player.GetWood(WoodType.Birch).ToString();
            empty.SetActive(false);
        }
        else
        {
            BirchLogs.SetActive(false);
        }
        if (player.GetWood(WoodType.Pine) != 0)
        {
            PineLogs.SetActive(true);
            PineCountDisplay.text = player.GetWood(WoodType.Pine).ToString();
            empty.SetActive(false);
        }
        else
        {
            PineLogs.SetActive(false);
        }
        if (player.GetWood(WoodType.Sakura) != 0)
        {
            SakuraLogs.SetActive(true);
            SakuraCountDisplay.text = player.GetWood(WoodType.Sakura).ToString();
            empty.SetActive(false);
        }
        else
        {
            SakuraLogs.SetActive(false);
        }
    }


    public void onButtonPress()
    {
        if (isHide)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    public void Show()
    {
        animator.Play("Show");
        isHide = false;
    }

    public void Hide()
    {
        animator.Play("Hide");
        isHide = true;
    }
}

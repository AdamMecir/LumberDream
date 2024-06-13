using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int logs;
    [SerializeField] private GameObject handle;
    [SerializeField] public Axe axe;
    [SerializeField] public Animator animator;
    [SerializeField] private TextMeshProUGUI moneyDisplay;
    [SerializeField] private int money;
    [SerializeField] private int oakWood;
    [SerializeField] private int birchWood;
    [SerializeField] private int pineWood;
    [SerializeField] private int sakuraWood;


    // Start is called before the first frame update
    void Start()
    {
        oakWood = 0;
        birchWood = 0;
        pineWood = 0;
        sakuraWood = 0;

        axe = GameObject.Find("ChopArea").GetComponent<Axe>();
        SetChopSpeed(axe.GetChopSpeed());
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        moneyDisplay.text = money.ToString();

        if (axe.trees.Count == 0)
        {
            animator.SetBool("IsChoping", false);
        }
        else if (axe.trees.Count != 0)
        {
            animator.SetBool("IsChoping", true);
        }
    }

    public void DoubleDamage()
    {
        axe.SetDoubleDamage();
    }

    public void RemoveDoubleDamage()
    {
        axe.RemoveDoubleDamage();
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }


    public int GetMoney()
    {
        return money;
    }

    public void RemoveMoney(int amount)
    {
        money -= amount;
    }

    public void ChopTrees()
    {
        if (axe.trees != null)
            foreach (var tree in axe.trees.ToArray())
            {
                if (tree)
                {
                    tree.GetChop(axe.GetDamage());
                    Debug.Log(axe.trees.Count);
                }
                else
                {
                    axe.trees.Clear();
                }
            }
    }

    public void SetChopSpeed(float amount)
    {
        animator.SetFloat("ChopSpeed", amount);
    }


    public void AddWood(WoodType type, int amount)
    {
        switch (type)
        {
            case WoodType.Oak:
                oakWood += amount;
                break;
            case WoodType.Birch:
                birchWood += amount;
                break;
            case WoodType.Pine:
                pineWood += amount;
                break;
            case WoodType.Sakura:
                sakuraWood += amount;
                break;
            default:
                return;
        }
    }

    public int GetWood(WoodType type)
    {
        switch (type)
        {

            case WoodType.Oak:
                return oakWood;
            case WoodType.Birch:
                return birchWood;
            case WoodType.Pine:
                return pineWood;
            case WoodType.Sakura:
                return sakuraWood;
            default:
                return 0;
        }
    }

    public void RemoveWood(WoodType type, int amount)
    {
        switch (type)
        {
            case WoodType.Oak:
                oakWood -= amount;
                break;
            case WoodType.Birch:
                birchWood -= amount;
                break;
            case WoodType.Pine:
                pineWood -= amount;
                break;
            case WoodType.Sakura:
                sakuraWood -= amount;
                break;
            default:
                return;
        }
    }

    public void RemoveAllWood()
    {
        oakWood = 0;
        birchWood = 0;
        pineWood = 0;
        sakuraWood = 0;
    }

    public bool isInventoryEmpty()
    {
        if (oakWood == 0 && birchWood == 0 && pineWood == 0 && sakuraWood == 0)
            return true;

        return false;
    }

    public int SellAllWood()
    {
        int sum = 0;

        sum += oakWood;
        sum += birchWood * 2;
        sum += pineWood * 3;
        sum += sakuraWood * 4;

        return sum;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCstats : MonoBehaviour
{
    [SerializeField] private int logs;
    [SerializeField] private GameObject handle;
    [SerializeField] public NPCaxe axe;
    [SerializeField] public Animator animator;
    [SerializeField] private int money;
    [SerializeField] private int oakWood;
    [SerializeField] private int birchWood;
    [SerializeField] private int pineWood;
    [SerializeField] private int sakuraWood;


    void Start()
    {

        axe = GameObject.Find("ChopAreaNPC").GetComponent<NPCaxe>();
        SetChopSpeed(axe.GetChopSpeed());
  
    }

    void Update()
    {

        if (axe.trees.Count == 0)
        {
            animator.SetBool("IsChoping", false);
        }
        else if (axe.trees.Count != 0)
        {
            animator.SetBool("IsChoping", true);
        }
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
}

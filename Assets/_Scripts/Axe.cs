using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float chopSpeed;
    [SerializeField] private float sizeX;
    [SerializeField] private float sizeZ;
    [SerializeField] public List<TreeController> trees;
    [SerializeField] public int upgradePrice;
    [SerializeField] PlayerStats player;
    public BoxCollider coll;

    private void Start()
    {
        player = GameObject.Find("Character").GetComponent<PlayerStats>();
        coll = GetComponent<BoxCollider>();
        ResizeChopArea();
        upgradePrice = 100;
        //coll.enabled = false;
    }

    public void ResizeChopArea()
    {
        coll.size = new Vector3(sizeX, 0.30f, sizeZ);
    }

    public int GetDamage()
    {
        return damage;
    }

    public void SetDoubleDamage()
    {
        damage = damage * 2;
    }

    public void RemoveDoubleDamage()
    {
        damage = damage / 2;
    }

    public void Upgrade()
    {
        if (player.GetMoney() >= upgradePrice)
        {
            sizeX += 0.1f;
            sizeZ += 0.1f;
            chopSpeed = chopSpeed + 0.1f;
            damage++;
            ResizeChopArea();
            player.RemoveMoney(upgradePrice);
            upgradePrice = (upgradePrice * 2);
            player.SetChopSpeed(chopSpeed);
        }
    }

    public float GetChopSpeed()
    {
        return chopSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            if (!trees.Contains(other.GetComponent<TreeController>()))
                trees.Add(other.GetComponent<TreeController>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            trees.Remove(other.GetComponent<TreeController>());
        }
    }
}

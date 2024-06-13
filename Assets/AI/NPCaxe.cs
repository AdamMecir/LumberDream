using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCaxe : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float chopSpeed;
    [SerializeField] private float sizeX;
    [SerializeField] private float sizeZ;
    [SerializeField] public List<TreeController> trees;
    [SerializeField] NPCstats player;
    public BoxCollider coll;

    private void Start()
    {
        coll = GetComponent<BoxCollider>();
        ResizeChopArea();
    }

    public void ResizeChopArea()
    {
        coll.size = new Vector3(sizeX, 0.30f, sizeZ);
    }

    public int GetDamage()
    {
        return damage;
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

    private void OnTriggerStay(Collider other)
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

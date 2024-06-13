using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TycoonNodeController : MonoBehaviour
{
    public int multipler = 1;
    public bool isLocked = true;
    public TextMeshPro text;

    private int stackedResources = 0;
    private bool isFirstTime;



    // Start is called before the first frame update
    void Start()
    {
        isLocked = true;
    }


    // Update is called once per frame
    void Update()
    {   
        if(isLocked == true)
        {
            text.text = "Locked!";
        }
        else
        {
            text.text = stackedResources.ToString();
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (isFirstTime)
        {
            createTicker();
            isLocked = false;
        }

        if(other.tag == "Player" && isLocked == true)
        {
           other.GetComponent<PlayerController>().resources += stackedResources;
            stackedResources = 0;
        }
    }

    private void createTicker()
    {
        TimeTickHandler.OnTick += TimeTickHandler_OnTick;
    }
    private void TimeTickHandler_OnTick(object sender, TimeTickHandler.OnTickEventArgs e)
    {
        stackedResources += 1 * multipler;
    }
}

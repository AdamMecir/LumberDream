using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }


    [SerializeField] private GameObject nextLvlSetter;
    [SerializeField] private GameObject currentLvl;
    public GameObject stations;

    public int Lvl = 1;

    public int lvlTreesRemaining;


    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);

        else
            instance = this;

        nextLvlSetter = GameObject.Find(("Lvl" + (Lvl + 1)).ToString());
        currentLvl = GameObject.Find("Lvl" + (Lvl).ToString() + "Trees");
    }

    public void ChangeStationsPosition()
    {
        stations.transform.position = nextLvlSetter.transform.position;
        nextLvlSetter = GameObject.Find(("Lvl" + (Lvl + 1)).ToString());
    }

    private void Update()
    {
        lvlTreesRemaining = currentLvl.transform.childCount;

        if (lvlTreesRemaining == 0)
        {
            Lvl++;
            currentLvl = GameObject.Find("Lvl" + (Lvl).ToString() + "Trees");
            ChangeStationsPosition();
        }
    }

}

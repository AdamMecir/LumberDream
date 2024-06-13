using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WoodType
{
    Oak,
    Birch,
    Pine,
    Sakura,
    Hollow,
    Cactus,
}

public class TreeController : MonoBehaviour
{
    [SerializeField] private List<GameObject> states;
    [SerializeField] private GameObject state;
    [SerializeField] private int maxHealth;
    [SerializeField] private int health;
    [SerializeField] private int lvl;
    [SerializeField] PlayerStats player;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject WoodIndicator;
    [SerializeField] private GameObject UI;
    [SerializeField] private int curentIndex;

    public WoodType type;

    public float healthPercentage;

    // Start is called before the first frame update
    void Start()
    {
        curentIndex = 5;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            states.Add(gameObject.transform.GetChild(i).gameObject);
        }

        states.Reverse();


        state = states[states.Count - 1];

        if (state.activeSelf != true)
        {
            state.SetActive(true);
        }

        maxHealth = (states.Count) * lvl;
        health = maxHealth;

        UI = GameObject.Find("UI");
        animator = GetComponent<Animator>();
        player = GameObject.Find("Character").GetComponent<PlayerStats>();
    }

    public void GetChop(int amount)
    {
        if (health - amount <= 0)
        {
            if (health <= 0)
                animator.Play("Chop");
            GameObject indi = Instantiate(WoodIndicator, GetScreenPos(), Quaternion.identity, UI.transform);
            indi.GetComponent<WoodIndicatorLogic>().OnStart();
            indi.GetComponent<WoodIndicatorLogic>().SetImage(type);
            player.AddWood(type, health);
            ChopDown();
        }
        else
        {
            animator.Play("Chop");
            health -= amount;
            Debug.Log("Health: " + health + " Damage dealth: " + amount);
            healthPercentage = ((float)health / (float)maxHealth) * 100f;
            ChangeMesh(healthPercentage);
        }
    }

    private void ChangeMesh(float healthPercentage)
    {
        int index = Mathf.FloorToInt(healthPercentage / 20f);
        index = Mathf.Clamp(index, 0, states.Count - 1);

        GameObject indi = Instantiate(WoodIndicator, GetScreenPos(), Quaternion.identity, UI.transform);
        indi.GetComponent<WoodIndicatorLogic>().SetImage(type);
        indi.GetComponent<WoodIndicatorLogic>().OnStart();

        if (curentIndex != index)
            player.AddWood(type, curentIndex - index);




        state.SetActive(false);
        state = states[index];
        state.SetActive(true);
        curentIndex = index;
    }

    public Vector3 GetScreenPos()
    {
        Camera cam = Camera.main;
        Vector3 screenPos = cam.WorldToScreenPoint(transform.position);

        Vector3 newVector3 = new Vector3(screenPos.x, screenPos.y + 100f, 0);

        return newVector3;
    }


    private void ChopDown()
    {
        player.axe.trees.Remove(this);
        Destroy(transform.parent.gameObject, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
    }

}

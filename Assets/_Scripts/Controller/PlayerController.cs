using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public int resources = 0;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = resources.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Coliding with" + other.name);
    }

}

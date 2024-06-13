using UnityEngine;

public class NPCSpawnScript : MonoBehaviour
{
    public GameObject NPCPrefab;
    public GameObject market;


    public void SpawnNPC()
    {
        Vector3 spawnPosition = market.transform.position + new Vector3(1, 0, 0); 
        Instantiate(NPCPrefab, spawnPosition, market.transform.rotation);
    }
}

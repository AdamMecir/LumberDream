using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class NPCmovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public NavMeshAgent agent;
    public Transform targetTree;
    public List<Transform> trees;
    public string Lvltrees = "Lvl1Trees";
    public GameManager LvlManager;

    private void Start()
    {
        LvlManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        agent = GetComponent<NavMeshAgent>();
        trees = new List<Transform>();
        targetTree = FindNearestTree();
    }

    private void Update()
    {
        



        if (targetTree != null)
        {
            if (IsTouchingTargetTree())
            {
                Debug.Log("ja sa dotykam");
                animator.SetBool("IsMoving", false);
                agent.SetDestination(transform.position);

                if (!targetTree.gameObject.activeSelf)
                {
                    targetTree = FindNearestTree();
                }
            }
            else
            {
                animator.SetBool("IsMoving", true);
                agent.SetDestination(targetTree.position);
            }
        }
        else
        {  
            
        switch (LvlManager.Lvl)
        {
            case 1:
                Lvltrees = "Lvl1Trees";
              
                break;
            case 2:
                Lvltrees = "Lvl2Trees";

                break;
            case 3:
                Lvltrees = "Lvl3Trees";

                break;
            case 4:
                Lvltrees = "Lvl4Trees";

                break;
            case 5:
                    Lvltrees = "Lvl5Trees";
                break;
            case 6:
                    Lvltrees = "Lvl6Trees";
                    break;

                default:
                Debug.Log("Reached MAX LVL");
                break;
        }

            FindTreesWithTag(Lvltrees);
            targetTree = FindNearestTree();
        }
    }

    private bool IsTouchingTargetTree()
    {
        Collider treeCollider = targetTree.GetComponent<Collider>();
        Collider npcCollider = GetComponent<Collider>();

        if (npcCollider != null && treeCollider != null)
        {
            return npcCollider.bounds.Intersects(treeCollider.bounds);
        }
        else
        {
            return false;
        }
    }

    private void FindTreesWithTag(string tag)
    {
        trees.Clear();
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject obj in taggedObjects)
        {
            Transform[] treeChildren = obj.GetComponentsInChildren<Transform>();
            foreach (Transform child in treeChildren)
            {
                if (child.CompareTag("Tree"))
                {
                    trees.Add(child);
                }
            }
        }
    }

    private Transform FindNearestTree()
    {
        Transform nearestTree = null;
        float shortestDistance = Mathf.Infinity;

        foreach (Transform tree in trees)
        {
            NavMeshPath path = new NavMeshPath();
            if (NavMesh.CalculatePath(transform.position, tree.position, NavMesh.AllAreas, path))
            {
                if (path.status == NavMeshPathStatus.PathComplete)
                {
                    float distance = GetPathDistance(path);
                    if (distance < shortestDistance)
                    {
                        shortestDistance = distance;
                        nearestTree = tree;
                    }
                }
            }
        }

        return nearestTree;
    }

    private float GetPathDistance(NavMeshPath path)
    {
        float distance = 0f;
        if (path.corners.Length < 2)
            return distance;

        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            distance += Vector3.Distance(path.corners[i], path.corners[i + 1]);
        }

        return distance;
    }
}

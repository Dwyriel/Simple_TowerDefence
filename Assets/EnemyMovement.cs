using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;

    void Start()
    {
        
        StartCoroutine(PrintWaypoints());
        print(path.Count);
    }

    IEnumerator PrintWaypoints()
    {
        print("Starting Patrol");
        foreach (Waypoint waypoint in path)
        {
            print("Visiting " + waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        print("Ending Patrol");
    }

    void Update()
    {

    }
}

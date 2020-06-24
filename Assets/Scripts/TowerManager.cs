using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] int towerLimit = 4;
    [SerializeField] Tower towerPrefab;
    [SerializeField] GameObject towerParent;
    Queue<Tower> towers = new Queue<Tower>();
    public void addTower(Waypoint waypoint, Quaternion rotation)
    {
        if (towers.Count < towerLimit)
        {
            InstantiateNewTower(waypoint, rotation);
        }
        else
        {
            MoveExistingTower(waypoint);
        }
    }

    private void InstantiateNewTower(Waypoint waypoint, Quaternion rotation)
    {
        Tower instantiatedTower = Instantiate(towerPrefab, waypoint.transform.position, rotation);
        instantiatedTower.gameObject.transform.parent = towerParent.transform;
        towers.Enqueue(instantiatedTower);
        instantiatedTower.GetComponent<Tower>().SetBaseWaypoint(waypoint);
        waypoint.isPlaceable = false;
    }

    private void MoveExistingTower(Waypoint waypoint)
    {
        Tower dequeuedTower = towers.Dequeue();
        Waypoint prevWaypoint = dequeuedTower.GetBaseWaypoint();
        prevWaypoint.isPlaceable = true;
        dequeuedTower.transform.position = waypoint.transform.position;
        dequeuedTower.SetBaseWaypoint(waypoint);
        waypoint.isPlaceable = false;
        towers.Enqueue(dequeuedTower);
    }
}

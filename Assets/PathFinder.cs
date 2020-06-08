using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint start, finish;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
    Queue<Waypoint> queueWP = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;

    private void Start()
    {
        LoadBlocks();
        ColorWaypoints();
        PathFind();
        //ExploreNeighbours();
    }

    private void PathFind()
    {
        queueWP.Enqueue(start);
        while (queueWP.Count > 0 && isRunning)
        {
            searchCenter = queueWP.Dequeue();
            searchCenter.isExplored = true;
            StopSearchIfFound();
            ExploreNeighbours();
        }
        print("Finished pathfinding?");
    }

    private void StopSearchIfFound()
    {
        if (searchCenter == finish)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) return;
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoords = searchCenter.GetGridPos() + direction;
            try
            {
                Waypoint neighbour = grid[neighbourCoords];
                if (!neighbour.isExplored && !queueWP.Contains(neighbour))
                {
                    neighbour.isExplored = true;
                    queueWP.Enqueue(neighbour);
                    neighbour.exploredFrom = searchCenter;
                }
            }
            catch
            {

            }
        }
    }

    private void ColorWaypoints()
    {
        start.SetTopColor(Color.green);
        finish.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            if (grid.ContainsKey(waypoint.GetGridPos()))
            {
                Debug.LogWarning("Overlapping block " + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }
}

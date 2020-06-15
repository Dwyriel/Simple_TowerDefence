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
    List<Waypoint> path = new List<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            LoadBlocks();
            BreadthFirstSearch();
            CreatePath();
        }
        return path;
    }

    private void CreatePath()
    {
        path.Add(finish);
        Waypoint previousWaypoint = finish.exploredFrom;
        while (previousWaypoint != null)
        {
            path.Add(previousWaypoint);
            previousWaypoint = previousWaypoint.exploredFrom;
        }
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queueWP.Enqueue(start);
        while (queueWP.Count > 0 && isRunning)
        {
            searchCenter = queueWP.Dequeue();
            searchCenter.isExplored = true;
            StopSearchIfFound();
            ExploreNeighbours();
        }
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
            if (grid.ContainsKey(neighbourCoords))
            {
                Waypoint neighbour = grid[neighbourCoords];
                if (!neighbour.isExplored && !queueWP.Contains(neighbour))
                {
                    neighbour.isExplored = true;
                    queueWP.Enqueue(neighbour);
                    neighbour.exploredFrom = searchCenter;
                }
            }

        }
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

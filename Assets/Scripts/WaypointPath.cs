using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();

    public Vector3 GetWaypointPosition(int index)
    {
        if (waypoints == null || waypoints.Count == 0) return transform.position;
        return waypoints[index].position;
    }

    private void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Count < 2) 
        { 
            return; 
        }

        Gizmos.color = Color.cyan;

        for (int i = 0; i < waypoints.Count; i++)
        {
            if (waypoints[i] != null)
            {
                Gizmos.DrawWireSphere(waypoints[i].position, 0.5f);

                int nextIndex = (i + 1) % waypoints.Count;

                if (waypoints[nextIndex] != null)
                {
                    Gizmos.DrawLine(waypoints[i].position, waypoints[nextIndex].position);
                }
            }
        }
    }
}
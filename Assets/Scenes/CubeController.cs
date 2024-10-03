using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public List<Transform> waypoints; // Lista de waypoints en la escena.
    public float moveSpeed = 5f; // Velocidad de movimiento.
    public float minDistance = 0.1f; // Distancia mínima para considerar que se ha llegado al waypoint.

    private Transform targetWaypoint; // Waypoint objetivo actual.
    private int currentWaypointIndex = -1; // Índice del waypoint actual.

    void Start()
    {
        if (waypoints.Count == 0)
        {
            Debug.LogError("No hay waypoints asignados en la lista.");
            return;
        }
        SetNewRandomWaypoint();
    }

    void Update()
    {
        if (waypoints.Count == 0) return;

        // Movimiento hacia el waypoint.
        MoveTowardsWaypoint();

        // Comprueba si ha llegado al waypoint.
        if (Vector3.Distance(transform.position, targetWaypoint.position) < minDistance)
        {
            SetNewRandomWaypoint(); // Asigna un nuevo waypoint al azar.
        }
    }

    void MoveTowardsWaypoint()
    {
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        // Opcional: para que el objeto mire hacia el waypoint.
        transform.LookAt(targetWaypoint);
    }

    void SetNewRandomWaypoint()
    {
        // Selecciona un waypoint aleatorio diferente al actual.
        int newWaypointIndex = currentWaypointIndex;
        while (newWaypointIndex == currentWaypointIndex)
        {
            newWaypointIndex = Random.Range(0, waypoints.Count);
        }

        currentWaypointIndex = newWaypointIndex;
        targetWaypoint = waypoints[currentWaypointIndex];
    }
}

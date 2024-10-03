using Inputs;
using Soldier;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inputs
{
    public class AIInputAdapter : IInput
    {
        private List<Transform> _waypoints;
        private Transform _currentWaypoint;
        private Vector3 _botPosition;
        private float _arrivalThreshold = 5f;
        private SoldierMediator _soldierMediator;

        public AIInputAdapter(SoldierMediator soldierMediator)
        {
            _soldierMediator = soldierMediator;
            _waypoints = new List<Transform>(GameObject.FindGameObjectsWithTag("Waypoint").Select(g => g.transform));
            if(_waypoints.Count > 0)
            {
                _currentWaypoint = _waypoints[Random.Range(0, _waypoints.Count)];
                Debug.Log($"El objetivo del {soldierMediator.Id} es {_currentWaypoint.name}");
            }
            
        }
        public Vector3 GetDirection()
        {
            if (_currentWaypoint == null)
            {
                return Vector3.zero;
            }

            _botPosition = _soldierMediator.transform.position; // Obtener la posición del bot
            Vector3 direction = _currentWaypoint.position - _botPosition; // Calcular dirección

            // Verificar si hemos llegado al waypoint
            if (direction.magnitude < _arrivalThreshold)
            {
                // Seleccionar nuevo waypoint aleatorio
                _currentWaypoint = _waypoints[Random.Range(0, _waypoints.Count)];
                direction = _currentWaypoint.position - _botPosition; // Recalcular dirección
            }
            Debug.Log("Current direction: " + direction);
            return direction.normalized; // Retornar dirección normalizada
        }

        public bool IsFireActionPressed()
        {
            return false;
        }
    }
}


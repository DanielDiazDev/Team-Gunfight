using Battle.GameStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class GameStateController : MonoBehaviour
    {
        private IGameState _currentState;
        private void Start()
        {
            SwithState(new WeaponSelectionState(this));
        }
        private void Update()
        {
            _currentState.Update();
        }

        public void SwithState(IGameState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Start();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.GameStates
{
    public class WeaponSelectionState : IGameState
    {
        private GameStateController _gameStateController;
        private bool _weaponSelected;
        public WeaponSelectionState(GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
        }

        public void Start()
        {
            WeaponSelectionView.OnWeaponSelectedEvent += WeaponHasBeenSelected;
        }
        public void Update()
        {
            if( _weaponSelected )
            {
                _gameStateController.SwithState(new BattleState(_gameStateController));
                //Ver si hacer un command para empezar
            }
        }
        public void Exit()
        {
            _weaponSelected = false;
            WeaponSelectionView.OnWeaponSelectedEvent -= WeaponHasBeenSelected;
        }
        private void WeaponHasBeenSelected()
        {
            _weaponSelected = true;
        }
    }
}
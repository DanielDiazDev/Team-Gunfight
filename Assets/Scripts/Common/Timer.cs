using Soldier.Common;
using Soldier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Common
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float _time = 10;
        [SerializeField] private bool _timerIsRunning;

        public static Action<float> OnTimerUpdateEvent;
        private static Timer _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
           
        }
        public static Timer Instance()
        {
            return _instance;
        }
        public void StartTimer()
        {
            _timerIsRunning = true;
        }
        private void Update()
        {
            Debug.Log(_time);
            OnTimerUpdateEvent?.Invoke(_time);
            if (_timerIsRunning)
            {
                if(_time > 0)
                {
                    _time -= Time.deltaTime;
                }
                else
                {
                    Debug.Log("Tiempo acabado");
                    _time = 0;
                    _timerIsRunning = false;
                }
            }
        }
    }
}

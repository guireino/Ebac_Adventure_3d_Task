using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.StateMachine{

    public class StateMachine<T> where T : System.Enum{

        private StateBase _currentState;

        public Dictionary<T, StateBase> dictionaryState;

        public float timeToStartGame = 1f;

        public StateBase CurrentState{
            get{
                return _currentState;
            }
        }

        public void Init(){
            dictionaryState = new Dictionary<T, StateBase>();
        }

        public void RegisterState(T typeEnum, StateBase state){
            dictionaryState.Add(typeEnum, state);
        }

        public void SwitchState(T state){

            if (_currentState != null){
                _currentState.OnStateExit();
            }

            _currentState = dictionaryState[state];

            _currentState.OnStateEnter();
        }

        // Update is called once per frame
        public void Update(){

            if (_currentState != null){
                _currentState.OnStateStay();
            }
        }
    }
}
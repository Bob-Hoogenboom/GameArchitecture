using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Redcat
{
    public class RedcatPlayer : MonoBehaviour
    {
        private FSM.StateMachine _stateMachine;

        private Redcat.RedcatIdle _idleState;
        private Redcat.RedcatMove _moveState;


        private void Start()
        {
            _stateMachine = new FSM.StateMachine();

            _idleState = new Redcat.RedcatIdle();
            _moveState = new Redcat.RedcatMove();

            _stateMachine.SetState(_idleState);
        }


        private void Update()
        {
            _stateMachine.Update();

            if (Input.GetKeyDown(KeyCode.M))
            {
                _stateMachine.SetState(_moveState);
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                _stateMachine.SetState(_idleState);
            }
        }
    }
}


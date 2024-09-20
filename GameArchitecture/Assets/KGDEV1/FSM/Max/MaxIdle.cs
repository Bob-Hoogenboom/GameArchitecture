using FSMTest;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Max
{
    public class MaxIdle : AState
    {
        private MaxController _maxController;

        public override void Start(IStateRunner runner)
        {
            _maxController = runner as MaxController;
            base.Start(runner);
        }

        public override void Update(IStateRunner runner)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                onSwitch(_maxController._moveSate);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                onSwitch(_maxController._attackState);
            }
        }

        public override void Complete(IStateRunner runner)
        {
            Debug.Log("Switching to MoveState");
            base.Complete(runner);
        }
    }
}

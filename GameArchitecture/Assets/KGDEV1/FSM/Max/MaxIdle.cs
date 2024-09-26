using FSMTest;
using UnityEngine;

namespace Max
{
    public class MaxIdle : AState<MaxController>
    {
        public override void Start(MaxController runner)
        { 
            base.Start(runner);
        }

        public override void Update(MaxController runner)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                onSwitch(runner._moveSate);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                onSwitch(runner._attackState);
            }
        }

        public override void Complete(MaxController runner)
        {
            Debug.Log("Switching to MoveState");
            base.Complete(runner);
        }
    }
}

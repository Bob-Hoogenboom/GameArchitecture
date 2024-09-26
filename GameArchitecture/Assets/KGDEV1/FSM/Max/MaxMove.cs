using FSMTest;
using UnityEngine;

namespace Max
{
    public class MaxMove : AState<MaxController>
    {
        private float _moveSpeed = 20f;

        public override void Start(MaxController runner)
        {
            base.Start(runner);
        }

        public override void Update(MaxController runner)
        {
            Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            runner.rb.MovePosition(runner.transform.position + moveInput * Time.deltaTime * _moveSpeed);

            if (moveInput != Vector3.zero)
            {
                runner.rb.MovePosition(runner.transform.position + moveInput * Time.deltaTime * _moveSpeed);
            }

            if (moveInput == Vector3.zero)
            {
                onSwitch(runner._idleState);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                onSwitch(runner._attackState);
            }
        }

        public override void Complete(MaxController runner)
        {
            Debug.Log("Switching to idleState");
            base.Complete(runner);
        }
    }
}

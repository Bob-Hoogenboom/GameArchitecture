using FSMTest;
using UnityEngine;

namespace Max
{
    public class MaxMove : AState
    {
        private MaxController _maxController;
        private float _moveSpeed = 20f;

        public override void Start(IStateRunner runner)
        {
            _maxController = runner as MaxController;
            base.Start(runner);
        }

        public override void Update(IStateRunner runner)
        {
            Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            _maxController.rb.MovePosition(_maxController.transform.position + moveInput * Time.deltaTime * _moveSpeed);

            if (moveInput != Vector3.zero)
            {
                _maxController.rb.MovePosition(_maxController.transform.position + moveInput * Time.deltaTime * _moveSpeed);
            }

            if (moveInput == Vector3.zero)
            {
                onSwitch(_maxController._idleState);
            }
        }

        public override void Complete(IStateRunner runner)
        {
            Debug.Log("Switching to idleState");
            base.Complete(runner);
        }
    }
}

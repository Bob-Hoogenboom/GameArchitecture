using FSMTest;
using UnityEngine;

namespace Max
{
    public class MaxAttack : AState
    {
        private MaxController _maxController;

        public override void Start(IStateRunner runner)
        {
            _maxController = runner as MaxController;
            _maxController.pooler.SpawnFromPool("MagicBall", _maxController.pooler.transform.position, Quaternion.identity);
            base.Start(runner);
        }
        public override void Update(IStateRunner runner)
        {
            onSwitch(_maxController._idleState);
            base.Update(runner);
        }

        public override void Complete(IStateRunner runner)
        {
            Debug.Log("Switching to idleState");
            base.Complete(runner);
        }
    }
}
 
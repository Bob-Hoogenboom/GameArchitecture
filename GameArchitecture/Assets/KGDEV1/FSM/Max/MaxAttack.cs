using FSMTest;
using UnityEngine;

namespace Max
{
    public class MaxAttack : AState<MaxController>
    {
        public override void Start(MaxController runner)
        { 
            runner.pooler.SpawnFromPool("MagicBall", runner.pooler.transform.position, Quaternion.identity);
            base.Start(runner);
        }
        public override void Update(MaxController runner)
        {
            onSwitch(runner._idleState);
            base.Update(runner);
        }

        public override void Complete(MaxController runner)
        {
            Debug.Log("Switching to idleState");
            base.Complete(runner);
        }
    }
}
 
using FSMTest;
using ObjectPool;
using UnityEngine;

namespace Max
{
    public class MaxController : MonoBehaviour, IStateRunner, IPhysicsControllable
    {
        public StateMachine stateMachine;
        public Rigidbody rb;
        public ObjectPooler pooler;

        public ScratchPad sharedData => new ScratchPad();

        //pre instantiated states so we can just pool the states instead of initializing new ones on every switch
        public MaxIdle _idleState { get; private set; } = new MaxIdle();
        public MaxMove _moveSate { get; private set; } = new MaxMove();
        public MaxAttack _attackState { get; private set; } = new MaxAttack();


        private void Start()
        {
            stateMachine = new StateMachine(this);
            stateMachine.SetState(_idleState);
        }

        private void Update()
        {
            stateMachine?.Update();
        }

        private void FixedUpdate()
        {
            stateMachine?.FixedUpdate();
        }

        public void Drag(float x, float y, float z)
        {

        }

        public void Push(float x, float y, float z)
        {

        }
    }
}

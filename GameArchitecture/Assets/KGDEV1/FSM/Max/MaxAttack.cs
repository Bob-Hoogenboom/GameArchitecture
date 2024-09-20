using FSMTest;

namespace Max
{
    public class MaxAttack : AState
    {
        private MaxController _maxController;

        public override void Start(IStateRunner runner)
        {
            _maxController = runner as MaxController;
            base.Start(runner);
        }
    }
}

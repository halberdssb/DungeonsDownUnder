using UnityEngine;

namespace Player.States
{
    public class IgniteCooldownState : BaseState
    {
        public IgniteCooldownState(StateController player)
        {
            base.InitializeState(player);
        }
        public override void EnterState()
        {
            return;
        }

        public override void UpdateState()
        {
            return;
        }

        public override void FixedUpdateState()
        {
            return;
        }

        public override void ExitState()
        {
            return;
        }
    
        public override void InitializeState(StateController player)
        {
            this.player = player;
        }
    
        public override void OnCollisionEnter(Collision collider)
        {
            return;
        }
    
        public override void OnCollisionExit(Collision collider)
        {
            return;
        }
    
        public override void OnTriggerEnter(Collider other)
        {
            return;
        }
    
        public override void OnTriggerExit(Collider other)
        {
            return;
        }
    }
}
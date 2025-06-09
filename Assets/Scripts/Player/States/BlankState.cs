using UnityEngine;

/*
 * This state should NOT be implemented in state machine -
 * it only exists for easy copy/pasting abstract methods into newly created states
 *
 * Jeff Stevenson
 * 5.17.25
 */

namespace Player.States
{
    public class BlankState : BaseState
    {
        // constructor - need to override with name of class 
        public BlankState(StateController player)
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
    
        // Virtual methods - optional to include
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
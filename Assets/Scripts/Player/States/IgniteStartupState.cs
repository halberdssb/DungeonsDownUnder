using UnityEngine;

/*
 * Initial startup state when ignite is pressed that listens for ignite held or otherwise skips the charge state
 *
 * Jeff Stevenson
 * 5.25.25
 */

namespace Player.States
{
    public class IgniteStartupState : BaseState
    {
        private float startupTimer;
        
        public IgniteStartupState(StateController player)
        {
            base.InitializeState(player);
        }
        
        public override void EnterState()
        {
            startupTimer = player.data.igniteChargeActivationThreshold;
            return;
        }

        public override void UpdateState()
        {
            // switch to ignite air state if ignite is released
            if (!player.input.IsIgniteHeld)
            {
                player.SwitchState(player.igniteAirState);
                return;
            }
            // otherwise, increment timer and switch to ignite charge state once hold threshold is passed
            if (startupTimer <= 0)
            {
                player.SwitchState(player.igniteChargeState);
                return;
            }
            
            startupTimer -= Time.deltaTime;
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
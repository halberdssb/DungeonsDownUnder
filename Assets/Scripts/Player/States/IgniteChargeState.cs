using DG.Tweening;
using UnityEngine;

/*
 * Charging state the player enters if ignite is held to aim and launch (if ability is unlocked)
 *
 * Jeff Stevenson
 * 5.25.25
 */

namespace Player.States
{
    public class IgniteChargeState : BaseState
    {
        private float chargeTimer;
        private float previousGravityScale;

        private Tween zeroVelocityTween;
        
        public IgniteChargeState(StateController player)
        {
            base.InitializeState(player);
        }
        public override void EnterState()
        {
            // set charge timer to charge time to begin decrement
            chargeTimer = player.data.igniteChargeTime;
            
            // save gravity on entry and start tween to 0
            previousGravityScale = player.rb.gravityScale;
            player.rb.gravityScale = 0;

            Vector3 previousVelocity = player.rb.linearVelocity;
            DOVirtual.Vector3(previousVelocity, Vector3.zero, player.data.igniteChargeComeToStopTime, (velocityTweenVector) =>
            {
                player.rb.linearVelocity = velocityTweenVector;
            });
        }

        public override void UpdateState()
        {
            // exit if ignite is released or timer is up - if direction is held, launch in that direction
            if (!player.input.IsIgniteHeld || chargeTimer <= 0f)
            {
                if (player.input.DirectionalInput.sqrMagnitude > 0)
                {
                    // need to kill stop tween to prevent it from overriding force
                    zeroVelocityTween.Kill();
                    Vector3 launchForce = player.input.DirectionalInput * player.data.igniteLaunchForce;
                    player.rb.AddForce(launchForce, ForceMode2D.Impulse);
                }
                
                player.SwitchState(player.igniteAirState);
                return;
            }
            
            // insert code here to update ui visuals (radial fill timer ui & arrow showing direction to launch)
            chargeTimer -= Time.deltaTime;
        }

        public override void FixedUpdateState()
        {
            // use run function to come to stop while aiming
            //player.movement.Run(0f, 0f, player.data.igniteChargeDeceleration, player.data.igniteChargeDeceleration);
            //player.movement.ApplyFriction(player.data.airFriction);
            
        }

        public override void ExitState()
        {
            // reset gravity scale to previous
            if (zeroVelocityTween != null)
            {
                zeroVelocityTween.Kill();
            }
            player.rb.gravityScale = previousGravityScale;
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
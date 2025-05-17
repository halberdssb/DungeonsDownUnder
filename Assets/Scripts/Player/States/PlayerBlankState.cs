using UnityEngine;

/*
 * This state should NOT be implemented in state machine -
 * it only exists for easy copy/pasting abstract methods into newly created states
 *
 * Jeff Stevenson
 * 5.17.25
 */

public class PlayerBlankState : PlayerBaseState
{
    // constructor - need to override with name of class 
    public PlayerBlankState(PlayerStateController player)
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
    public override void InitializeState(PlayerStateController player)
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

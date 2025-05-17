using UnityEngine;

/*
 * Abstract state for player state machine that all states inherit from
 *
 * Jeff Stevenson
 * 5.17.25
 */

public abstract class PlayerBaseState
{
    protected PlayerStateController player;
    
    public virtual void InitializeState(PlayerStateController player)
    {
        this.player = player;
    }
    public abstract void EnterState();

    public abstract void UpdateState();
    
    public abstract void FixedUpdateState();
    
    public virtual void OnCollisionEnter(Collision collision)
    {
        return;
    }
    
    public virtual void OnCollisionExit(Collision collision)
    {
        return;
    }
    
    public virtual void OnTriggerEnter(Collider other)
    {
        return;
    }
    
    public virtual void OnTriggerExit(Collider other)
    {
        return;
    }
    
    public abstract void ExitState();
}

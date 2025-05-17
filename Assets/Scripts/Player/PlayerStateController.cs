using UnityEngine;

/*
 * Handles player states, including switching between states and calling proper state functions
 *
 * Jeff Stevenson
 * 5.17.25
 */

public class PlayerStateController : MonoBehaviour
{
    private PlayerGroundState GroundState;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateStates();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Instantiates all states with player reference
    private void CreateStates()
    {
        GroundState = new PlayerGroundState(this);
    }
}

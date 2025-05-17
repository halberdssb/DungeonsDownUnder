using UnityEngine;

/*
 * Handles calculations/physics for player movement abilities
 * Functions are called in appropriate player states
 *
 * Jeff Stevenson
 * 5.17.25
 */

namespace Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        private Data data;

        private Rigidbody2D rb;
    
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        
        // Moves the player laterally based on input
        public void Run(float moveInput, float speed, float accelerationValue, float decelerationValue)
        {
            // find velocity we want to reach - either max speed in direction or 0 to stop
            float targetVelocity = moveInput * speed;
        
            // calculate difference from desired velocity to current velocity
            float velocityDifference = targetVelocity - rb.linearVelocityX;
        
            float accelerationToUse = Mathf.Abs(targetVelocity) > 0.01f ? accelerationValue : decelerationValue; 
        
            // calculate movement force with accel/decel and velocity power, then add to rigidbody
            float movementForce = Mathf.Pow(Mathf.Abs(velocityDifference) * accelerationToUse, data.velocityPower);
            movementForce *= Mathf.Sign(velocityDifference);
        
            rb.AddForce(movementForce * Vector3.right, ForceMode2D.Force);
        }

        // Applies friction when the player stops moving
        public void ApplyFriction(float frictionValue)
        {
            // use either base friction value or velocity to stop depending on speed
            float frictionToUse = Mathf.Min(Mathf.Abs(rb.linearVelocityX), frictionValue);
            frictionToUse *= -Mathf.Sign(rb.linearVelocityX);
            
            // apply friction
            rb.AddForce(frictionToUse * Vector3.right, ForceMode2D.Impulse);
        }
    }
}
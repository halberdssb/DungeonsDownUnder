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
        private StateController player;

        [HideInInspector]
        public float timeInAir;
        [HideInInspector]
        public float timeHoldingJump;

        //[HideInInspector] 
        public bool jumpPressedWhileAirborne;
        [HideInInspector]
        public float baseGravity;
        [HideInInspector] 
        public bool isUsingFallGravity;
        
        private Rigidbody2D rb;

    
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            baseGravity = rb.gravityScale;
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
            float movementForce = Mathf.Pow(Mathf.Abs(velocityDifference) * accelerationToUse, player.data.velocityPower);
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
        
        // Handles the player jump ability
        public void Jump(float jumpForce)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            timeInAir = 0;
        }
        
        // Applies negative velocity force to player if jump released before apex of jump
        public void ApplyJumpCut()
        {
            float jumpCutForce = rb.linearVelocity.y * (1 - player.data.jumpCutMultiplier) * -1f;
            rb.AddForce(Vector3.up * jumpCutForce, ForceMode2D.Impulse);
        }
        
        // Checks if player is grounded
        public bool CheckIfGrounded()
        {
            // box is half height of player ECB - only add edge radius to y to ensure player is not sliding off edge of platform
            Vector3 boxSize = new Vector2(player.environmentCollisionBox.size.x, 0.1f);//new Vector2(player.environmentCollisionBox.size.x, (player.environmentCollisionBox.size.y + player.environmentCollisionBox.edgeRadius * 2) / 2);
            
            // center box so that it goes from center of player to bottom of ECB
            Vector3 overlapBoxCenter = player.transform.position;
            overlapBoxCenter.y -= (player.environmentCollisionBox.size.y / 2) + player.environmentCollisionBox.edgeRadius;
            overlapBoxCenter += (Vector3)player.environmentCollisionBox.offset;
            overlapBoxCenter.y += boxSize.y / 2;
            
            // do box cast and return based on results
            if (Physics2D.OverlapBox(overlapBoxCenter, boxSize, 0f, player.data.groundLayerMask) != null)
            {
                player.isGrounded = true;
            }
            else
            {
                player.isGrounded = false;
            }

            return player.isGrounded;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 boxSize = new Vector2(player.environmentCollisionBox.size.x, 0.1f);//new Vector2(player.environmentCollisionBox.size.x, (player.environmentCollisionBox.size.y + player.environmentCollisionBox.edgeRadius * 2) / 2);
            
            // center box so that it goes from center of player to bottom of ECB
            Vector3 overlapBoxCenter = player.transform.position;
            overlapBoxCenter.y -= (player.environmentCollisionBox.size.y / 2) + player.environmentCollisionBox.edgeRadius;
            overlapBoxCenter += (Vector3)player.environmentCollisionBox.offset;
            overlapBoxCenter.y += boxSize.y / 2;
            Gizmos.DrawWireCube(overlapBoxCenter, boxSize);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Methods
    {
        public static bool IsGrounded(Player_FSM player)
        {
            return Physics2D.Raycast(player.transform.position + player.colliderOffset, Vector2.down, player.groundLength, player.groundLayer) || Physics2D.Raycast(player.transform.position - player.colliderOffset, Vector2.down, player.groundLength, player.groundLayer);
        }
        public static void HorizontalMovement(Player_FSM player, float velocity, float limiter, Vector2 direction)
        {
            velocity *= -limiter;
            Vector2 finalSpeed = direction * velocity * Time.deltaTime;
            player.transform.Translate(finalSpeed);
        }
        public static void Jump(/*Player_FSM player, */Rigidbody2D rigidbody, float jumpSpeed, float limiter)
        {
            jumpSpeed *= limiter;
            rigidbody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
        public static void JumpImpulse(Player_FSM player, Rigidbody2D rigidbody, float jumpBoost, float limiter)
        {
            if (!player.usedImpulse)
            {
                jumpBoost *= limiter;
                rigidbody.AddForce(Vector2.up * jumpBoost, ForceMode2D.Impulse);
                player.usedImpulse = true;
            }
        }
        public static void Fall(Player_FSM player, Rigidbody2D rigidbody, float gravity, float fallMultiplier)
        {
            if (IsGrounded(player))
            {
                rigidbody.gravityScale = 0;
            }
            else
            {
                rigidbody.gravityScale = gravity;
                if (rigidbody.velocity.y < 0)
                {
                    rigidbody.gravityScale = gravity * fallMultiplier;
                }
                else if (Input.GetButton("Fire1"))
                {
                    rigidbody.gravityScale = gravity * (fallMultiplier * 2);
                }
                else if (rigidbody.velocity.y > 0 && !Input.GetKey(player.jump))
                {
                    rigidbody.gravityScale = gravity * (fallMultiplier / 2);
                }
            }
        }
        public static Collider2D CheckInteractable(Player_FSM player)
        {
            Beak beak = player.GetComponentInChildren<Beak>();
            return Physics2D.OverlapCircle(beak.transform.position, beak.detectionDistance, beak.interactableLayer);
        }

        public static void Interact(Player_FSM player, GameObject objectInteractable)
        {
            if (Input.GetKeyDown(player.peck))
            {
                objectInteractable.GetComponent<IInteractable>().InitInteraction(player.gameObject);
            }
            else if (Input.GetKeyUp(player.peck))
            {
                objectInteractable.GetComponent<IInteractable>().EndInteraction();
            }
        }
    }
}
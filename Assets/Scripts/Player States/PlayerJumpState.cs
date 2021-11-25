using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class PlayerJumpState : PlayerBaseState
{
    bool timer;
    public override void EnterState(Player_FSM player)
    {
        timer = false;
        if (player.isWeak) player.jumpPercentage = player.jumpPercentageWhenWeak;
        else player.jumpPercentage = 1;
        Methods.Jump(player.rb, player.jumpForce, player.jumpPercentage);
        player.StartCoroutine(CheckGround());
    }
    public override void Update(Player_FSM player)
    {
        Debug.Log(Methods.IsGrounded(player));
        if (Input.GetAxis("Horizontal") >= 0.001f || Input.GetAxis("Horizontal") <= -0.001) Methods.HorizontalMovement(player, player.movementSpeed, player.speedPercentage, -player.movementDirection);

        if (Input.GetButtonDown("Fire1") && !player.isWeak && !Methods.IsGrounded(player))
        {
            Methods.JumpImpulse(player, player.rb, player.jumpBoost, player.jumpPercentage);
        }
    }
    public override void LateUpdate(Player_FSM player)
    {
        if (timer)
        {
            if (Methods.IsGrounded(player) & (Input.GetAxis("Horizontal") >= 0.001 || Input.GetAxis("Horizontal") <= -0.001))
            {
                player.TransitionToState(player.walkState);
                player.usedImpulse = false;
            }
            else if (Methods.IsGrounded(player))
            {
                player.TransitionToState(player.idleState);
                player.usedImpulse = false;
            }
        }
    }
    public override void FixedUpdate(Player_FSM player)
    {

    }
    public override void OnCollisionEnter2D(Player_FSM player, Collision2D collision)
    {

    }
    public override void OnTriggerEnter2D(Player_FSM player, Collider2D collision)
    {

    }

    public IEnumerator CheckGround()
    {
        yield return new WaitForSeconds(0.05f);
        timer = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class PlayerWalkState : PlayerBaseState
{
    public override void EnterState(Player_FSM player)
    {
        Debug.Log("Enter Walk State");
        if (player.isWeak) player.speedPercentage = player.speedPercentageWhenWeak;
        else player.speedPercentage = 1;
        player.anim.SetInteger("AnimationPar", 1);
    }
    public override void Update(Player_FSM player)
    {
        if (Input.GetKeyDown(player.jump) && Methods.IsGrounded(player))
        {
            player.TransitionToState(player.jumpState);
        }
        if (Input.GetButtonDown("Fire1") && !player.isWeak && !Methods.IsGrounded(player))
        {
            Methods.JumpImpulse(player, player.rb, player.jumpBoost, player.jumpPercentage);
        }
        if (Methods.CheckInteractable(player))
        {
            Methods.Interact(player, player.interactableObject);
        }
    }
    public override void FixedUpdate(Player_FSM player)
    {
        if (Input.GetAxis("Horizontal") >= 0.001f || Input.GetAxis("Horizontal") <= -0.001) Methods.HorizontalMovement(player, player.movementSpeed, player.speedPercentage, -player.movementDirection);
        else
        {
            player.anim.SetInteger("AnimationPar", 0);
            player.TransitionToState(player.idleState);
        }
    }
    public override void OnCollisionEnter2D(Player_FSM player, Collision2D collision)
    {

    }
    public override void OnTriggerEnter2D(Player_FSM player, Collider2D collision)
    {

    }
    public override void LateUpdate(Player_FSM player)
    {

    }
}

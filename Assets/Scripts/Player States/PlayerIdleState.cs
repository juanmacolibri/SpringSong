using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(Player_FSM player)
    {
        Debug.Log("Enter Idle State");
    }
    public override void Update(Player_FSM player)
    {
        if (Input.GetKeyDown(player.jump) && Methods.IsGrounded(player))
        {
            player.TransitionToState(player.jumpState);
        }
        if (Methods.CheckInteractable(player))
        {
            Methods.Interact(player, player.interactableObject);
        }
    }
    public override void FixedUpdate(Player_FSM player)
    {
        if (Input.GetAxis("Horizontal") >= 0.001 || Input.GetAxis("Horizontal") <= -0.001)
        {
            player.TransitionToState(player.walkState);
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

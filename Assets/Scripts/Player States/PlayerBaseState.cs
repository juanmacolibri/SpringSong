using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(Player_FSM player);
    public abstract void Update(Player_FSM player);
    public abstract void FixedUpdate(Player_FSM player);
    public abstract void LateUpdate(Player_FSM player);
    public abstract void OnTriggerEnter2D(Player_FSM player, Collider2D collision);
    public abstract void OnCollisionEnter2D(Player_FSM player, Collision2D collision);

}

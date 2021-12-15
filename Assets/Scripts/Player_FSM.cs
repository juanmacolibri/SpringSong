using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using EnumLib;

public class Player_FSM : MonoBehaviour
{
    #region Player Variables

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator anim;
    public LayerMask groundLayer;
    public GameObject model3d;

    [Header("Horizontal Movement")]
    public float movementSpeed;
    [HideInInspector] public float speedPercentage;
    [Range(.0f, 1.0f)]
    public float speedPercentageWhenWeak;
    public Vector2 movementDirection;

    [Header("Vertical Movement")]
    public float jumpForce;
    public float jumpBoost;
    [HideInInspector] public float jumpPercentage;
    [Range(.0f, 1.0f)]
    public float jumpPercentageWhenWeak;

    [Header("Physics")]
    public float gravity;
    public float fallMultiplier;

    [Header("Collision")]
    public float groundLength;
    public Vector3 colliderOffset;

    [Header("Player Checks")]
    public bool usedImpulse;
    public bool isWeak;
    public bool isHiden;
    public bool isDead;

    [Header("Sprites")]
    public SpriteRenderer spriteRenderer;
    public GameObject pico;
    [HideInInspector] public bool turn = true;

    [Header("Inputs")]
    [HideInInspector] public KeyCode jump, peck;

    [Header("Around")]
    public GameObject interactableObject;

    #endregion

    #region State Machine Declarations

    private PlayerBaseState currentState;

    public readonly PlayerIdleState idleState = new PlayerIdleState();
    public readonly PlayerWalkState walkState = new PlayerWalkState();
    public readonly PlayerJumpState jumpState = new PlayerJumpState();
    public readonly PlayerGlideState glideState = new PlayerGlideState();
    public readonly PlayerHideState hideState = new PlayerHideState();
    public readonly PlayerBatheState batheState = new PlayerBatheState();
    public readonly PlayerDeathState deathState = new PlayerDeathState();

    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        TransitionToState(idleState);
    }
    private void Update()
    {
        currentState.Update(this);
        Methods.Fall(this, rb, gravity, fallMultiplier);

        if (!isDead && turn)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                //spriteRenderer.flipX = true;
                //pico.GetComponent<SpriteRenderer>().flipX = true;
                model3d.transform.localEulerAngles = new Vector3(model3d.transform.localEulerAngles.x, 90);
                pico.transform.localPosition = new Vector3(7.15f, 9.6f, transform.localPosition.z);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                //spriteRenderer.flipX = false;
                //pico.GetComponent<SpriteRenderer>().flipX = false;
                model3d.transform.localEulerAngles = new Vector3(model3d.transform.localEulerAngles.x, -90);
                pico.transform.localPosition = new Vector3(-7.15f, 9.6f, transform.localPosition.z);
            }
        }
    }
    private void FixedUpdate()
    {
        currentState.FixedUpdate(this);
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
    }
    private void LateUpdate()
    {
        currentState.LateUpdate(this);
    }
    public void TransitionToState(PlayerBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
        Debug.Log(currentState + " " + this.gameObject);
    }

    public void BirdFuckingDies()
    {
        isDead = true;
        StartCoroutine(RotateDie());
        TransitionToState(deathState);
    }

    IEnumerator RotateDie()
    {
        int n = 0;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<BoxCollider2D>().enabled = false;
        while (n < 180)
        {
            Vector3 rot = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(rot.x, rot.y, rot.z - 1);
            n++;
            yield return new WaitForSeconds(0.007f);
        }
    }

    public void SetInput(MoveType m, string s)
    {
        switch (m)
        {
            case MoveType.Jump:
                jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), s);
                break;
            case MoveType.Peck:
                peck = (KeyCode)System.Enum.Parse(typeof(KeyCode), s);
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);
    }
}

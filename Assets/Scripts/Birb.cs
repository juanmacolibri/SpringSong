using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumLib;

public class Birb : MonoBehaviour
{
    public GameObject beak;
    public bool turn = true, isWeak;
    [SerializeField] float verticalForce, horizontalForce, moveDelayMin, moveDelayMax;
    [SerializeField] GameObject interact;
    bool movePause, alive = true;
    public KeyCode jump;
    // dis de scrip for cute lil birb
    void Start()
    {
        
    }

    private void Update()
    {
        if (alive)
        {
            if (Input.GetKeyDown(jump))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 9);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                interact.GetComponent<IInteractable>().InitInteraction(transform.gameObject);
            }
            else if (interact && Input.GetKeyUp(KeyCode.E))
            {
                interact.GetComponent<IInteractable>().EndInteraction();
            }

        }
    }

    // updatin the cute birbhavior
    void FixedUpdate()
    {
        BirbMovement();
    }

    void BirbMovement()
    {
        if (!movePause && Input.GetAxis("Horizontal") != 0)
        {
            if (turn) { 
                if (Input.GetAxis("Horizontal") < 0)
                {
                    transform.localScale = new Vector2(-4.6f, transform.localScale.y);
                }
                else
                {
                transform.localScale = new Vector2(4.6f, transform.localScale.y);
                }
            }
            StartCoroutine(LilJump(Input.GetAxis("Horizontal")));
        }
    }

    IEnumerator LilJump(float inp)
    {
        movePause = true;
        GetComponent<Rigidbody2D>().velocity = new Vector2(verticalForce * inp, horizontalForce) * Time.deltaTime;
        yield return new WaitForSeconds(Random.Range(moveDelayMin, moveDelayMax));
        movePause = false;
    }

    public void birdfuckingdies()
    {
        alive = false;
        StartCoroutine(RotateDie());
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

        }
    }
}

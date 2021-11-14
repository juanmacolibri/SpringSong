using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumLib;

public class Birb : MonoBehaviour
{
    public GameObject beak;
    public bool turn = true;
    [SerializeField] float verticalForce, horizontalForce, moveDelayMin, moveDelayMax;
    [SerializeField] GameObject interact;
    bool movePause;
    public KeyCode jump;
    // dis de scrip for cute lil birb
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(jump))
        {
            Debug.Log("works");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 9);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Beak pressed");
            Debug.Log(interact.name);
            interact.GetComponent<IInteractable>().InitInteraction(transform.gameObject);
        }
        else if (interact && Input.GetKeyUp(KeyCode.E))
        {
            interact.GetComponent<IInteractable>().EndInteraction();
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

    public void SetInput(MoveType m, string s)
    {
        Debug.Log("Start learning");
        switch (m)
        {
            case MoveType.Jump:
                jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), s);
                Debug.Log("learning complete");
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformerControl : MonoBehaviour
{
    private Animator anim;
    private float h = 0;
    private bool jump = false;
    private CharacterController character;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        character = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();
        h = move.x;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jump = context.performed;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("h", Mathf.Abs(h));
    }

    private void FixedUpdate()
    {
        character.Move(h, jump);
        jump = false;
    }

    
}

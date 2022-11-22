using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;

    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoX = Input.GetAxisRaw("Horizontal");
        float movimientoY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;

        playerAnimator.SetFloat("Horizontal", movimientoX);
        playerAnimator.SetFloat("Vertical", movimientoY);
        playerAnimator.SetFloat("Speed", moveInput.sqrMagnitude);
        

    }

   private void FixedUpdate() 
    {
        playerRb.MovePosition(playerRb.position + moveInput * velocidadMovimiento * Time.fixedDeltaTime);
    }
}

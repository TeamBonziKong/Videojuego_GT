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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.velocidadMovimiento = 5;
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;

        }else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            this.velocidadMovimiento = 3;
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;
        }

        
        if (movimientoX != 0 || movimientoY != 0)
        {
            playerAnimator.SetFloat("UltimoX", movimientoX);
            playerAnimator.SetFloat("UltimoY", movimientoY);
        }

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

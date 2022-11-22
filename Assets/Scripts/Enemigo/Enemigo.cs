using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;

    public int rutina;
    public float cronometro;
    private Animator animator;
    public int direccion;
    public float speed_walk;
    public float speed_run;
    public GameObject target;
    public bool atacando;

    private void Update() {
        Comportamientos();
    }

    private void Start() 
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("Enemigo");
    }
    
    public void Comportamientos()
    {
        animator.SetBool("Caminar", false);
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            rutina = Random.Range(0,2);
            cronometro = 0;
        }
        switch (rutina)
        {
            case 0:
                animator.SetBool("Caminar2",false);
                break;
            case 1:
                direccion = Random.Range(0,2);
                rutina++;
                break;
            case 2:
                switch (direccion)
                {
                    case 0:
                        transform.rotation = Quaternion.Euler(0,0,0);
                        transform.Translate(Vector3.right *speed_walk *Time.deltaTime);
                        break;
                    case 1:
                        transform.rotation = Quaternion.Euler(0,180,0);
                        transform.Translate(Vector3.right *speed_walk *Time.deltaTime);
                        break;

                }
                animator.SetBool("Caminar2", true);
                break;
        }
    }

    public void TomarDanio(float danio)
    {
        vida -= danio;

        if (vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        animator.SetTrigger("Muerte");
    }
}

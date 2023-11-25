using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieRadar : MonoBehaviour
{
    private Transform target; // Arraste o objeto do jogador para cá no Inspector
    public float _range;
    public float speed;
    public float rotationSpeed;
    private Animator zombieAnim;
    public followPath path;
    public bool isntAttacking;

    void Start()
    {
        zombieAnim = GetComponent<Animator>();
    }

    void Update()
    {
        // Qualquer lógica de atualização que você precise
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Personagem")
        {
            path.movementSpeed=Random.Range(0.5f,1.5f);
            path.runner=true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Personagem")
        {
            if (isntAttacking == true)
            {
                zombieAnim.SetBool("runZombie", true);
                target = collision.gameObject.transform;
                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.LookRotation(target.position - transform.position),
                    rotationSpeed * Time.deltaTime);
                float dist = Vector3.Distance(target.position, transform.position);

                if (dist <= _range)
                {
                    transform.position = Vector3.MoveTowards(transform.position,
                        target.transform.position, speed);
                }
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Personagem")
        {
            zombieAnim.SetBool("runZombie", false);
            zombieAnim.SetBool("idleZombie", true);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0);
            path.movementSpeed=1;
            path.runner=false;
        }
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(1f);
        zombieAnim.SetBool("atackZombie", false);
        isntAttacking = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Personagem")
        {
            zombieAnim.SetBool("atackZombie", true);
            isntAttacking = false;
            StartCoroutine(Move());
        }
    }
}
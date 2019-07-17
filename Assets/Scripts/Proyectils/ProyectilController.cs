using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilController : MonoBehaviour
{
    public float Speed;
    public int Damage;
    public float TimeToDestoy = 10;

    private Vector3 direction;

    private void Update()
    {
        transform.position += Speed * Time.deltaTime * direction;
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
        transform.forward = direction;

        Destroy(gameObject, TimeToDestoy);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}

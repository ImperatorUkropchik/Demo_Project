using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAIContr : MonoBehaviour
{

    public Patrol patrol;
    public AIDestinationSetter aidestination;
    public GameObject target;
    public float agrDist = 3f;
    public float Hp = 3f;
    private void FixedUpdate()
    {
        float dist = Vector2.Distance(transform.position, target.transform.position);
        if (dist <= agrDist)
        {
            patrol.enabled = false;
            aidestination.enabled = true;
        }
        else
        {
            aidestination.enabled = false;
            patrol.enabled = true;
        }
        if (Hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Hp--;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().Damage(transform.position);
        }
    }

    private void Start()
    {

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class shadowMovement : MonoBehaviour
{
    public Transform user;
    private NavMeshAgent enemyAgent;
    private Animator enemyAnimator;
    private bool userDetected;
    private bool isFrozen = false;
    //private bool canDetectCollision = true;

    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Sphere"))
        {
            userDetected = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Sphere"))
        {
            userDetected = false;
        }
    }

    void Update()
    {
        if (userDetected && !isFrozen)
        {
            enemyAgent.isStopped = false;
            enemyAgent.destination = user.position;
            enemyAnimator.SetInteger("action", 1);
        }
        else
        {
            enemyAgent.isStopped = true;
            enemyAnimator.SetInteger("action", 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere") && !isFrozen)
        {
            StartCoroutine(FreezeEnemyForSeconds(3f));

        }
    }

    IEnumerator FreezeEnemyForSeconds(float seconds)
    {
        isFrozen = true;
        enemyAgent.isStopped = true;

        yield return new WaitForSeconds(seconds);

        isFrozen = false;
        enemyAgent.isStopped = false;
    }
}

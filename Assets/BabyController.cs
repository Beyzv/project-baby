using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BabyController : MonoBehaviour
{
    private NavMeshAgent baby;
    private Animator babyAnimator;


    Point current_point;

    bool performing = false;

   
    void Start()
    {
        baby = GetComponent<NavMeshAgent>();
        babyAnimator = GetComponent<Animator>();
        SelectPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(baby.velocity.magnitude > 0f)
        {
            babyAnimator.SetBool("Moving", true);
        }
        else
        {
            babyAnimator.SetBool("Moving", false);
        }


        if (baby.remainingDistance <= baby.stoppingDistance && !performing && !baby.pathPending)
        {
            /*if (current_point.type == Point.PointType.attackPoint)
            {
                StartCoroutine(Attack());
                
            }
            else if(current_point.type == Point.PointType.movePoint)
            {
                StartCoroutine(Wait());
            }
            else
            {
                SelectPoint();
                
            }*/
        }

    }


    IEnumerator Wait()
    {
        performing = true;
        yield return new WaitForSeconds(2);
        SelectPoint();
        performing = false;
    }

    IEnumerator Attack()
    {
        Debug.Log("SALDIRDIM");
        performing = true;
        babyAnimator.SetTrigger("Attack");
        current_point.TriggerAttack();
        yield return new WaitForSeconds(1);
        SelectPoint();
        performing = false;
    }


    void SelectPoint()
    {
            
        current_point = GameManager.instance.points[Random.Range(0, GameManager.instance.points.Length)];

        if(current_point.type != Point.PointType.attackPoint)
        {
            baby.SetDestination(current_point.transform.position);
        }
        else
        {
            baby.SetDestination(current_point.refPoint.position);
        }
            
    }
}

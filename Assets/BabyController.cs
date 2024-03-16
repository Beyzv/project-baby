using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BabyController : MonoBehaviour
{
    private NavMeshAgent baby;
    private Animator babyAnimator;

    public Point[] points;

    Point current_point;

    bool performing = false;

    //eþya zararý içim
  //  public furnitureHealth furnitureHealth;
   
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


        if (baby.remainingDistance <= baby.stoppingDistance && !performing)
        {
            if (current_point.type == Point.PointType.attackPoint)
            {
                StartCoroutine(Attack());
                
            }
            else
            {
                SelectPoint();
                
            }
        }

    }

    IEnumerator Attack()
    {
        performing = true;
        babyAnimator.SetTrigger("Attack");
        current_point.TriggerAttack();
        yield return new WaitForSeconds(1);
        SelectPoint();
        performing = false;
     //   furnitureHealth.TakeDamage(10);
    }


    void SelectPoint()
    {

            current_point = points[Random.Range(0, points.Length)];
            baby.SetDestination(current_point.transform.position);
    }
}

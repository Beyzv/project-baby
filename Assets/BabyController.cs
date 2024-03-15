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

    // Start is called before the first frame update
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


        if(Vector3.Distance(baby.transform.position,current_point.transform.position) < 1f && !performing)
        {
            if(current_point.type == Point.PointType.attackPoint)
            {
                StartCoroutine(Attack());
                Debug.Log("attacked selected");
            }
            else
            {
                SelectPoint();
                Debug.Log("point selected");
            }


            
        }

    }

    IEnumerator Attack()
    {
        performing = true;
        babyAnimator.SetTrigger("Attack");
        yield return new WaitForSeconds(2);
        SelectPoint();
        performing = false;
    }


    void SelectPoint()
    {

            current_point = points[Random.Range(0, points.Length)];
            baby.SetDestination(current_point.transform.position);
    }
}

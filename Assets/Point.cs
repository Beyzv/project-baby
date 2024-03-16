using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private Animator pointAnimator;
    private AudioSource audioSource;
    private GameObject pointObject;

    public Transform refPoint;


    public AudioClip attackSFX;
    public bool dropped = false;

   public enum PointType { 
        movePoint,
        attackPoint,
        speedPoint,
    
    };

    public PointType type;


    private void Start()
    {
        pointObject = gameObject;

        if(type != PointType.movePoint)
        {
            pointAnimator = pointObject.GetComponent<Animator>();
            audioSource = pointObject.GetComponent<AudioSource>();
            refPoint = transform.Find("RefPoint");
        }
       
        
    }
    public void TriggerAttack()
    {
        pointAnimator.SetBool("Dropped", true);
        dropped = true;
        audioSource.PlayOneShot(attackSFX);

    }

    public void ResetObject()
    {
        pointAnimator.SetBool("Dropped", false);
        dropped = false;
    }
}

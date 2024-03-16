using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private Animator pointAnimator;
    private AudioSource audioSource;

    public AudioClip attackSFX;
    public GameObject pointObject;
   public enum PointType { 
        movePoint,
        attackPoint,
        speedPoint,
    
    };

    public PointType type;


    private void Start()
    {
        pointAnimator = pointObject.GetComponent<Animator>();
        audioSource = pointObject.GetComponent<AudioSource>();
    }
    public void TriggerAttack()
    {
        pointAnimator.SetBool("Dropped", true);
        audioSource.PlayOneShot(attackSFX);

    }

    public void ResetObject()
    {
        pointAnimator.SetBool("Dropped", false);
    }
}

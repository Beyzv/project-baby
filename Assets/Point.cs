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

    public GameObject[] dropObjects;

   public enum PointType { 
        movePoint,
        attackPoint,
        speedPoint,
    
    };

    public PointType type;


    private void Awake()
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

        if(dropObjects.Length > 0)
        {
            foreach(GameObject go in dropObjects)
            {
                go.SetActive(true);
            }
        }

    }

    public void ResetObject()
    {
        pointAnimator.SetBool("Dropped", false);
        dropped = false;

        if (dropObjects.Length > 0)
        {
            foreach (GameObject go in dropObjects)
            {
                go.SetActive(false);
            }
        }
    }
}

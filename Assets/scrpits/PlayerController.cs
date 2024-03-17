using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float stepInterval = 1f;
    private float lastStepTime;
    private Vector2 movementData;
    public Rigidbody rb;
    public Animator animator;
    public AudioSource audioSource;


    public GameManager gm;

    public AudioClip catFixClip;

    public Point fixablePoint = null;

    public bool boosted;

    public GameObject boostParticles;

    [Serializable]
    public struct MaterialFootstepPair
    {
        public PhysicMaterial material;
        public AudioClip[] footstepSounds;
    }

    public MaterialFootstepPair[] materialFootstepPairs;
    public LayerMask raycastLayerMask;
    public GameObject groundCheck;

    public void OnMove(InputAction.CallbackContext context)
    {
        movementData = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Update()
    {
        if (fixablePoint != null && fixablePoint.dropped)
        {
            gm.fixButton.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                FixObject();
            }
            
        }
        else
        {
            gm.fixButton.gameObject.SetActive(false);
        }
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        lastStepTime = Time.time;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DropItem"))
        {
            fixablePoint = other.gameObject.GetComponent<Point>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("DropItem"))
        {
            fixablePoint = null;
        }
    }

 
    public void FixObject()
    {
        StartCoroutine(Fix());
        Score.scoreValue += 30;
    }

    IEnumerator Fix()
    {
        animator.SetFloat("Speed", 0f);
        animator.SetTrigger("Fix");
        audioSource.PlayOneShot(catFixClip);
        speed = 0;
        GetComponent<CapsuleCollider>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        fixablePoint.ResetObject();
        yield return new WaitForSeconds(1f);
        GetComponent<CapsuleCollider>().enabled = true;
        speed = 20;
    }

    public void MovePlayer()
    {
        Vector3 movement = new Vector3(movementData.x, 0f, movementData.y).normalized * speed;
        rb.velocity = movement;

        animator.SetFloat("Speed", movement.magnitude);

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
            Quaternion newRotation = Quaternion.Slerp(rb.rotation, targetRotation, 15 * Time.fixedDeltaTime);
            rb.MoveRotation(newRotation);


            RaycastHit hit;
            if (Physics.Raycast(groundCheck.transform.position, Vector3.down, out hit, Mathf.Infinity, raycastLayerMask))
            {
                PhysicMaterial hitMaterial = hit.collider.sharedMaterial;
                if (hitMaterial != null)
                {
                    foreach (var pair in materialFootstepPairs)
                    {
                        if (pair.material == hitMaterial)
                        {
                            if (Time.time - lastStepTime > stepInterval)
                            {
                                audioSource.PlayOneShot(pair.footstepSounds[UnityEngine.Random.Range(0, pair.footstepSounds.Length)]);
                                lastStepTime = Time.time;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
    public void ResetSpeed()
    {
        speed = 20;
        boosted = false;
        boostParticles.SetActive(false);
    }

    public void IncreaseSpeed(float boostSpeed)
    {
        speed = boostSpeed;
        boosted = true;
        boostParticles.SetActive(true);
        StartCoroutine(SpeedTimer());
    }


    IEnumerator SpeedTimer()
    {
        yield return new WaitForSeconds(5);
        ResetSpeed();
    }
}

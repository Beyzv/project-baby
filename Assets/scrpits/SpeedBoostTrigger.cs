using UnityEngine;
using System.Collections;

public class SpeedBoosterTrigger : MonoBehaviour
{
    public float boostSpeed = 2f; // H�z�n ka� kat art�r�laca��n� belirler


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            PlayerController playerController = other.GetComponent<PlayerController>(); 
            if (playerController != null && !playerController.boosted)
            {
                playerController.IncreaseSpeed(boostSpeed);
                Destroy(gameObject);
            }
        }
    }
}

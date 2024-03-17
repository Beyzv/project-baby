using UnityEngine;
using System.Collections;

public class SpeedBoosterTrigger : MonoBehaviour
{
    public float boostSpeed = 2f; // Hýzýn kaç kat artýrýlacaðýný belirler


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

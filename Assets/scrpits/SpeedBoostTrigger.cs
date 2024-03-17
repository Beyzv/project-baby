using UnityEngine;
using System.Collections;

public class SpeedBoosterTrigger : MonoBehaviour
{
    public float speedMultiplier = 2f; // H�z�n ka� kat art�r�laca��n� belirler
    public float duration = 5f; // H�z artt�r�c�n�n etkili olaca�� s�re

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered) 
        {
            PlayerController playerController = other.GetComponent<PlayerController>(); 
            if (playerController != null)
            {
                playerController.IncreaseSpeed(speedMultiplier); 
                isTriggered = true;
                StartCoroutine(DisableSpeedBoost(playerController)); 
            }
        }
    }

    IEnumerator DisableSpeedBoost(PlayerController playerController)
    {
        yield return new WaitForSeconds(duration); 
        playerController.ResetSpeed();  
        Destroy(gameObject); 
    }
}

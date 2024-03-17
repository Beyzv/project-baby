using UnityEngine;
using System.Collections;

public class SpeedBoosterTrigger : MonoBehaviour
{
    public float speedMultiplier = 2f; // Hýzýn kaç kat artýrýlacaðýný belirler
    public float duration = 5f; // Hýz arttýrýcýnýn etkili olacaðý süre

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

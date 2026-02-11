using UnityEngine;  
  
public class JumpBoostPowerup : MonoBehaviour  
{  
    public float boostMultiplier = 2f; // Makes jump twice as high  
    public float boostDuration = 5f;   // Lasts 5 seconds  
  
    void OnTriggerEnter(Collider other)  
    {  
        // Check if the player touched the powerup  
        PlayerMovement player = other.GetComponent<PlayerMovement>();  
        if (player != null)  
        {  
            StartCoroutine(BoostJump(player));  
            // Hide or destroy the powerup so it can't be picked up again  
            gameObject.SetActive(false);  
        }  
    }  
  
    System.Collections.IEnumerator BoostJump(PlayerMovement player)  
    {  
        float originalJump = player.jumpForce;  
        player.jumpForce *= boostMultiplier; // Boost jump  
  
        yield return new WaitForSeconds(boostDuration);  
  
        player.jumpForce = originalJump; // Reset jump to normal  
        Destroy(gameObject); // Remove the powerup from the scene  
    }  
}  

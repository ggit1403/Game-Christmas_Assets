using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isInvincible = false;
    void OnTriggerEnter2D (Collider2D other)
    {
        if (!isInvincible)
        {
            SetHeart.HP --;
            StartCoroutine(InvincibilityTimer(1f));
        }
        
    }
    IEnumerator InvincibilityTimer(float duration)
    {
        isInvincible = true;

        // Chờ đợi trong thời gian bất tử
        yield return new WaitForSeconds(duration);

        isInvincible = false; // Kết thúc thời gian bất tử
    }
}

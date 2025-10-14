using System.Runtime.CompilerServices;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    private float health = 100;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("HitEnemy");
            health -= 20;

            CheckHealth();
        }
    }
    
    private void CheckHealth()
    {
        if (health <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItems : MonoBehaviour
{
    // Config
    [SerializeField] int healedAmountPotion;
    [SerializeField] int value;
    [SerializeField] AudioClip coinSound;
    [SerializeField] AudioClip potionSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Potion"))
            {
                HealthManager health = collision.GetComponent<HealthManager>();
                if (health.GetCurrentHealth() < health.GetMaxHealth())
                {
                    AudioSource.PlayClipAtPoint(potionSound, FindObjectOfType<CameraFollow>().transform.position);
                    health.HealCharacter(healedAmountPotion);
                    Destroy(gameObject);
                }
                else
                    return;
            }
            if (gameObject.CompareTag("Coin"))
            {
                AudioSource.PlayClipAtPoint(coinSound, FindObjectOfType<CameraFollow>().transform.position);
                CoinManager.sharedInstance.AddMoney(value);
                Destroy(gameObject);
            }
        }
    }
}

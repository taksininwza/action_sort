using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int points = 1;
    bool isPickup = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isPickup == false)
        {
            isPickup = true;
            this.gameObject.SetActive(false);
            GameSession.Instance.addScore(points);
            Destroy(this.gameObject);
        }
    }
}

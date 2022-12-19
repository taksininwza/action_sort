using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int hp = 50;
    [SerializeField] int points = 5;
    [SerializeField] ParticleSystem hitParticleEffect;

    public int HP
    {
        get { return hp; }
    }
    void playHitParticleEffect()
    {
        if (hitParticleEffect == null)
        {
            return;
        }
        ParticleSystem effect = Instantiate(hitParticleEffect, this.transform.position, Quaternion.identity);
        var lifttime = effect.main.duration + effect.main.startLifetime.constantMax;
        Destroy(effect, lifttime);
    }
    public void TakeDamage(int damage)
    {
        shakeScreen();
        playHitParticleEffect();
        AudioPlayer.Instance.PlayHitAudio();
        hp -= damage;
        die();
    }

    private void die()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            if (this.tag == "Player")
            {
                AudioPlayer.Instance.PlayExplosionAudio();
                GameManager.Instance.LoadEndScene();
            }
            else
            {
                AudioPlayer.Instance.PlayEnemyExplosionAudio();
                ScoreManager.Instance.AddScore(points);
            }

        }
    }

    private void shakeScreen()
    {
        if (this.tag != "Player")
            return;
        ShakeScreen.Instance.ShakeCamera(2f, 0.2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            damageDealer.Hit(this);
        }
    }
}

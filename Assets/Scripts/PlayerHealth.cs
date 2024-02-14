using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // public int maxLifePoints = 3;
    // public int currentLifePoints;

    public bool isInvulnerable = false;
    public SpriteRenderer sr;
    public float invulnerableDuration = 3;
    public float invulnerableDelta = 0.15f;

    public PlayerData playerData;

    public HealthBar healthBar;

    public VoidEventChannel onPlayerDeath;
    
    private void Start(){
        playerData.currentLifePoints = playerData.maxLifePoints;
        // float amount = ((float) currentLifePoints / (float) maxLifePoints);
        // healthBar.Fill(amount);
    }
    
    public void Hurt(int damage)
    {
        if(!isInvulnerable){
            playerData.currentLifePoints = playerData.currentLifePoints - damage;
            if (playerData.currentLifePoints <= 0)
            {
            Die();
            }

            //float amount = ((float) playerData.currentLifePoints / (float) playerData.maxLifePoints);
            StartCoroutine(Invulnerable());
            //healthBar.Fill(amount);
        }
    }
    private void Die(){
        onPlayerDeath?.Raise();
        transform.Rotate(0, 0, 45f);
        foreach (Transform child in transform)
        {
            SpriteRenderer childSr = child.GetComponent<SpriteRenderer>();
            if(childSr != null){
                childSr.color = Color.red;
            }
        }
        
    }
    public IEnumerator Invulnerable()
        {
            isInvulnerable = true;

            WaitForSeconds invulnerableDeltaWait = new WaitForSeconds(invulnerableDelta);
    
            for (float i = 0; i <= invulnerableDuration; i += invulnerableDelta)
            {
                if (sr.color.a == 1)
                {
                    sr.color = new Color(1f, 1f, 1f, 0f); // Color.clear
                }
                else
                {
                    sr.color = Color.white;
                }
    
                yield return new WaitForSeconds(invulnerableDelta);
            }
    
            sr.color = Color.white;
            isInvulnerable = false;
        }
}
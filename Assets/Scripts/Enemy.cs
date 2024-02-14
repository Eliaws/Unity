using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxLifePoints = 2;
    public int currentLifePoints;

    // Start is called before the first frame update
    void Start()
    {
        currentLifePoints = maxLifePoints;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ContactPoint2D[] listContacts = new ContactPoint2D[1];
            other.GetContacts(listContacts);
            // Le joueur a sauté sur le dessus de l'ennemi
            if (listContacts[0].normal.y < -0.5f)
            {
                       currentLifePoints -= 1;
                if (currentLifePoints <= 0)
                {
                Destroy(gameObject);
                }
            }else{
                PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
                playerHealth.Hurt(1);
            }
        }
    }
}


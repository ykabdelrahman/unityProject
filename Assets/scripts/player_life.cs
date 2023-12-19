using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_life : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anime;
    private bool isAlive = true; // Flag to track player's life

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAlive && collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        isAlive = false; // Player is no longer alive
        rb.velocity = Vector2.zero; // Stop the player's movement
        anime.SetTrigger("death");
        Invoke("RestartLevle", 1f); // Restart level after 2 seconds (adjust the delay as needed)
    }

    private void RestartLevle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

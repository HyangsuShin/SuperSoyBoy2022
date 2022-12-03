using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public GameObject playerDeathPrefab;
    public AudioClip deathClip;
    public Sprite hitSprite;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // 1
        if (coll.transform.tag == "Player") //check colliding object has player
        {
            // 2
            var audioSource = GetComponent<AudioSource>();
            if (audioSource != null && deathClip != null)
            {
                audioSource.PlayOneShot(deathClip);
            }
            // 3
            Instantiate(playerDeathPrefab, coll.contacts[0].point,
            Quaternion.identity);
            spriteRenderer.sprite = hitSprite;
            // 4
            Destroy(coll.gameObject);
        }

        //Game Manager
        GameManager.instance.RestartLevel(1.25f);
    }
}

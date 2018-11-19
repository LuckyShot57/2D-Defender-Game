using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    SpriteRenderer playerRenderer;
    

    public Rigidbody2D lazer_prefab;
    public float lazer_speed = 500f;
    float shooting_cooldown = 0.0f;
    float last_shot = 0.0f;

    void fireLazer()
    {
    

        Rigidbody2D lazerprefab = Instantiate(lazer_prefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity) as Rigidbody2D;
        

        if (playerRenderer.flipX == true)
        {
            lazerprefab.GetComponent<Rigidbody2D>().AddForce(new Vector2(-lazer_speed, 0));
        }
        if (playerRenderer.flipX == false)
        {
            lazerprefab.GetComponent<Rigidbody2D>().AddForce(new Vector2(lazer_speed, 0));
        }
        last_shot = Time.time;
    }

    // Use this for initialization
    void Start()
    {
        playerRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            fireLazer();
        }

    }
}

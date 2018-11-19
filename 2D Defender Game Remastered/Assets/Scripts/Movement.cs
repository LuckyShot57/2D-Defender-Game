using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    float x = 0.0f;
    float y = 0.0f;
    public float bounding_size = 40.0f;
    Camera game_camera;
    SpriteRenderer playerRenderer;

    // Use this for initialization
    void Start()
    {
        game_camera = FindObjectOfType<Camera>();
        playerRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 ShipPosition = new Vector2(x, y);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            ShipPosition += new Vector2(x, 6) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            ShipPosition += new Vector2(x, -6) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            playerRenderer.flipX = true;
        }

            if (Input.GetKey(KeyCode.RightArrow))
        {
            
            playerRenderer.flipX = false;
        }



            Vector2 new_position = game_camera.WorldToScreenPoint((Vector2)transform.position + ShipPosition);

        if (new_position.x + bounding_size > game_camera.pixelWidth)
        {
            ShipPosition = new Vector2(x, y);
        }
        else if (new_position.x - bounding_size < 0)
        {
            ShipPosition = new Vector2(x, y);
        }


        if (new_position.y + bounding_size > game_camera.pixelHeight)
        {
            ShipPosition = new Vector2(x, y);
        }
        else if (new_position.y - bounding_size < 0)
        {
            ShipPosition = new Vector2(x, y);
        }

        transform.Translate(ShipPosition);

    }
}


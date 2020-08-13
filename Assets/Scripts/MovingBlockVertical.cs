using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockVertical : MonoBehaviour
{
    // Start is called before the first frame update
    public int distance = 20;
    public float blockSpeed = 4f;
    public float initialY;

    void Start()
    {
        initialY = this.transform.position.y; // initial position
    }
    void Update()
    {
        float position = Mathf.PingPong(Time.time * blockSpeed, distance);
        this.transform.position = new Vector2(this.transform.position.x, initialY + position);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.name.Contains("Player")) // if object is player
        {
            col.collider.transform.SetParent(transform); // makes block parent of player
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.name.Contains("Player")) // opposite
        {
            col.collider.transform.SetParent(null);
        }
    }
}

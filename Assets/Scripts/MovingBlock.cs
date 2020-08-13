using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    // Start is called before the first frame update
    public int distance = 20;
    public float blockSpeed = 4f;
    public float initialX;

    void Start() {
        initialX = this.transform.position.x;
    }
    void Update()
    {
        float position = Mathf.PingPong(Time.time*blockSpeed, distance);
        this.transform.position = new Vector2(initialX + position, this.transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.collider.name.Contains("Player")) {
            col.collider.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        if (col.collider.name.Contains("Player"))
        {
            col.collider.transform.SetParent(null);
        }
    }
}

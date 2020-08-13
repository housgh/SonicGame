using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using System;

public class enemy_movement : MonoBehaviour
{

    public Transform _trans; // enemy transform component
    public Vector2 _startingPos; // enemy starting position
    public float lastPos; // enemy's last position
    public bool dir = false; // enemy direction
    public SpriteRenderer r; // sprite renderer component
   

    void Start() { // on start
        _trans = GetComponent<Transform>(); // initialize components
        r = GetComponent<SpriteRenderer>();
        _startingPos = _trans.position; // set start position
        r.flipX = true; // flip enemy
    }
    void Update() {
        float p = Mathf.PingPong(Time.time, 7); // beshra7a ba3den
        if ((p - lastPos > 0 && dir) || (p - lastPos < 0 && !dir)) { // check if the direction of enemy has changed
            r.flipX = !r.flipX; //flip enemy
            dir = !dir; //change direction
        }
        _trans.position = new Vector3(_startingPos.x + p, _startingPos.y ); // change position
        lastPos = p; // change last position
    }

    

}

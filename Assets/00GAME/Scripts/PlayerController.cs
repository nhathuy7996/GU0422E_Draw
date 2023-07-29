using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rigi;
    Collider2D _colli;

    // Start is called before the first frame update
    void Start()
    {
        _rigi = this.GetComponent<Rigidbody2D>();
        _colli = this.GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void starGame() {
        _rigi.simulated = true;
        _colli.enabled = true;
    }
}

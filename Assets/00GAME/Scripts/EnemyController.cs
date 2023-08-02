using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D _rigi;
    [SerializeField] float _speed;
    [SerializeField] float _limitForce;
    // Start is called before the first frame update
    void Start()
    {
        _rigi = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rigi.velocity.magnitude > _limitForce)
        {
            _rigi.velocity = Vector2.zero;
            return;
        }

        Vector2 dir = GameController.Instant.Player.transform.position - this.transform.position;
        _rigi.AddForce( dir.normalized * _speed);  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rigi.velocity = Vector2.zero;

        Vector2 dir = GameController.Instant.Player.transform.position - this.transform.position;
        _rigi.AddForce(dir.normalized * -_speed * 200);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class LineController : MonoBehaviour
{
    LineRenderer _line;

    Vector2 _oldPos;

    EdgeCollider2D _collider;
    Rigidbody2D _rigi;

    List<Vector2> _listPos = new List<Vector2>();

    void Start()
    {
        _line = this.GetComponent<LineRenderer>();
        _collider = this.GetComponent<EdgeCollider2D>();
        _rigi = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) {
            _rigi.simulated = false;
            _rigi.velocity = Vector3.zero;
            this.transform.position = Vector3.zero;
            this.transform.rotation = new Quaternion();
            _collider.Reset();
            _collider.edgeRadius = _line.startWidth;
            _line.positionCount = 0;
            _oldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _listPos.Clear();
        }

        if (Input.GetMouseButton(0)) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(_oldPos, mousePos) < 0.2f)
                return;
            _line.positionCount++;

            _line.SetPosition(_line.positionCount-1, mousePos);
            _listPos.Add(mousePos);
            _oldPos = mousePos;
        }

        if (Input.GetMouseButtonUp(0)) {
            _collider.SetPoints(_listPos);
            _rigi.simulated = true;

            GameController.Instant.Player.starGame();
        }
        
    }

    
}

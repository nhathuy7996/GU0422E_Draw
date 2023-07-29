using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineController : MonoBehaviour
{
    LineRenderer _line;

    float radius;

    List<GameObject> Enemies = new List<GameObject>();
    GameObject firstEStuned;
    // Start is called before the first frame update
    void Start()
    {
        _line = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnStunEnemy() {
        if (Enemies.Count <= 0)
            return;

        float minDistance = Vector2.Distance(this.transform.position, Enemies[0].transform.position);
        GameObject nearestE = null;
        foreach (GameObject g in Enemies) {
            float tmpDistance = Vector2.Distance(this.transform.position, g.transform.position);
            if(minDistance < tmpDistance) {
                nearestE = g;
                minDistance = tmpDistance;
            }

            // g != 1stStunEnemy
            //if(g.gameObject.GetInstanceID())

        }

        if (minDistance > radius)
            return;

        //stun nearestE

        _line.positionCount = 2;
        _line.SetPosition(0, firstEStuned.transform.position);
        _line.SetPosition(1, nearestE.transform.position);

        _line.GetPosition(0);
    }
}

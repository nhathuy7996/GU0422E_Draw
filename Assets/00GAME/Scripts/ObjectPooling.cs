using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuynnLib;

public class ObjectPooling : Singleton<ObjectPooling>
{
    
    Dictionary<GameObject, List<GameObject>> _pools = new Dictionary<GameObject, List<GameObject>>();

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getObj(GameObject objKey) {
        List<GameObject> pool = new List<GameObject>();
        if (_pools.ContainsKey(objKey))
            pool = _pools[objKey];
        else
            _pools.Add(objKey,pool);

        foreach (GameObject g in pool) {
            if(g == null) {
                
                continue;
            }
            if (g.activeSelf)
                continue;

            return g;
        }

        GameObject g2 = Instantiate(objKey, Vector2.zero, Quaternion.identity);
        pool.Add(g2);
        g2.SetActive(false);
        return g2;
    }

}

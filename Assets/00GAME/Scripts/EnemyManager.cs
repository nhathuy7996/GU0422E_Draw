using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)] int _numberBee;
    [SerializeField] GameObject _prefabEnemy;
    // Start is called before the first frame update
    void Start()
    {
        Observer.Instant.AddListener(Observer.GAME_START, SpawEnemy);
    }

    private void OnDestroy()
    {
        Observer.Instant.RemoveListener(Observer.GAME_START, SpawEnemy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawEnemy(object data) {
       
        for (int i = 0; i< _numberBee; i++) {
            Vector2 pos = (Vector2)this.transform.position + Random.insideUnitCircle;

            
            GameObject e = ObjectPooling.Instant.getObj(_prefabEnemy);
            e.transform.position = pos;
            e.transform.SetParent(this.transform);
            e.SetActive(true);
        }
    }
}

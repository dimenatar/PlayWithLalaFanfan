using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WashingBubbleSpawner : MonoBehaviour
{
    [SerializeField] private int _poolCapacity;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _delay;
    private float _timer;

    private Queue<GameObject> _pool = new Queue<GameObject>();

    public Queue<GameObject> Pool => _pool;

    private void Update()
    {
        
    }

    private void Start()
    {
        _timer = _delay;
        for (int i = 0; i < _poolCapacity; i++)
        {
            GameObject bubble = Instantiate(_prefab);
            bubble.GetComponent<WashingBubble>().OnDisabledBubble += (GameObject washingBubble) => _pool.Enqueue(washingBubble);
            _pool.Enqueue(bubble);
            bubble.SetActive(false);
        }
    }

    public void SpawnBubble(Vector3 position)
    {
        _timer += Time.deltaTime;
        if (_timer >= _delay)
        {
            GameObject washingBubble = _pool.Dequeue();
            washingBubble.transform.position = position;
            washingBubble.transform.localScale = Vector3.one;
            washingBubble.SetActive(true);
            _timer = 0;
        }
    }
}

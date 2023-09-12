using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] Transform player;
    [SerializeField] float pos = 5;

    void Start()
    {
        
    }

    void Update()
    {
        if(player.position.x > pos)
        {
            GameObject obstacle = obstacles[Random.Range(0, obstacles.Count)];
            Instantiate(obstacle, new Vector2(player.position.x + 10, obstacle.transform.position.y), Quaternion.identity);
            pos += 10;
        }
    }
}

using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private int objectSpawnCount = 30;
    [SerializeField]
    private GameObject[] prefabArray;

    [SerializeField] private Transform[] spawnPointArray;
    private int currentObjectCount = 0; // 현재까지 생성한 오브젝트 개수
    private float objectSpawnTime = 0.0f;

    private void Update()
    {
        if (currentObjectCount + 1 > objectSpawnCount)
        {
            return;
        }

        // 원하는 시간마다 오브젝트를 생성하기 위한 시간 변수 연산
        objectSpawnTime += Time.deltaTime;
        
        // 0.5초에 한번씩 실행
        if ( objectSpawnTime >= 0.5f)
        {
            int prefabIndex = Random.Range(0, prefabArray.Length);
            int spawnIndex = Random.Range(0, spawnPointArray.Length);

            Vector3 position = spawnPointArray[spawnIndex].position;
            GameObject clone = Instantiate(prefabArray[prefabIndex], position, Quaternion.identity);
            
            Vector3 moveDirection = (spawnIndex == 0 ? Vector3.right : Vector3.left);
            clone.GetComponent<Movement2D>().Setup(moveDirection);

            currentObjectCount ++;
            objectSpawnTime = 0.0f;
        }
    }
}

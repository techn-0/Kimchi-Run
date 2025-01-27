using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    public float minSPawnDelay;
    public float maxSPawnDelay;

    [Header("References")]
    public GameObject[] gameObjects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        Invoke("Spawn", Random.Range(minSPawnDelay, maxSPawnDelay));
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void Spawn()
    {
        var randomObject = gameObjects[Random.Range(0, gameObjects.Length)];
        Instantiate(randomObject, transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(minSPawnDelay, maxSPawnDelay)); // 인복은 일정 시간 후 호출
    }
}

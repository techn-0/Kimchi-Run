using UnityEngine;
using UnityEngine.UIElements;

public class Mover : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {transform.position += Vector3.left * moveSpeed * GameManager.Instance.CalculateGameSpeed() * Time.deltaTime;
        
    }
}

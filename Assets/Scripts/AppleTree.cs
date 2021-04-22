using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour
{

    public GameObject applePrefab;
    public float speed = 5f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.001f;
    public float secondsBetweenAppleDrops = 2f;
        
    void Start()
    {
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
    }


    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }

}
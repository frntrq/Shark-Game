using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackwards : MonoBehaviour
{
    public float speed = 3.0f;
    private float zDestroy = -10.0f;
    public float multiplier = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime * multiplier);

        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }        
    }
}

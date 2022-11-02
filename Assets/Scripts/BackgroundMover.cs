using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField]
    private int speed;
    [SerializeField]
    private float resetPos;

    private Vector3 startPos;



    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
        if (transform.position.x < resetPos)
        {
            transform.position = startPos;
        }
    }
}

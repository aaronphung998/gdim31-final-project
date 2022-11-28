using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField]
    private float speedFactor;
    [SerializeField]
    private float resetPos;

    private Vector3 startPos;
    private bool isMoving;



    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        isMoving = true;
        GameStateManager.OnGameOver += StopMoving;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.position += new Vector3(-speedFactor * GameStateManager.ObstacleSpeed * Time.deltaTime, 0f, 0f);
        }
        if (transform.position.x < resetPos)
        {
            transform.position = startPos;
        }
    }

    public void OnDestroy()
    {
        GameStateManager.OnGameOver -= StopMoving;
    }

    void StopMoving()
    {
        isMoving = false;
    }
}

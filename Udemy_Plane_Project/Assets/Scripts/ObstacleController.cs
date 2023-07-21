using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private float veloc;
    [SerializeField]
    private GameController gameC;

    void Start()
    {
        gameC = FindObjectOfType<GameController>();

        if (gameObject != null)
        {
            Destroy(gameObject, 5f);
        }
    }


    void Update()
    {
        veloc = 3f + gameC.ReturnLvl();
        transform.position += Vector3.left * Time.deltaTime * veloc;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D airplaneRB;
    private float veloc = 5f;
    [SerializeField]
    private GameObject puff;

    void Start()
    {
        airplaneRB = gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Subir();
        LimitVeloc();
        LimitArea();
    }

    private void LimitArea()
    {
        if (transform.position.y > 5f || transform.position.y < -5f)
        {
            SceneManager.LoadScene("Jogo");
        }
    }

    private void LimitVeloc()
    {
        if (airplaneRB.velocity.y < -veloc)
        {
            airplaneRB.velocity = Vector2.down * veloc;
        }
    }

    private void Subir()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            airplaneRB.velocity = Vector2.up * veloc;
            GameObject puffObject = Instantiate(puff, transform.position, Quaternion.identity);
            Destroy(puffObject, 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(0);
    }
}

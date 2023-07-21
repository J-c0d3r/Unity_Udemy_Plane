using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    private float timer = 1f;
    [SerializeField]
    private GameObject obstacle;
    private float posMin = -1.55f;
    private float posMax = 2.3f;
    private Vector3 position;
    private float points = 0f;
    [SerializeField]
    private Text pointsTxt;
    [SerializeField]
    private Text lvlTxt;
    [SerializeField]
    private AudioClip levelUpAudio;
    private Vector3 camPos;
    private int level = 1;
    private float nextLvl = 10f;

    void Start()
    {
        position.x = 14f;
        camPos = Camera.main.transform.position;
    }


    void Update()
    {
        CreateObstacle();
        Points();
        GainLvl();
    }

    private void Points()
    {
        points += Time.deltaTime * (level / 2f);
        pointsTxt.text = "Points: " + Mathf.Round(points).ToString();
    }

    private void GainLvl()
    {
        if (points >= nextLvl)
        {
            level++;
            lvlTxt.text = "Level: " + level.ToString();
            AudioSource.PlayClipAtPoint(levelUpAudio, camPos);
            nextLvl *= 2;
        }
    }

    private void CreateObstacle()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            position.y = Random.Range(posMin, posMax);
            timer = Random.Range(1f / level, 2f);

            Instantiate(obstacle, position, Quaternion.identity);
        }
    }

    public int ReturnLvl()
    {
        return level;
    }
}

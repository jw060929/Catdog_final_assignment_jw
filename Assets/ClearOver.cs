using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearOver : MonoBehaviour
{
    public Transform mario;
    public GameObject ClearText;
    public float clearPositionX = 190f;
    public GameObject GameoverText;
    public float gameOverY = -4f;
    public MarioController marioController;

    private bool isCleared = false;
    private bool isGameover = false;
    void Clear()
    {
        isCleared = true;
        ClearText.SetActive(true);
        marioController.enabled = false;
        Rigidbody2D rb = mario.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
    }

    public void Gameover()
    {
        isGameover = true;
        GameoverText.SetActive(true);
        marioController.enabled = false;
        Rigidbody2D rb = mario.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCleared && !isGameover)
        {
            // 클리어 판정
            if (mario.position.x >= clearPositionX)
            {
                Clear();
            }

            // 게임오버(낙사) 판정
            if (mario.position.y <= gameOverY)
            {
                Gameover();
            }
        }
    }
}

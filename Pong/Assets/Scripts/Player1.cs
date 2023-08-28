using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public int velocidade;

    Vector2 raquetePlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
        LimiteMovimento();
    }

    void Movimento()
    {
        float y = Input.GetAxisRaw("Player 1") * velocidade * Time.deltaTime;

        transform.Translate(0.0f, y, 0.0f);
    }

    void LimiteMovimento()
    {
        raquetePlayer = transform.position;

        if (raquetePlayer.y > 3.10f)
        {
            raquetePlayer = new Vector2(-7.5f, 3.10f);

            transform.position = raquetePlayer;
        }

        if (raquetePlayer.y < -3.10)
        {
            raquetePlayer = new Vector2(-7.5f, -3.10f);

            transform.position = raquetePlayer;
        }
    }
}

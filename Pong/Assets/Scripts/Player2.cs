using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public int velocidade;

    private bool jogador2 = false;

    Vector3 posicaoBola;

    Vector3 raquete;

    // Start is called before the first frame update
    void Start()
    {
        raquete = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        IAcontroller();
        MovimentoPlayer2();
        LimiteMovimento();
    }

    void MovimentoPlayer2()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        { 
            jogador2 = true;
        }

        if (jogador2 == true)
        {
            float y = Input.GetAxisRaw("Player 2") * velocidade * Time.deltaTime;

            transform.Translate(0.0f, y, 0.0f);
        }   
    }

    void IAcontroller()
    {

        if (jogador2 == false)
        {
            posicaoBola.y = GameObject.FindGameObjectWithTag("Bolinha").transform.position.y;

            posicaoBola.x = 7.02f;
            
            //Minha posição, posição q quero seguir, porcentagem com base na velocidade do objeto q estou seguindo.
            raquete.y = Mathf.Lerp(transform.position.y, posicaoBola.y, 0.01f);

            transform.position = new Vector3 (7.7f, raquete.y, 0f);
        }

        /*if (jogador2 == false)
        {
            posicaoBola.y = GameObject.FindGameObjectWithTag("Bolinha").transform.position.y;

            posicaoBola.x = 7.50f;

            transform.position = posicaoBola;
        }*/
    }

    void LimiteMovimento()
    {
        raquete = transform.position;

        if (raquete.y > 3.98f)
        {
            raquete = new Vector2(7.7f, 3.98f);

            transform.position = raquete;
        }

        if (raquete.y < -3.98f)
        {
            raquete = new Vector2(7.7f, -3.98f);

            transform.position = raquete;
        }
    }
}

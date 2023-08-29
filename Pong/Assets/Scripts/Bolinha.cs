using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolinha : MonoBehaviour
{

    Rigidbody2D rb;

    Vector2 minhaVelocidade;

    public float speedBolinha;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(DirecaoBolinha());
    }
    // Update is called once per frame
    void Update()
    {
     
    }

    IEnumerator DirecaoBolinha()
    {
        yield return new WaitForSeconds(1f);

        int direcao = Random.Range(0,3);

        if (direcao == 0)
        {
            minhaVelocidade.x = speedBolinha;
            minhaVelocidade.y = speedBolinha;
        }
        else if (direcao == 1)
        {
            minhaVelocidade.x = -speedBolinha;
            minhaVelocidade.y = -speedBolinha;
        }
        else if (direcao == 2)
        {
            minhaVelocidade.x = speedBolinha;
            minhaVelocidade.y = -speedBolinha;
        }
        else if (direcao == 3)
        {
            minhaVelocidade.x = -speedBolinha;
            minhaVelocidade.y = speedBolinha;
        }

        rb.velocity = minhaVelocidade;
    }
}

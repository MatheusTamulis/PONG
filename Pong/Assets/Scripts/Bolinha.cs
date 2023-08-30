using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bolinha : MonoBehaviour
{
    public Text txtScoreP1;
    public Text txtScoreP2;

    int scoreP1;
    int scoreP2;
    int direcao;

    Rigidbody2D rb;

    Vector2 minhaVelocidade;
    Vector2 reset;

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
        txtScoreP1.text = scoreP1.ToString();

        txtScoreP2.text = scoreP2.ToString();

        ResetScene();
    }

    IEnumerator DirecaoBolinha()
    {
        yield return new WaitForSeconds(1f);

        RandomBolinha();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ParedeDireita")
        {
            scoreP1++;

            reset = new Vector2 (0,0);

            transform.position = reset;

            RandomBolinha();
        }

        if (collision.gameObject.tag == "ParedeEsquerda")
        {
            scoreP2++;

            reset = new Vector2(0, 0);

            transform.position = reset;

            RandomBolinha();
        }
    }

    void RandomBolinha()
    {
        direcao = Random.Range(0, 4);

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

    void ResetScene()
    {
        if (scoreP1 >= 10)
        {
            SceneManager.LoadScene("TitleScreen");
        }
        else if (scoreP2 >= 10) 
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bolinha : MonoBehaviour
{
    public Text txtScoreP1;
    public Text txtScoreP2;
    public Text winP1;
    public Text winP2;

    int scoreP1;
    int scoreP2;
    int direcao;

    public AudioSource[] sound;

    Rigidbody2D rb;

    Vector2 minhaVelocidade;
    Vector2 reset;

    public float speedBolinha;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sound = GetComponents<AudioSource>();

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

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("TitleScreen");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "ParedeDireita")
        {
            sound[1].Play();

            scoreP1++;

            reset = new Vector2 (0,0);

            transform.position = reset;

            RandomBolinha();
        }
        else if (collision.gameObject.tag == "ParedeEsquerda")
        {
            sound[1].Play();

            scoreP2++;

            reset = new Vector2(0, 0);

            transform.position = reset;

            RandomBolinha();
        }
        else
        {
            if (collision.collider)
            {
                sound[0].Play();
            }
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
            winP1.enabled = true;

            StartCoroutine(LoadScene());
        }
        else if (scoreP2 >= 10) 
        {
            winP2.enabled = true;

            StartCoroutine(LoadScene());
        }
    }

    void WinCondition()
    {

    }
}

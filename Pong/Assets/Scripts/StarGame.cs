using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarGame : MonoBehaviour
{

    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BlinkText());
    }

    // Update is called once per frame
    void Update()
    {
        StartScene();
    }

    void StartScene()
    {
        if (Input.anyKey)
        {
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Gameplay");
    }

    IEnumerator BlinkText()
    {
        yield return new WaitForSeconds(0.7f);
        txt.enabled = false;
        yield return new WaitForSeconds(0.7f);
        txt.enabled = true;

        StartCoroutine(BlinkText());
    }
}

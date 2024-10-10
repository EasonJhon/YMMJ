using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Launcher : MonoBehaviour
{
    public Button EnterGameBtn;
    public Button QuitGameBtn;
    public AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        EnterGameBtn.onClickEx = EnterGame;
        QuitGameBtn.onClickEx = QuitGame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterGame()
    {
        StartCoroutine("LoadScene");
    }

    public void QuitGame()
    {
        StartCoroutine("Quit");
    }

    IEnumerator LoadScene()
    {
        AS.Play();
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadSceneAsync("Main");
    }

    IEnumerator Quit()
    {
        AS.Play();
        yield return new WaitForSeconds(0.2f);
        Application.Quit();
    }
}

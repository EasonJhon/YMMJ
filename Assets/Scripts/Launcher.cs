using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Launcher : MonoBehaviour
{
    private Button m_EnterGameBtn;
    private Button m_QuitGameBtn;
    public AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        m_EnterGameBtn = transform.Find("EnterGameBtn").GetComponent<Button>();
        m_QuitGameBtn = transform.Find("QuitGameBtn").GetComponent<Button>(); 
        m_EnterGameBtn.onClick.AddListener(EnterGame);
        m_QuitGameBtn.onClick.AddListener(QuitGame);
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
        SceneManager.LoadSceneAsync("Loading");
    }

    IEnumerator Quit()
    {
        AS.Play();
        yield return new WaitForSeconds(0.2f);
        Application.Quit();
    }
}
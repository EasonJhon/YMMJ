using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    public float PlayerMoveSpeed;
    private Rigidbody2D m_PlayerRB;
    private Collider2D m_PlayerColl;
    private float m_ScaleX;
    public GameObject Question;
    public List<Button> Answers;
    public GameObject QuestionResult;
    public int CorrectAnswer;
    public GameObject KillUI;
    public Button AttackBtn;
    public GameObject Monster;
    public int MonsterHp;
    public int PlayerAttack;
    public GameObject End;
    public Button NextBtn;
    public string NextSceneName;
    public AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        m_ScaleX = transform.localScale.x;
        m_PlayerRB = GetComponent<Rigidbody2D>();
        m_PlayerColl = GetComponent<CapsuleCollider2D>();
        for (var i = 0; i < Answers.Count; i++)
        {
            var i1 = i;
            Answers[i].onClick.AddListener((() => { OnQuestionClick(i1); }));
        }
        AttackBtn.onClick.AddListener(KillMonster);
        NextBtn?.onClick.AddListener(NextScene);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float horizontalNum = Input.GetAxis("Horizontal");
        float faceNum = Input.GetAxisRaw("Horizontal");
        m_PlayerRB.velocity = new Vector2(PlayerMoveSpeed * horizontalNum, m_PlayerRB.velocity.y);
        if (faceNum != 0)
        {
            transform.localScale = new Vector3(faceNum * m_ScaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Question")
        {
            collision.transform.gameObject.SetActive(false);
            Question.SetActive(true);
        }
    }
    
    private void OnQuestionClick(int index)
    {
        if (index != CorrectAnswer)
        {
            QuestionResult.SetActive(true);
            StartCoroutine("LoadScene");
            return;
        }
        AS.Play();
        Question.SetActive(false);
        KillUI.SetActive(true);
        Monster.SetActive(true);
    }

    public void KillMonster()
    {
        AS.Play();
        MonsterHp-= PlayerAttack;
        if (MonsterHp > 0) return;
        Monster.SetActive(false);
        KillUI.SetActive(false);
        End.SetActive(true);
    }

    public void QuitGame()
    {
        StartCoroutine("Quit");
    }

    private void NextScene()
    {
        StartCoroutine("LoadNextScene");
    }
    
    IEnumerator Quit()
    {
        AS.Play();
        yield return new WaitForSeconds(0.2f);
        Application.Quit();
    }
    
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync("Launcher");
    }
    
    IEnumerator LoadNextScene()
    {
        AS.Play();
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadSceneAsync(NextSceneName);
    }
}

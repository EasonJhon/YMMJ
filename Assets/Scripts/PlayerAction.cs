using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float PlayerMoveSpeed;
    public Rigidbody2D PlayerRB;
    public Collider2D PlayerColl;
    private float m_ScaleX;
    public GameObject Question;
    public GameObject KillUI;
    public GameObject Monster;
    public GameObject End;
    public AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        m_ScaleX = transform.localScale.x;
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
        PlayerRB.velocity = new Vector2(PlayerMoveSpeed * horizontalNum, PlayerRB.velocity.y);
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

    public void OnQuestionClick()
    {
        AS.Play();
        Question.SetActive(false);
        KillUI.SetActive(true);
        Monster.SetActive(true);
    }


    public void KillMonster()
    {
        AS.Play();
        Monster.SetActive(false);
        KillUI.SetActive(false);
        End.SetActive(true);
    }

    public void QuitGame()
    {
        StartCoroutine("Quit");
    }

    IEnumerator Quit()
    {
        AS.Play();
        yield return new WaitForSeconds(0.2f);
        Application.Quit();
    }
}

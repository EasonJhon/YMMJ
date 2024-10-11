using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoadScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadSceneAsync("Main");
    }
}

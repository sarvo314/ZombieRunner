using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        SceneManager.LoadScene("Sandbox");
        Debug.Log("Scene is Restarted");
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Time.timeScale = 1;
       Application.Quit();
    }
}

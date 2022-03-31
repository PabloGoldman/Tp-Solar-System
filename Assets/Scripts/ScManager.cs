using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScManager : MonoBehaviour
{
    public static ScManager self;

    void Awake()
    {
        if (self != null && self != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            self = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
        Debug.Log(ActualScene());
    }

    public string ActualScene()
    {
        return SceneManager.GetActiveScene().name;
    }
}

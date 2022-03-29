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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public int ActualScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}

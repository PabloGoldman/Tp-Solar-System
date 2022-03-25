using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager self;

    public Models actualModel;

    public Vector3 spawnPoint;

    bool alreadyLoaded = false;

    GameObject player;

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
        if (ScManager.self.ActualScene() == 1 && !alreadyLoaded)
        {
            InstantiatePlayer();
            alreadyLoaded = true;
        }
        else if(ScManager.self.ActualScene() != 1)
        {
            alreadyLoaded = false;

            if (player != null)
            {
                Destroy(player);
            }
        }
    }

    public void SetModel(Models model)
    {
        actualModel = model;
    }

    public void InstantiatePlayer()
    {
        player = Instantiate(actualModel.character, spawnPoint, Quaternion.identity);
        player.SetActive(true);
    }
}

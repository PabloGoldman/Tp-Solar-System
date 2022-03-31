using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //PREGUNTARLE A SERGIO POR QUE CUANDO VUELVO A UNA ESCENA SE PIERDEN LAS REFERENCIAS A LOS MANAGERS

    public static GameManager self;

    [SerializeField] Models defaultModel;

    private Models actualModel = null;
    public Models GetModel() => actualModel;
    public void SetModel(Models model) => actualModel = model;

    public Vector3 spawnPoint;

    bool alreadyLoaded = false;

    GameObject player;
    public GameObject GetPlayer() => player;

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
        if (actualModel == null)
        {
            SetModel(defaultModel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ScManager.self.ActualScene() == "SampleScene" && !alreadyLoaded)
        {
            InstantiatePlayer();
            alreadyLoaded = true;
        }
        else if(ScManager.self.ActualScene() != "SampleScene")
        {
            alreadyLoaded = false;

            if (player != null)
            {
                Destroy(player);
            }
        }
    }

    public void InstantiatePlayer()
    {
        player = Instantiate(actualModel.character, spawnPoint, Quaternion.identity);
        player.SetActive(true);
    }

    public void ResetData()
    {
        alreadyLoaded = false;
    }
}

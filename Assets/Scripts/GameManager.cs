using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //PREGUNTARLE A SERGIO COMO TESTEAR EL JUEGO SIN PASAR X EL SELECTOR DE PERSONAJE
    //POR EJ SI QUIERO TESTEAR LA CAMARA SOLO EN EL JUEGO

    //PREGUNTAR X LO DEL ALREADYLOADED QUE EL JUGADOR SE INSTANCIABA EN LA OTRA ESCENA

    public static GameManager self;


    private Models actualModel;
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

    public void InstantiatePlayer()
    {
        player = Instantiate(actualModel.character, spawnPoint, Quaternion.identity);
        player.SetActive(true);
    }
}

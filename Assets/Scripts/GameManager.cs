using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        InputManager();
    }

    void InputManager()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            player.ResetPlayerPos();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Selector : MonoBehaviour
{
    public Models[] characterModels;

    public Transform spot;

    public TextMeshProUGUI title;
    public TextMeshProUGUI speed;

    private List<GameObject> characters;

    private int currentCharacter;

    // Start is called before the first frame update

    private void Awake()
    {
        title = title.GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        characters = new List<GameObject>();

        foreach (var Models in characterModels)
        {
            GameObject go = Instantiate(Models.character, spot.position, Quaternion.identity);
            go.SetActive(false);
            go.transform.SetParent(spot);
            characters.Add(go);
        }

        ShowCharacterFromList();
    }

    void ShowCharacterFromList()
    {
        characters[currentCharacter].SetActive(true);

        title.text = characterModels[currentCharacter].Name;
        speed.text = "Speed: " + characterModels[currentCharacter].speed.ToString();


        //Seteo el player al game manager
        GameManager.self.SetModel(characterModels[currentCharacter]);
    }

    public void OnClickNext()
    {
        characters[currentCharacter].SetActive(false);

        if (currentCharacter < characters.Count - 1)
            ++currentCharacter;
        else
            currentCharacter = 0; 

        ShowCharacterFromList();
    }

    public void OnClickPrevious()
    {
        characters[currentCharacter].SetActive(false);

        if (currentCharacter == 0)
            currentCharacter = characters.Count - 1;
        else
            --currentCharacter;

        ShowCharacterFromList();
    }

}

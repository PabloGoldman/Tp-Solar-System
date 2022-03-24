using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Models", menuName = "Character")]
public class Models : ScriptableObject
{
    public string Name;

    public bool isActive;

    public enum Rarity { Tier1, Tier2, Tier3};

    public Rarity rarity;

    public GameObject character;
}

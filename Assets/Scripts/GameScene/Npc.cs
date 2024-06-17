using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NpcType
{
    QuestGiver,
    ShopKeeper,
    Enemy
}

public enum DialogueType
{
    Quest,
    Shop,
    Exit
}

[CreateAssetMenu(fileName = "Npc", menuName = "Npc")]
public class Npc : ScriptableObject {
    [SerializeField] private string name;
    [SerializeField] private NpcType npcType;
    [SerializeField] private Sprite sprite;
    [SerializeField] private TextAsset dialogue;
    
    public string Name => name;
    public NpcType NpcType => npcType;
    public Sprite Sprite => sprite;
    public TextAsset Dialogue => dialogue;
}

using UnityEngine;

namespace Characters.Npc {
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
        [SerializeField] private string npcName;
        [SerializeField] private NpcType npcType;
        [SerializeField] private Sprite sprite;
        [SerializeField] private TextAsset dialogue;
    
        public string Name => npcName;
        public NpcType NpcType => npcType;
        public Sprite Sprite => sprite;
        public TextAsset Dialogue => dialogue;
    }
}
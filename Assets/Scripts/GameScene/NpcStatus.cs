using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class NpcStatus : MonoBehaviour {
    [SerializeField] private Npc _npc;
    
    private GameObject _player;
    private Animator _playerAnimator;
    
    private DialogueManager _dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
        GetComponent<SpriteRenderer>().sprite = _npc.Sprite;
        _player = GameObject.Find("Player");
        _playerAnimator = _player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_player == null) return;
        // if player presses E and is in range of the npc and looking at the npc
        // show the dialogue box
        if(Input.GetKeyDown(KeyCode.E) && Vector3.Distance(transform.position, _player.transform.position) < 2f){
            // find out player's direction
            float horizontal = _playerAnimator.GetFloat("Horizontal");
            float vertical = _playerAnimator.GetFloat("Vertical");
            
            Vector3 playerDirection = new Vector3(horizontal, vertical, 0);
            Vector3 direction = transform.position - _player.transform.position;
            
            // take dot product of player's direction and direction to npc
            float dot = Vector3.Dot(playerDirection.normalized, direction.normalized);
            if(dot > 0.5f){
                _dialogueManager.StartDialogue(_npc.Dialogue);
                Time.timeScale = 0;
            }
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool talked = false;

    // public GameObject dialogueBar;

    public void TiggerDialogue()
    {
        talked = true;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    { 
        if (collision.gameObject.name == "Player"  && !talked)
        {
            dialogue.source.Play();
            dialogue.source.loop = true;
            TiggerDialogue();
        }
    }

    // void OnCollisionExit2D(Collision2D collision) 
    // { 
    //     if (collision.gameObject.name == "Player")
    //     {
    //         dialogueBar.gameObject.SetActive(false);
    //     }
    // } 

}

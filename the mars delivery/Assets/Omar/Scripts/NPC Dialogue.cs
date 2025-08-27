using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNPCDialogue", menuName = "NPC Dialogue")]
public class NPCDialogue : ScriptableObject
{
    public string npcName;
    public Sprite ncpIcon;
    public string[] dialogueLines;
    public float typingSpeed = 0.5f;
    public bool[] autoProgressLines;
    public float AutoProgressDelay = 0.5f;
    public AudioClip vioceSound;
    public float voicePitch = 1f;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class SoundOnGrab : MonoBehaviour
{
    public AudioClip grabSound; 
    private AudioSource audioSource;
    private XRGrabInteractable grabInteractable;
    // Start is called before the first frame update
    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = grabSound; 
        audioSource.playOnAwake = false; 
        
        grabInteractable.selectEntered.AddListener(PlaySound);
    }
    private void PlaySound(SelectEnterEventArgs args)
    {
        audioSource.Play();
    }
    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(PlaySound);
    }
}

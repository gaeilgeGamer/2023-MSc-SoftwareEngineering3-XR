using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class GrabParticleEffect : MonoBehaviour
{
    public ParticleSystem particleEffect; 

    private XRGrabInteractable grabInteractable;
    // Start is called before the first frame update
    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(StartParticleEffect);
        grabInteractable.selectExited.AddListener(StopParticleEffect);

    }
        private void StartParticleEffect(SelectEnterEventArgs args)
    {
        particleEffect.Play();
    }
    private void StopParticleEffect(SelectExitEventArgs args)
    {
        particleEffect.Stop();
    }
    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(StartParticleEffect);
        grabInteractable.selectExited.RemoveListener(StopParticleEffect);
    }
}

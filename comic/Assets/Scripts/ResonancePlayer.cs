using UnityEngine;

public class ResonancePlayer : MonoBehaviour
{
    public AudioManager manager;
    public ParticleSystem particle;
    public string clipName;

    public void PlayResonace( string clipName)
    {
        particle.Play();
        manager.PlayFX(clipName);
    }
}

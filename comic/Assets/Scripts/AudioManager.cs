using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Image buttonIMG;
    public Sprite soundOnBtn;
    public Sprite soundOffBtn;
    public AudioSource bgm;
    public AudioSource fx;

    public bool isMuted = false;

    //Lista de efectos de la escena para asignar desde el inspector
    public AudioClip[] clips;

    public void ToggleMute()
    {
        isMuted = !isMuted;
        if (isMuted == true)
        {
            bgm.mute = true;
            fx.mute = true;
            buttonIMG.sprite = soundOffBtn;
        }
        else
        {
            bgm.mute = false;
            fx.mute = false;
            buttonIMG.sprite=soundOnBtn;
        }
    }

    public void PlayFX(string clipName)
    {
        AudioClip clip = System.Array.Find(
            clips,
            c => c.name == clipName
        );

        if (clip != null)
        {
            fx.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("No se encontró el audio");
        }
    }
}

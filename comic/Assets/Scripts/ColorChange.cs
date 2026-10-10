using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    public Color colorObjetivo = new Color(0.6f, 0.7f, 1f);
    public float duracion = 0.5f;

    // llamar desde botones
    // todas las viñetas con colorObjetivo
    public void TintarTodas()
    {
        TintAll(colorObjetivo, duracion);
    }

    //vuelve todo al color original
    public void RestaurarTodas()
    {
        TintAll(Color.white, duracion);
    }

    // solo la viñeta con índice (0 = Viñeta1)
    public void TintarUna(int index)
    {
        TintOne(index, colorObjetivo, duracion);
    }


    public void TintAll(Color target, float time)
    {
        StopAllCoroutines();
        StartCoroutine(Fade(GetComponentsInChildren<RawImage>(), target, time));
    }

    public void TintOne(int index, Color target, float time)
    {
        var imgs = transform.GetChild(index).GetComponentsInChildren<RawImage>();
        StartCoroutine(Fade(imgs, target, time));
    }

    IEnumerator Fade(RawImage[] imgs, Color target, float time)
    {
        var start = new Color[imgs.Length];
        for (int i = 0; i < imgs.Length; i++) start[i] = imgs[i].color;

        for (float t = 0; t < time; t += Time.deltaTime)
        {
            float k = t / time;
            for (int i = 0; i < imgs.Length; i++)
                imgs[i].color = Color.Lerp(start[i], target, k);
            yield return null;
        }
        foreach (var img in imgs) img.color = target;
    }
}

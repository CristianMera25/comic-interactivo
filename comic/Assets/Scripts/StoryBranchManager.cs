using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryBranchManager : MonoBehaviour
{
    [Header("Componentes UI")]
    public ScrollRect scrollRect; 
    public GameObject imagenBlur; 
    public float altoPanelSuperior = 250f; 

    [Header("Flujos de Viñetas")]
    public GameObject branch1Container;
    public GameObject branch2Container;
    public GameObject branch3Container;

    [Header("Botones de Decisión")]
    public Button buttonDecision1;
    public Button buttonDecision2;
    public Button buttonDecision3;

    public static int decisionMomento1 = 0; 

    void Start()
    {
        branch1Container.SetActive(false);
        branch2Container.SetActive(false);
        branch3Container.SetActive(false);

        if (imagenBlur != null) imagenBlur.SetActive(true);

        buttonDecision1.onClick.AddListener(() => TomarDecision(1, true));
        buttonDecision2.onClick.AddListener(() => TomarDecision(2, true));
        buttonDecision3.onClick.AddListener(() => TomarDecision(3, true));

        CheckSavedDecisions();
    }

    private void TomarDecision(int opcion, bool animarScroll)
    {
        LockDecisions();
        decisionMomento1 = opcion;

        if (imagenBlur != null) imagenBlur.SetActive(false);

        if (opcion == 1)
        {
            branch1Container.SetActive(true);
            if (animarScroll) StartCoroutine(ScrollHaciaRama(branch1Container.GetComponent<RectTransform>()));
        }
        else if (opcion == 2)
        {
            branch2Container.SetActive(true);
            if (animarScroll) StartCoroutine(ScrollHaciaRama(branch2Container.GetComponent<RectTransform>()));
        }
        else if (opcion == 3)
        {
            branch3Container.SetActive(true);
            if (animarScroll) StartCoroutine(ScrollHaciaRama(branch3Container.GetComponent<RectTransform>()));
        }
    }

    private IEnumerator ScrollHaciaRama(RectTransform target)
    {
        // 1. Esperamos dos frames para que Unity recalcule todos los tamaños de los Layouts
        yield return null;
        yield return null;

        // 2. Forzamos a la UI a reconstruirse inmediatamente
        LayoutRebuilder.ForceRebuildLayoutImmediate(scrollRect.content);

        // 3. Calculamos matemáticamente el borde superior sin importar cómo esté tu Pivot
        float offsetPivote = (1f - target.pivot.y) * target.rect.height;
        float targetY = Mathf.Abs(target.localPosition.y) - offsetPivote - altoPanelSuperior;

        if (targetY < 0) targetY = 0;

        Vector2 startPos = scrollRect.content.anchoredPosition;
        Vector2 endPos = new Vector2(startPos.x, targetY);

        float time = 0f;
        float duration = 0.6f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = Mathf.SmoothStep(0f, 1f, time / duration);
            scrollRect.content.anchoredPosition = Vector2.Lerp(startPos, endPos, t);
            yield return null;
        }

        scrollRect.content.anchoredPosition = endPos;
    }

    private void LockDecisions()
    {
        buttonDecision1.interactable = false;
        buttonDecision2.interactable = false;
        buttonDecision3.interactable = false;
    }

    private void CheckSavedDecisions()
    {
        if (decisionMomento1 != 0)
        {
            TomarDecision(decisionMomento1, false);
        }
    }
}
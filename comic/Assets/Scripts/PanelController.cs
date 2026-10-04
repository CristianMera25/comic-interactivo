using UnityEngine;

public class PanelController : MonoBehaviour
{
    public RectTransform viewport; 

    public float fadeDistance = 400f; 

    private CanvasGroup canvasGroup;
    private RectTransform panelRect;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        panelRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (viewport == null) return;


        Vector3[] panelCorners = new Vector3[4];
        panelRect.GetWorldCorners(panelCorners);
        float panelTopY = panelCorners[1].y;

        Vector3[] viewportCorners = new Vector3[4];
        viewport.GetWorldCorners(viewportCorners);
        float viewportBottomY = viewportCorners[0].y; 

        float overlap = panelTopY - viewportBottomY;

        if (overlap <= 0f)
        {
            canvasGroup.alpha = 0f; 
        }
        else if (overlap >= fadeDistance)
        {
            canvasGroup.alpha = 1f; 
        }
        else
        {
            canvasGroup.alpha = overlap / fadeDistance;
        }
    }
}
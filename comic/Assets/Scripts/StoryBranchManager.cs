using UnityEngine;
using UnityEngine.UI;

public class StoryBranchManager : MonoBehaviour
{
    [Header("Viñeta de Decisiones Original")]
    public GameObject viñetaDecisionBase;

    [Header("Viñetas de Consecuencia")]
    public GameObject ruta1Container;
    public GameObject ruta2Container;
    public GameObject ruta3Container;

    [Header("Viñetas Target para los botones")]
    public GameObject viñetaTarget1;
    public GameObject viñetaTarget2;
    public GameObject viñetaTarget3;

    [Header("Botones de Decisión Originales")]
    public Button buttonDecision1;
    public Button buttonDecision2;
    public Button buttonDecision3;

    [Header("Imagen de desenfoque")]
    public GameObject imagenDesenfoque;

    public static int decisionMomento1 = 0;

    void Start()
    {
        // Ocultar las rutas al iniciar
        if (ruta1Container != null)
            ruta1Container.SetActive(false);

        if (ruta2Container != null)
            ruta2Container.SetActive(false);

        if (ruta3Container != null)
            ruta3Container.SetActive(false);

        // Crear copias de los botones en las viñetas Target
        CrearBotonesTarget();

        // Asignar eventos a los botones originales
        buttonDecision1.onClick.AddListener(() => TomarDecision(1));
        buttonDecision2.onClick.AddListener(() => TomarDecision(2));
        buttonDecision3.onClick.AddListener(() => TomarDecision(3));

        CheckSavedDecisions();
    }

    private void CrearBotonesTarget()
    {
        // Copiar botón 1
        if (buttonDecision1 != null && viñetaTarget1 != null)
        {
            Button nuevoBoton1 = Instantiate(
                buttonDecision1,
                viñetaTarget1.transform
            );

            nuevoBoton1.name = "Button Decision 1 Target";
            nuevoBoton1.interactable = false;

            RectTransform rectTransform = nuevoBoton1.GetComponent<RectTransform>();

            if (rectTransform != null)
            {
                rectTransform.anchoredPosition = new Vector2(
                    rectTransform.anchoredPosition.x,
                    1500f
                );
            }
        }

        // Copiar botón 2
        if (buttonDecision2 != null && viñetaTarget2 != null)
        {
            Button nuevoBoton2 = Instantiate(
                buttonDecision2,
                viñetaTarget2.transform
            );

            nuevoBoton2.name = "Button Decision 2 Target";
            nuevoBoton2.interactable = false;

            RectTransform rectTransform = nuevoBoton2.GetComponent<RectTransform>();

            if (rectTransform != null)
            {
                rectTransform.anchoredPosition = new Vector2(
                    rectTransform.anchoredPosition.x,
                    1500f
                );
            }
        }

        // Copiar botón 3
        if (buttonDecision3 != null && viñetaTarget3 != null)
        {
            Button nuevoBoton3 = Instantiate(
                buttonDecision3,
                viñetaTarget3.transform
            );

            nuevoBoton3.name = "Button Decision 3 Target";
            nuevoBoton3.interactable = false;

            RectTransform rectTransform = nuevoBoton3.GetComponent<RectTransform>();

            if (rectTransform != null)
            {
                rectTransform.anchoredPosition = new Vector2(
                    rectTransform.anchoredPosition.x,
                    1500f
                );
            }
        }
    }

    private void TomarDecision(int opcion)
    {
        // Bloquear los botones originales
        LockDecisions();

        // Guardar decisión
        decisionMomento1 = opcion;

        // Apagar imagen de desenfoque
        if (imagenDesenfoque != null)
        {
            imagenDesenfoque.SetActive(false);
        }

        // Ocultar la viñeta original de decisiones
        if (viñetaDecisionBase != null)
        {
            viñetaDecisionBase.SetActive(false);
        }

        // Mostrar únicamente la consecuencia elegida
        if (opcion == 1 && ruta1Container != null)
        {
            ruta1Container.SetActive(true);
        }
        else if (opcion == 2 && ruta2Container != null)
        {
            ruta2Container.SetActive(true);
        }
        else if (opcion == 3 && ruta3Container != null)
        {
            ruta3Container.SetActive(true);
        }
    }

    private void LockDecisions()
    {
        if (buttonDecision1 != null)
            buttonDecision1.interactable = false;

        if (buttonDecision2 != null)
            buttonDecision2.interactable = false;

        if (buttonDecision3 != null)
            buttonDecision3.interactable = false;
    }

    private void CheckSavedDecisions()
    {
        if (decisionMomento1 != 0)
        {
            // Ocultar viñeta original
            if (viñetaDecisionBase != null)
                viñetaDecisionBase.SetActive(false);

            // Apagar desenfoque
            if (imagenDesenfoque != null)
                imagenDesenfoque.SetActive(false);

            // Mostrar la ruta guardada
            if (decisionMomento1 == 1 && ruta1Container != null)
                ruta1Container.SetActive(true);

            if (decisionMomento1 == 2 && ruta2Container != null)
                ruta2Container.SetActive(true);

            if (decisionMomento1 == 3 && ruta3Container != null)
                ruta3Container.SetActive(true);

            // Mantener botones bloqueados
            LockDecisions();
        }
    }
}
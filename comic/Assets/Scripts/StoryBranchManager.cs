using UnityEngine;
using UnityEngine.UI;

public class StoryBranchManager : MonoBehaviour
{
    [Header("Flujos de Viñetas")]
    public GameObject branch1Container; // Aquí arrastrarás Flujo_Decision1
    public GameObject branch2Container; // Aquí arrastrarás Flujo_Decision2

    [Header("Botones de Decisión")]
    public Button buttonDecision1;
    public Button buttonDecision2;

    void Start()
    {
        // 1. Ocultar los flujos alternativos al iniciar la escena
        branch1Container.SetActive(false);
        branch2Container.SetActive(false);

        // 2. Conectar los botones a sus respectivas funciones
        buttonDecision1.onClick.AddListener(ChooseBranch1);
        buttonDecision2.onClick.AddListener(ChooseBranch2);

        // HU 2.3: Verificar si el usuario ya había tomado esta decisión antes
        CheckSavedDecisions();
    }

    public void ChooseBranch1()
    {
        // Activa la rama 1 y asegura que la 2 esté apagada
        branch1Container.SetActive(true);
        branch2Container.SetActive(false);
        
        LockDecisions(); // Bloquea los botones para que no cambie de opinión
        PlayerPrefs.SetInt("Decision_Momento1", 1); // Guarda la decisión (HU 2.3)
        PlayerPrefs.Save();
    }

    public void ChooseBranch2()
    {
        // Activa la rama 2 y asegura que la 1 esté apagada
        branch1Container.SetActive(false);
        branch2Container.SetActive(true);
        
        LockDecisions();
        PlayerPrefs.SetInt("Decision_Momento1", 2); 
        PlayerPrefs.Save();
    }

    private void LockDecisions()
    {
        // Opcional: Desactiva la interacción de los botones para confirmar la elección
        buttonDecision1.interactable = false;
        buttonDecision2.interactable = false;
    }

    private void CheckSavedDecisions()
    {
        // Revisa si ya hay una decisión guardada en la memoria del celular
        if (PlayerPrefs.HasKey("Decision_Momento1"))
        {
            int savedDecision = PlayerPrefs.GetInt("Decision_Momento1");
            if (savedDecision == 1)
            {
                ChooseBranch1();
            }
            else if (savedDecision == 2)
            {
                ChooseBranch2();
            }
        }
    }
}
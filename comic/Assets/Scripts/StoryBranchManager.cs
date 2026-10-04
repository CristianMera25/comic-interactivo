using UnityEngine;
using UnityEngine.UI;

public class StoryBranchManager : MonoBehaviour
{
    [Header("Flujos de Viñetas")]
    public GameObject branch1Container;
    public GameObject branch2Container;

    [Header("Botones de Decisión")]
    public Button buttonDecision1;
    public Button buttonDecision2;

    public static int decisionMomento1 = 0; 

    void Start()
    {
        branch1Container.SetActive(false);
        branch2Container.SetActive(false);

        buttonDecision1.onClick.AddListener(ChooseBranch1);
        buttonDecision2.onClick.AddListener(ChooseBranch2);

        CheckSavedDecisions();
    }

    public void ChooseBranch1()
    {
        branch1Container.SetActive(true);
        branch2Container.SetActive(false);
        
        LockDecisions();
        decisionMomento1 = 1;
    }

    public void ChooseBranch2()
    {
        branch1Container.SetActive(false);
        branch2Container.SetActive(true);
        
        LockDecisions();
        decisionMomento1 = 2;
    }

    private void LockDecisions()
    {
        buttonDecision1.interactable = false;
        buttonDecision2.interactable = false;
    }

    private void CheckSavedDecisions()
    {
        if (decisionMomento1 == 1)
        {
            ChooseBranch1();
        }
        else if (decisionMomento1 == 2)
        {
            ChooseBranch2();
        }
    }
}
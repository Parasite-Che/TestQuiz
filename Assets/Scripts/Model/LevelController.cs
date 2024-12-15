using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour, ILevelControllable
{
    [SerializeField]
    private List<BundleData> paletBundles;

    [SerializeField]
    private GameSettingsData gameSettings;

    [SerializeField]
    private Text textOfTask;

    private FieldGenerationController fieldGenerationController;

    private ListController listController = new ListController();

    private byte curentLevel = 0;
    private List<string> answers = new List<string>();


    private void Awake()
    {
        fieldGenerationController = GetComponent<FieldGenerationController>();

        CreateLevel();
    }

    public void MovingToNewLevel()
    {
        if (curentLevel != gameSettings.Levels.Length - 1)
        {
            fieldGenerationController.ClearField();
            curentLevel++;
            CreateLevel();
        }
    }

    public bool CheckAnswer(string _answer)
    {
        if (_answer == answers[curentLevel])
        {
            return true;
        }
        return false;
    }

    private void CreateLevel()
    {
        int numOfBundle = Random.Range(0, paletBundles.Count);
        List<int> numOfValues = listController.RandomValues(
            paletBundles[numOfBundle].Names.Count,
            gameSettings.Levels[curentLevel]);
        answers.Add(paletBundles[numOfBundle].Names[numOfValues[Random.Range(0, numOfValues.Count)]]);

        textOfTask.text = "Find " + answers[answers.Count - 1];

        StartCoroutine(fieldGenerationController.FieldGeneration(numOfValues,
            paletBundles[numOfBundle]));
    }



}

interface ILevelControllable
{
    public void MovingToNewLevel();

    public bool CheckAnswer(string _answer);

}

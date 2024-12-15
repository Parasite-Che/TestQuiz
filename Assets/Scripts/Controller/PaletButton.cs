using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaletButton : MonoBehaviour
{
    private string _name;

    private ILevelControllable levelController;

    public string GetName { get { return _name; } }

    public void SetName(string name) {  _name = name; }

    private void Awake()
    {
        levelController = transform.parent.GetComponent<ILevelControllable>();
        gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }


    public void TaskOnClick()
    {
        StartCoroutine(ButtonLogic());
    }

    private IEnumerator ButtonLogic()
    {
        if (levelController.CheckAnswer(_name))
        {
            gameObject.GetComponent<ParticleSystem>().Play();
            yield return new WaitForSeconds(1);
            levelController.MovingToNewLevel();
        }
        yield return null;
    }


}

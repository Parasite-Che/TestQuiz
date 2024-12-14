using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FieldGenerationController : MonoBehaviour
{
    [SerializeField] 
    private GameObject paletePref;

    [SerializeField]
    private BundleData[] paletBundles;

    private void Awake()
    {
        StartCoroutine(FieldGenerate(gameObject.transform, paletePref, 9));
    }

    private IEnumerator FieldGenerate(Transform _parent, GameObject _palete, Int16 count)
    {
        for (int i = 0; i < count; i++)
        {

            // create and move to ganerate palete function
            Transform obj = Instantiate(_palete, _parent).transform.GetChild(0);
            obj.GetComponent<SpriteRenderer>().sprite = paletBundles[0].Sprites[i];

            for (int j = 0; j < paletBundles[0].NumsForRotate.Count; j++)
            {
                if (i == paletBundles[0].NumsForRotate[j])
                {
                    obj.Rotate(new Vector3(0, 0, -90));
                }
            }

            //obj.parent.GetComponent<Button>().onClick.AddListener(); Loose and win logic

            yield return null;
        }
    }



}

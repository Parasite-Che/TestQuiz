using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FieldGenerationController : MonoBehaviour
{
    [SerializeField] 
    private GameObject paletePref;

    [SerializeField]
    private List<GameObject> paletList;


    public List<GameObject> PaletList {  get { return paletList; } }


    public IEnumerator FieldGeneration(List<int> numOfValues, BundleData paletBundles, IEnumerator paleteAnim = null, IEnumerator nextEnumerator = null)
    {

        for (int i = 0; i < numOfValues.Count; i++)
        {
            paletList.Add(Instantiate(paletePref, gameObject.transform));
            paletList[i].GetComponent<PaletButton>().SetName(paletBundles.Names[numOfValues[i]]);


            Transform icon = paletList[i].transform.GetChild(0);

            icon.GetComponent<SpriteRenderer>().sprite = paletBundles.Sprites[numOfValues[i]];

            for (int j = 0; j < paletBundles.NumsForRotate.Count; j++)
            {
                if (numOfValues[i] == paletBundles.NumsForRotate[j])
                {
                    icon.Rotate(new Vector3(0, 0, -90));
                }
            }

            //obj.parent.GetComponent<Button>().onClick.AddListener(); Loose and win logic

            yield return paleteAnim;
        }

        yield return nextEnumerator;
    }

    public void ClearField()
    {
        for (int i = 0;i < paletList.Count; i++)
        {
            Destroy(paletList[i]);
        }
        paletList.Clear();
    }

}

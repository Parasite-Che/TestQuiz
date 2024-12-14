using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BundleData", menuName = "Bundle Data", order = 1)]
public class BundleData : ScriptableObject
{

    [SerializeField]
    private List<Sprite> sprites;

    [SerializeField]
    private List<string> names;

    [SerializeField]
    private List<int> numsForRotate;


    public List<Sprite> Sprites => sprites;
    
    public List<string> Names => names;

    public List<int> NumsForRotate => numsForRotate;
}

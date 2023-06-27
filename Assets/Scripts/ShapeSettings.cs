using UnityEngine;
using UnityEngine.UI;
public struct ShapeSettings
{

    public Toggle Toggle;
    public GameObject Prefab;

    public ShapeSettings(Toggle toggle, GameObject prefab)
    {
        Toggle = toggle;
        Prefab = prefab;
    }
}

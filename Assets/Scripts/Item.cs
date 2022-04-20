using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "CreateItem/Item")]
public class Item : ScriptableObject
{
    [SerializeField]
    private Sprite _icon;
    [SerializeField]
    private int _id;

    public int ID
    {
        get
        {
            return _id;
        }
    }

    public Sprite Icon
    {
        get
        {
            return _icon;
        }
    }
}

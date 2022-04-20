using UnityEngine;

public class ItemSrc : MonoBehaviour
{
    [SerializeField] private GameObject _shadow;
    [SerializeField] private Item _srcObj;
    [SerializeField] private bool _stateShadow;
    public bool StateShadow
    {
        get
        {
            return _stateShadow;
        }
        set
        {
            _stateShadow = value;
        }
    }
    private int _id;

    private void Start()
    {
        this.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = _srcObj.Icon;
        _id = _srcObj.ID;
        CheckHide();
        Debug.Log(_stateShadow);
        Debug.Log(_id);
    }

    private void CheckHide() // Проверка состояния объекта
    {
        if (_stateShadow == true)
            _shadow.SetActive(true);
        else
            _shadow.SetActive(false);
    }
}

using UnityEngine;

public class ItemSrc : MonoBehaviour
{
    [SerializeField] private GameObject _shadow;
    [SerializeField] private Item _srcObj;
    [SerializeField] private bool _stateShadow;
    private int _id;
    public Item SrcObj
    {
        get
        {
            return _srcObj;
        }
    }
    public int ID
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
        }
    }
    public bool StateShadow
    {
        get
        {
            return _stateShadow;
        }
    }
    
    private void Start()
    {
        if (this.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite == null)
        {
            this.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = _srcObj.Icon;
        }
        CheckHide();
    }
    public void ChangeShadowState() // Смена состояния тени на ячейке
    {
        _stateShadow = !_stateShadow;
        CheckHide();
    }
    private void CheckHide() // Проверка состояния объекта
    {
        if (_stateShadow == true)
            _shadow.SetActive(true);
        else
            _shadow.SetActive(false);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<ItemSrc>().ChangeShadowState(); // Смена состояния на соседней ячейке
    }
}

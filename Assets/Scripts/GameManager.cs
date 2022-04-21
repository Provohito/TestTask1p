using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _parentResultCell;
    [SerializeField] private UIManager _ui;

    private int _endGame = 0;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            CastRay(); 
    }

    private void CastRay() // Луч для клика на ячейку
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            AddCellToTable(hit.collider.GetComponent<ItemSrc>().SrcObj);
            Destroy(hit.collider.gameObject);
            CheckGameState();
        }
    }
    private void AddCellToTable(Item _item) // Добавление ячеек в результирующее поле
    {
        for (int i = 0; i < _parentResultCell.transform.childCount; i++)
        {
            if (_parentResultCell.transform.GetChild(i).gameObject.activeInHierarchy == false)
            {
                _parentResultCell.transform.GetChild(i).gameObject.SetActive(true);
                _parentResultCell.transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite = _item.Icon;
                _parentResultCell.transform.GetChild(i).GetComponent<ItemSrc>().ID = _item.ID;
                CheckCampatibilityCells();
                break;
            }
        }
    }
    private int result = 0;
    private void CheckCampatibilityCells() // проверка результата ячеек в результирующем поле
    {
        
        for (int i = 0; i < 4; i++)
        {
            result = 0;
            for (int k = 0; k < _parentResultCell.transform.childCount; k++)
            {
                if (_parentResultCell.transform.GetChild(k).gameObject.activeInHierarchy == true)
                {
                    if (_parentResultCell.transform.GetChild(k).GetComponent<ItemSrc>().ID == i)
                    {
                        result++;
                        if (result == 3)
                        {
                            DestroyCells(i);
                        }
                        
                    }
                } 
            }
        }
    }

    private void DestroyCells(int _id) // Деактивирование одинаковых клеток
    {
        for (int k = 0; k < _parentResultCell.transform.childCount; k++)
        {
            if (_parentResultCell.transform.GetChild(k).gameObject.activeInHierarchy == true)
            {
                if (_parentResultCell.transform.GetChild(k).GetComponent<ItemSrc>().ID == _id)
                {
                    _parentResultCell.transform.GetChild(k).gameObject.SetActive(false);
                }
            }     
        }
        
    }

    private void CheckGameState() // Проверка состояния игры
    {
        _endGame = 0;
        for (int i = 0; i < _parentResultCell.transform.childCount; i++)
        {
            if (_parentResultCell.transform.GetChild(i).gameObject.activeInHierarchy == true)
            {
                _endGame++;
            }
        }
        if (_endGame == 7)
            _ui.GetResultGame(2);
        else if (GameObject.FindGameObjectsWithTag("cell").Length == 1)
            _ui.GetResultGame(1);
    }
}

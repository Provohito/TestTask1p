using UnityEngine;

public class LVLManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _lvlPrefabs;
    private GameObject _currentLvl;
    private int _numberLvl;
    public void Start()
    {
        _currentLvl = Instantiate(_lvlPrefabs[0]);
        _numberLvl = 0;
    }
    public void Retry()
    {
        Debug.Log("retry");
        Destroy(_currentLvl);
        _currentLvl = Instantiate(_lvlPrefabs[0]);
    }
    public void Continue()
    {
        Debug.Log("Next");
        Destroy(_currentLvl);
        if (_numberLvl == 0)
        {
            _currentLvl = Instantiate(_lvlPrefabs[1]);
            _numberLvl = 1;
        }
        else
        {
            _currentLvl = Instantiate(_lvlPrefabs[0]);
            _numberLvl = 0;
        }
    }
}

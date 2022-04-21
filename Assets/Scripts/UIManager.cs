using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _defeatScreen;
    private LVLManager _lvlManager;
    private void Start()
    {
        _lvlManager = GameObject.Find("LvlManager").GetComponent<LVLManager>();
    }
    public void GetResultGame(int state)
    {
        SetResultGame(state);
    }

    private void SetResultGame(int state)
    {
        if (state == 1)
            _winScreen.SetActive(true);
        else
            _defeatScreen.SetActive(true);
    }

    public void RetryLvl()
    {
        _lvlManager.Retry();
    }
    public void NextLvl()
    {
        _lvlManager.Continue();
    }
}

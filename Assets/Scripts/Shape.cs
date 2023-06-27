using UnityEngine;
using UnityEngine.UI;

public class Shape : MonoBehaviour
{
    [SerializeField] private Font _timerFont;
    [SerializeField] private Text _timerText;

    private float _lifeTimer;

    private void Update()
    {
        _lifeTimer -= Time.deltaTime;
        if (_lifeTimer < 0)
        {
            Destroy(gameObject);
        }
        _timerText.text = _lifeTimer.ToString("F1");
    }

    public void InitializeFigure(float life, Vector3 position)
    {
        _lifeTimer = life;
        transform.localPosition = position;
    }
}
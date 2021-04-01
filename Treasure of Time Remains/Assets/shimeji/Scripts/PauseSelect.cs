using UnityEngine;
using UnityEngine.UI;

public class PauseSelect : MonoBehaviour
{
    [SerializeField] private Button[] button;

    private void Awake()
    {
        button[0].Select();
    }
}

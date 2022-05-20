using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text local;
    public Text local2;

    void Start()
    {
        local.text = LocalizationManager.Instance.GetMessage(0);
        local2.text = LocalizationManager.Instance.GetMessageWithKeyword(1, "123");
    }
}

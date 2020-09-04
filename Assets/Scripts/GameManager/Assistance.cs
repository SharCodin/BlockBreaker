using UnityEngine;
using UnityEngine.UI;

public class Assistance : MonoBehaviour
{

    public static bool isAssisted = false;

    [SerializeField] private Text assistText = null;

    public void AssistedMode()
    {
        if (isAssisted)
        {
            isAssisted = false;
            assistText.text = "Assist: Off";
        }
        else
        {
            isAssisted = true;
            assistText.text = "Assist: On";
        }
    }

    public bool AssistedOnOff()
    {
        return isAssisted;
    }

}

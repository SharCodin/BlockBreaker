using UnityEngine;

public class Assistance : MonoBehaviour
{

    public static bool isAssisted = false;

    public void AssistedMode()
    {
        if (isAssisted) 
            isAssisted = false;
        else 
            isAssisted = true;
    }

}

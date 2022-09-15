using UnityEngine;

public class SaveInitiate : MonoBehaviour
{
    private void OnApplicationPause(bool pause)
    {
        if (pause) Levls.Save();
    }

    private void OnApplicationQuit()
    {
        Levls.Save();
    }
}

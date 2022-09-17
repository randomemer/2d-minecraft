using UnityEngine;

public class CaveBoundary : MonoBehaviour
{
    public static bool? onSurface;
    public GameObject surfaceCamera;
    public GameObject caveCamera;

    private void Start()
    {
        onSurface = LevelManager.player.transform.position.y > transform.position.y;
        SwitchCameras();
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject == LevelManager.player.gameObject)
        {
            onSurface = collider.transform.position.y > transform.position.y;
            SwitchCameras();
        }
    }

    private void SwitchCameras()
    {
        if (onSurface == null) return;
        caveCamera.SetActive(onSurface == false);
        surfaceCamera.SetActive(onSurface == true);
        AudioManager.SwitchTracks(onSurface == true);
    }
}
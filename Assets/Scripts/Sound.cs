using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip Clip;
    [Range(0f, 1f)] public float Volume;
    [Range(0.1f, 3f)] public float Pitch;
    [HideInInspector] public AudioSource source;
    public bool loop;
    [Range(0f, 1f)] public float SpatialBlend = 0f;
    public float Maxdistance;
    public float Mindistance;
}

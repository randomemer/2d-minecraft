using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager intan;
    [HideInInspector]
    public AudioSource track;
    [HideInInspector]
    public AudioSource cave;
    GameObject Player;
    bool pause;
    private void Awake()
    {
        if (intan == null)
        {
            intan = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sound item in sounds)
        {
            item.source = gameObject.AddComponent<AudioSource>();
            item.source.clip = item.Clip;
            item.source.pitch = item.Pitch;
            item.source.volume = item.Volume;
            item.source.loop = item.loop;
            item.source.spatialBlend = item.SpatialBlend;
            item.source.maxDistance = item.Maxdistance;
            item.source.minDistance = item.Mindistance;
            item.source.rolloffMode = AudioRolloffMode.Linear;
        }
        cave = Find("cave");
        SceneManager.activeSceneChanged += this.IAssign;
        Assign();

    }
    private void Start()
    {
        track.Play();
    }
    public void PLay(string name)
    {
        Sound S = Array.Find(sounds, sound => sound.name == name);
        if (S == null)
        {
            Debug.LogWarning("Audio" + name + "not found");
            return;
        }
        S.source.Play();
    }
    public void Stop()
    {
        foreach (Sound S in sounds)
        {
            S.source.Stop();
        }
    }
    public AudioSource Find(string name)
    {
        Sound S = Array.Find(sounds, sound => sound.name == name);
        if (S == null)
        {
            Debug.LogWarning("Audio" + name + "not found");
            return null;
        }
        return S.source;
    }
    void IAssign(Scene arg1, Scene arg2)
    {
        Assign();
    }
    void Assign()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (!(track == null))
        {
            track.Stop();
        }
        try
        {
            if (cave.isPlaying && !(cave == null))
            {
                cave.Stop();
            }
        }
        catch (Exception)
        {
        }

        if (scene == 0)
        {
            track = Find("Menu");
        }
        else if (scene == 1 || scene == 2 || scene == 4)
        {
            track = Find("1");
            cave = Find("cave2");
        }
        else if (scene == 3)
        {
            track = Find("2");
            cave = Find("cave1");
        }
        else if (scene == 5)
        {
            track = Find("stronghold");
        }
        else
        {
            track = null;
        }
        if (track != null)
        {
            track.Play();
        }
        pause = false;
    }
    private void Update()
    {
        int x = SceneManager.GetActiveScene().buildIndex;
        if (x == 3 || x == 4)
        {
            Player = GameObject.Find("Player");
            if (Player.transform.position.y > -6f && !track.isPlaying && !pause)
            {

                track.Play();
                cave.Pause();
            }
            else if (!cave.isPlaying && Player.transform.position.y < -6f && !pause)
            {
                track.Pause();
                cave.Play();
            }
        }
    }
    public void PauseAudio()
    {
        track.Pause();
        cave.Pause();
        pause = true;
    }
    public void ResumeAudio()
    {
        pause = false;
        int x = SceneManager.GetActiveScene().buildIndex;
        if (x == 5 || x == 1 || x == 2)
        {
            track.Play();
        }
    }
    public void Switch()
    {
        track.Stop();
        track = Find("end");
        track.Play();
    }

}

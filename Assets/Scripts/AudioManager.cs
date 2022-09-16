using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private Sound[] sounds;
    private AudioSource mainMenuTrack;
    [HideInInspector] public AudioSource curTrack;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        InitSounds();
        mainMenuTrack = Find("Menu");
        curTrack = mainMenuTrack;
        SceneManager.activeSceneChanged += this.IAssign;
    }

    private void InitSounds()
    {
        foreach (Sound item in sounds) RegisterAudioSource(item);
    }

    public static void RegisterAudioSource(Sound sound)
    {
        if (instance == null || sound.Clip == null) return;

        sound.source = instance.gameObject.AddComponent<AudioSource>();
        sound.source.clip = sound.Clip;
        sound.source.pitch = sound.Pitch;
        sound.source.volume = sound.Volume;
        sound.source.loop = sound.loop;
        sound.source.spatialBlend = sound.SpatialBlend;
        sound.source.maxDistance = sound.Maxdistance;
        sound.source.minDistance = sound.Mindistance;
        sound.source.rolloffMode = AudioRolloffMode.Linear;
    }

    private void Start()
    {
        curTrack?.Play();
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
        foreach (Sound sound in sounds) sound.source.Stop();
    }

    public AudioSource Find(string name)
    {
        Sound S = Array.Find(sounds, sound => sound.name == name);
        if (S == null)
        {
            Debug.LogWarning($"Audio : {name} not found");
            return null;
        }
        return S.source;
    }

    private void IAssign(Scene prevScene, Scene curScene)
    {
        var old = LevelManager.instance;
        var newOne = FindObjectOfType<LevelManager>();
        Debug.Log($"Old : {old?.GetInstanceID()}, New : {newOne?.GetInstanceID()}");
        LevelManager levelManager = old ?? newOne;
        // LevelManager levelManager = LevelManager.instance ?? FindObjectOfType<LevelManager>();

        if (levelManager != null)
        {
            if (levelManager.levelTrack?.source == null) RegisterAudioSource(levelManager.levelTrack);
            if (levelManager.caveTrack?.source == null) RegisterAudioSource(levelManager.caveTrack);
        }

        if (instance.curTrack != null) instance.curTrack.Stop();

        if (curScene.buildIndex == 0) instance.curTrack = instance.mainMenuTrack;
        else instance.curTrack = levelManager?.levelTrack.source;

        if (instance.curTrack != null) instance.curTrack.Play();
        // StartCoroutine(this.checkAudioSources());
    }

    /*
    private IEnumerator checkAudioSources()
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log($"{AudioManager.instance.GetComponents<AudioSource>().Length} Audio Sources");
    }
    */

    public static void SwitchTracks(bool onSurface)
    {
        if (instance.curTrack != null) instance.curTrack.Pause();
        instance.curTrack = onSurface ? LevelManager.instance?.levelTrack.source : LevelManager.instance?.caveTrack.source;
        instance.curTrack?.Play();
    }

    public void PauseAudio()
    {
        curTrack?.Pause();
    }

    public void ResumeAudio()
    {
        curTrack?.Play();
    }

    public void Switch()
    {
        curTrack?.Stop();
        instance.curTrack = Find("end");
        curTrack?.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hints : MonoBehaviour
{
    public Dialogue dialogue;
    public Text bodyText;
    public GameObject panel;
    public GameObject ui;
    GameObject gm;
    CharacterMovement movement;
    public static Dictionary<string, string> vs = new Dictionary<string, string>();
    private void Start()
    {
        gm = GameObject.Find("Fixed Joystick");
        movement = FindObjectOfType<CharacterMovement>();
        if (vs.Count == 0)
        {
            for (int i = 0; i < dialogue.names.Length; i++)
            {
                vs.Add(dialogue.names[i], dialogue.sentences[i]);
            }
        }
    }
    public void DisplayHint(string name)
    {
        if (!vs.ContainsKey(name))
        {
            return;
        }
        panel.SetActive(true);
        ui.SetActive(false);
        bodyText.text = vs[name];
        vs.Remove(name);
        //gm.SetActive(false);
        //movement.controller.input = new Vector2(0, 0);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
        ui.SetActive(true);
        //gm.SetActive(true);
        //movement.controller.input = new Vector2(0, 0);
    }
}

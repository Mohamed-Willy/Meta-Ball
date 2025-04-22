using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

[Serializable]
public class MatchData
{
    public string code;
    public string name;
    public Sprite image;
    public VideoClip clip;
}
public class MatchManager : MonoBehaviour
{
    [Space]
    [SerializeField, HideInInspector] TMPro.TMP_Text MatchName;
    [SerializeField, HideInInspector] Image MatchImage;
    [SerializeField, HideInInspector] Button SubmitButton;
    [SerializeField, HideInInspector] string dName;
    [SerializeField, HideInInspector] Sprite dImage;
    [SerializeField, HideInInspector] Text inputFieldText;
    [SerializeField, HideInInspector] VideoPlayer player;
    [SerializeField, HideInInspector] VideoClip dClip;
    [SerializeField] List<MatchData> data;
    [SerializeField, HideInInspector] UnityEvent OnSubmit;
    [Space]
    [SerializeField] MatchData curData;
    private void Awake()
    {
        player.clip = dClip;
        curData = new MatchData();
    }
    public void SearchMatch()
    {
        DOVirtual.DelayedCall(0.1f, () =>
        {
            string code = inputFieldText.text;
            foreach (MatchData data in data)
            {
                if (data.code == code)
                {
                    curData = data;
                    MatchImage.sprite = data.image;
                    MatchName.text = data.name;
                    SubmitButton.interactable = true;
                    return;
                }
            }
            MatchImage.sprite = dImage;
            MatchName.text = dName;
            SubmitButton.interactable = false;
        });
    }
    public void OpenMatch()
    {
        OnSubmit.Invoke();
        if (curData != null) { 
            player.clip = curData.clip;
        }
        DOVirtual.DelayedCall(2f, () =>
        {
            Destroy(gameObject);
        });
    }
}

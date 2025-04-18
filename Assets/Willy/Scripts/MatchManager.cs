using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public struct MatchData
{
    public string code;
    public string name;
    public Sprite image;
}
public class MatchManager : MonoBehaviour
{
    [SerializeField, HideInInspector] TMPro.TMP_Text MatchName;
    [SerializeField, HideInInspector] Image MatchImage;
    [SerializeField, HideInInspector] Button SubmitButton;
    [SerializeField, HideInInspector] string dName;
    [SerializeField, HideInInspector] Sprite dImage;
    [SerializeField, HideInInspector] Text inputFieldText;
    [SerializeField] List<MatchData> data;
    [SerializeField] UnityEvent OnSubmit;
    int indx;
    public void SearchMatch()
    {
        DOVirtual.DelayedCall(0.1f, () =>
        {
            indx = 0;
            string code = inputFieldText.text;
            foreach (MatchData data in data)
            {
                if (data.code == code)
                {
                    MatchImage.sprite = data.image;
                    MatchName.text = data.name;
                    SubmitButton.interactable = true;
                    return;
                }
                indx++;
            }
            MatchImage.sprite = dImage;
            MatchName.text = dName;
            SubmitButton.interactable = false;
        });
    }
    public void OpenMatch()
    {
        OnSubmit.Invoke();
        // TODO: Open Match
        DOVirtual.DelayedCall(2f, () =>
        {
            Destroy(gameObject);
        });
    }
}

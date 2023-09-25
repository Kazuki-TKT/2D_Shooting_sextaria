using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChnageText : MonoBehaviour,GetText
{
    [SerializeField]
    Text _text;

    [SerializeField]
    [Multiline(8)]
    private string _expText;

    public string ExpText => _expText;

    public void ChangeText()
    {
        _text.text = ExpText;
    }
}

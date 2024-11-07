using System.Collections;
using System.Collections.Generic;
using System.Security;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.SceneManagement;

public class TypingManager : MonoBehaviour
{
    public string[] inputStrings;
    public TextMeshProUGUI inputText;
    public TMP_InputField field;
    public TextMeshProUGUI fieldText;
    public RectTransform inputField;
    public GameObject startButton;
    public SpriteRenderer face;
    
    public bool isStart = false;

    int currentIndex = 0;

    private void Start()
    {
        inputField.anchoredPosition = new Vector3(0, 300, 0);
        fieldText.text = inputStrings[currentIndex];
    }

    public void StartGame()
    {
        isStart = true;
        inputField.anchoredPosition = new Vector3(0, 0, 0);
        Destroy(startButton);
    }

    public void InputFieldUpdate()
    {
        if(fieldText.color == Color.green)
        {
            face.color = Color.white;
            currentIndex++;
            if (currentIndex >= inputStrings.Length) SceneManager.LoadScene("Victory3");
            else fieldText.text = inputStrings[currentIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            field.ActivateInputField();
            field.Select();

            if (IsSame(inputText.text, fieldText.text))
            {
                fieldText.color = Color.green;
            }
            else
            {
                fieldText.color = Color.red;
            }
        }
        else
        {
            face.color = Color.white;
        }
    }

    bool IsSame(string _inputText, string _fieldText)
    {
        _inputText = Regex.Replace(_inputText, @"<.*?>", "");

        string currentString = new string("");
        for (int i = 0; i < Mathf.Min(_fieldText.Length, _inputText.Length); i++)
        {
            currentString += _inputText[i];
        }

        _inputText = currentString;

        if (_inputText == _fieldText)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI TextField;

    [SerializeField]
    private TypeWriter _typeWriter;

    [TextArea]
    public List<string> Texts;

    [SerializeField]
    private Button _button;


    [SerializeField]
    private List<GameObject> _showAdditionalInfos;

    public void OnClickWrite()
    {
        StartCoroutine(StartTyping());
    }

    public IEnumerator StartTyping()
    {
        _button.interactable = false;
        ShowAdditionalInformations(true);
        for (int i = 0; i < Texts.Count; i++)
        {
            _typeWriter.Type(Texts[i], WriteText);

            float length = Texts[i].Length ;

            if(length < 100)
            {
                length = 2.5f;
            } else if (length >= 100 && length < 300){

                length = 5f;

            } else if (length >= 300)
            {
                length = 10f;
            }

            yield return new WaitForSeconds(length);

        }
                
        ShowAdditionalInformations(false);
    }

    private void ShowAdditionalInformations(bool show)
    {
        if (_showAdditionalInfos == null) return;

       for (int i = 0; i < _showAdditionalInfos.Count; i++)
        {
            _showAdditionalInfos[i].SetActive(show);
        }
    }

    private void WriteText(string Text)
    {
        TextField.text = Text;
    }



}

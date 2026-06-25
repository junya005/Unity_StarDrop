using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// 文字送りの処理
/// </summary>
public class ChangeCaption : MonoBehaviour
{
    public bool IsComplete { get; private set; }

    public IEnumerator Display(TextMeshProUGUI textMeshPro, string caption, float speed, string initCaption = "")
    {
        IsComplete = false;

        if (initCaption != "")
        {
            textMeshPro.text = initCaption + "\n";
        }
        else
        {
            textMeshPro.text = "";
        }

        for (int i = 0; i < caption.Length; ++i)
        {
            textMeshPro.text += caption[i];
            yield return new WaitForSeconds(speed);
        }

        IsComplete = true;
    }
}

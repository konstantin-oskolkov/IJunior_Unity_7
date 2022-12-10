using UnityEngine;
using TMPro;

public abstract class Score : MonoBehaviour
{
   [SerializeField] protected TMP_Text Text;

   public void OnValueChanged(int value)
   {
      Text.text = value.ToString();
   }
}

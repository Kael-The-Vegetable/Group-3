using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace JDoddsNAIT.Utilities.Components
{
    [ExecuteAlways]
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class HudLabel : MonoBehaviour
    {
        private TextMeshProUGUI label;

        [Tooltip("If true, will trim the prefix and suffix and add spaces.")]
        [SerializeField] private bool trimText = true;
        [SerializeField, TextArea] private string prefix, suffix;

        public string Text
        {
            get => label.text;
            set => label.text = value;
        }
        public string Prefix
        {
            get => trimText
                    ? prefix.Trim() + " "
                    : prefix;
            set => prefix = value;
        }
        public string Suffix
        {
            get => trimText
                    ? " " + suffix.Trim()
                    : suffix;

            set => suffix = value;
        }

        private void OnValidate()
        {
            label = GetComponent<TextMeshProUGUI>();
        }

        void Start()
        {
            label = GetComponent<TextMeshProUGUI>();
            Debug.Assert(label != null);
        }

        public void SetStringText(string text) => SetText(text);
        public void SetIntText(int text) => SetText(text);
        public void SetBoolText(bool text) => SetText(text);
        public void SetFloatText(float text) => SetText(text);
        public void SetObjectText(Object obj) => SetText(obj);

        public void SetText(object text)
        {
            Text = Prefix + text.ToString() + Suffix;
        }
    }
}
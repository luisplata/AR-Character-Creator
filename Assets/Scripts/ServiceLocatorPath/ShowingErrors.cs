using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;
using UnityEngine.UI;

namespace ServiceLocatorPath
{
    public class ShowingErrors : MonoBehaviour, IShowErrors, ILocalization
    {
        [SerializeField] private Animator anim;
        [SerializeField] private TextMeshProUGUI title, message;
        [SerializeField] private Image colorOfMessage; 
        [SerializeField] private Color colorGood, colorbad;
        [SerializeField] private LocalizedStringTable stringTable;
        private StringTable _stringTable;

        public void Configurate()
        {
            _stringTable = stringTable.GetTable();
        }
        public void ShowError(string messageInMessage)
        {
            anim.SetBool("open", true);
            title.text = "Error";
            colorOfMessage.color = colorbad;
            message.text = messageInMessage;
        }
        private string GetLocalizedString(StringTable table, string entryName)
        {
            // Get the table entry. The entry contains the localized string and Metadata
            var entry = table.GetEntry(entryName);
            return entry.GetLocalizedString(); // We can pass in optional arguments for Smart Format or String.Format here.
        }

        public string Get(string key)
        {
            return GetLocalizedString(_stringTable, key);
        }

        public void Close()
        {
            anim.SetBool("open", false);
        }
    }
}
using System;
using Starload;
using Starload.UI.Menus;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menus
{
    public class StatusMenu : UIMenu
    {
        public Text statusText;
        public Text substatusText;
        public Button actionButton;

        public void OnEnable()
        {
            ActionVisible(false);
        }

        public void SetStatus(string status, string substatus)
        {
            statusText.text = status;
            substatusText.text = substatus;
        }

        public void SetAction(string label, Action action)
        {
            ActionVisible(true);
            Text buttonText = actionButton.GetComponentInChildren<Text>();
            buttonText.text = label;
            actionButton.onClick.AddListener(() => action());
        }

        public void ActionVisible(bool visible)
        {
            actionButton.gameObject.SetActive(visible);
        }

        public static Action GoToMain()
        {
            return () => GameManager.Instance.menus.SelectMenu<UIMenu>(0);
        }
    }
}
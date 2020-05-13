using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Starload.UI.Menus
{
    public class Menus : MonoBehaviour
    {
        public UIMenu defaultMenu;
        private UIMenu _selectedMenu;

        public List<UIMenu> menus;

        // Start is called before the first frame update
        void Start()
        {
            _selectedMenu = defaultMenu;
            UpdateSelectedMenu();
        }

        public T SelectMenu<T>(int index) where T : UIMenu
        {
            _selectedMenu = GetMenu<T>(index);
            UpdateSelectedMenu();
            return (T)_selectedMenu;
        }

        public T GetMenu<T>(int index) where T : UIMenu
        {
            return (T)menus.ElementAt(index);
        }
        
        public void UpdateSelectedMenu()
        {
            foreach (UIMenu menu in menus)
            {
                menu.gameObject.SetActive(menu == _selectedMenu);
            }
        }
    }
}

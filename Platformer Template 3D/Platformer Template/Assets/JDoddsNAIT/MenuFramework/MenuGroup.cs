using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDoddsNAIT.Unity.MenuFramework
{
    public class MenuGroup : MonoBehaviour
    {
        [SerializeField] private List<Menu> _group;

        public Menu this[int i]
        {
            get => _group[i];
            set => _group[i] = value;
        }

        public void SetCurrentMenu(int index)
        {
            CloseGroup();

            _group[index].OpenMenu();
        }

        // These methods exist so they can be called through UnityEvents.
        public void OpenMenu(int index) => _group[index].OpenMenu();
        public void CloseMenu(int index) => _group[index].CloseMenu();

        public void CloseGroup()
        {
            foreach (var menu in _group)
            {
                menu.CloseMenu();
            }
        }
    }
}
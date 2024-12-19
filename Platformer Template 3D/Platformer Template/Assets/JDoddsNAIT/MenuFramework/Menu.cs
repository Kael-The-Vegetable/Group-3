using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace JDoddsNAIT.Unity.MenuFramework
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CanvasGroup))]
    public class Menu : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;
        private EventSystem _eventSystem;

        [SerializeField] private bool _startOpen = true;

        [Header("Automations")]
        [SerializeField] private bool _autoToggleElements = true;
        [SerializeField] private bool _autoSelectFirstElement = true;
        [SerializeField] private bool _autoSetActive = true;

        [Header("Events")]
        [SerializeField] private UnityEvent onMenuOpen;
        [SerializeField] private UnityEvent onMenuClose;

        private bool _isOpen;

        public bool IsOpen
        {
            get { return _isOpen; }
            set
            {
                // _isOpen is set in the methods below
                if (value)
                {
                    OpenMenu();
                }
                else
                {
                    CloseMenu();
                }
            }
        }

        public EventSystem EventSystem
        {
            get
            {
                if (_eventSystem == null)
                {
                    _eventSystem = FindFirstObjectByType<EventSystem>();
                }
                return _eventSystem;
            }

            private set => _eventSystem = value;
        }

        public UnityEvent OnMenuOpen { get => onMenuOpen; set => onMenuOpen = value; }
        public UnityEvent OnMenuClose { get => onMenuClose; set => onMenuClose = value; }

        private void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();

            if (_startOpen)
            {
                OpenMenu(force: true);
            }
            else
            {
                CloseMenu(force: true);
            }
        }

        private void OnValidate()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OpenMenu() => OpenMenu(false);
        public void OpenMenu(bool force = false)
        {
            // We allow for forcing to ensure the menu has the correct initial state.
            if (!IsOpen || force)
            {
                if (_autoToggleElements)
                {
                    SetSelectables(true);
                }

                // Using the field instead of the property to avoid a StackOverflow
                _isOpen = true;
                OnMenuOpen.Invoke();

                if (_autoSelectFirstElement)
                {
                    SelectElement(0);
                }

                if (_autoSetActive)
                {
                    gameObject.SetActive(true);
                }
            }
        }

        public void CloseMenu() => CloseMenu(false);
        public void CloseMenu(bool force = false)
        {
            // We allow for forcing to ensure the menu has the correct initial state.
            if (IsOpen || force)
            {
                if (_autoToggleElements)
                {
                    SetSelectables(false);
                }

                // Using the field instead of the property to avoid a StackOverflow
                _isOpen = false;
                OnMenuClose.Invoke();
                Debug.Log("wth");
                if (_autoSetActive)
                {
                    gameObject.SetActive(false);
                }
            }
        }

        public void SelectElement(int index)
        {
            GameObject element = _canvasGroup.GetComponentsInChildren<Selectable>()[index].gameObject;
            if (element != null)
            {
                EventSystem.SetSelectedGameObject(element);
            }
        }

        public void SetSelectables(bool state)
        {
            _canvasGroup.interactable = state;
        }

        // Animator events are so annoying
        public void ToggleSelectables() => _canvasGroup.interactable = !_canvasGroup.interactable;
        public void EnableSelectables() => SetSelectables(true);
        public void DisableSelectables() => SetSelectables(false);
    }
}
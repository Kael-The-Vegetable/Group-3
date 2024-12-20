using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDoddsNAIT.Utilities.Components
{
    public class Billboard : MonoBehaviour
    {
        [Tooltip("The camera to look at. If null, will use Camera.main instead.")]
        [SerializeField] private new Camera camera;

        private void Start()
        {
            if (camera == null)
            {
                camera = Camera.main;
            }
        }

        private void Update()
        {
            if (enabled)
            {
                transform.LookAt(camera.transform);
            }
        }
    }
}
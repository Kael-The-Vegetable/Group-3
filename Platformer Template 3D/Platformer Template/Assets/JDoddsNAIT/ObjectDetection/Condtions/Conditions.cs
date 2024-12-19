using UnityEditor;
using UnityEngine;

namespace JDoddsNAIT.ObjectDetection
{
    [System.Serializable]
    public abstract class Conditions
    {
        public enum Types
        {
            None = 0,
            CompareTag = 1,
            HasComponent = 2,
            //HasScript = 3,
            InLineOfSight = 4,
        }

        public static implicit operator Condition.Evaluation(Conditions value)
        {
            return value.Evaluate;
        }

        protected abstract bool Evaluate(GameObject obj);

        [System.Serializable]
        public class None : Conditions
        {
            [SerializeField] private bool returnValue = true;
            protected override bool Evaluate(GameObject gameObject)
            {
                return returnValue;
            }
        }

        [System.Serializable]
        public class CompareTag : Conditions
        {
            [SerializeField, TagField] private string tag;
            protected override bool Evaluate(GameObject obj)
            {
                return obj.CompareTag(tag);
            }
        }

        [System.Serializable]
        public class HasComponent : Conditions
        {
            [SerializeField] private ComponentTypeField component;
            protected override bool Evaluate(GameObject obj)
            {
                var componentInParent = obj.GetComponentInParent(component.Type);
                var componentInChild = obj.GetComponentInChildren(component.Type);
                return obj.TryGetComponent(component.Type, out _)
                    || componentInParent != null || componentInChild != null;
            }
        }

//        [System.Serializable]
//        public class HasScript : Conditions
//        {
//#if UNITY_EDITOR
//            [SerializeField, OnValueChanged(nameof(SetType))] private MonoScript selectScript;

//            void SetType()
//            {
//                type = selectScript.GetClass();
//            }
//#endif
//            [SerializeField] private System.Type type;

//            protected override bool Evaluate(GameObject obj)
//            {
//                var componentInParent = obj.GetComponentInParent(type);
//                var componentInChild = obj.GetComponentInChildren(type);
//                return obj.TryGetComponent(type, out _) 
//                    || componentInParent != null || componentInChild != null;
//            }
//        }

        [System.Serializable]
        public class InLineOfSight : Conditions
        {
            [SerializeField] private Transform origin;
            [SerializeField] private LayerMask obstacleMask = Physics.DefaultRaycastLayers;
            [SerializeField] private QueryTriggerInteraction queryTriggerInteraction;
            [SerializeField] private ColorSettings colors;
            protected override bool Evaluate(GameObject obj)
            {
                var from = this.origin.position;
                var to = obj.transform.position;

                bool result = !Physics.Linecast(from, to, obstacleMask, queryTriggerInteraction);

                if (colors.ShowLineCasts)
                {
                    Debug.DrawLine(from, to, colors.GetColor(result));
                }

                return result;
            }

            [System.Serializable]
            private struct ColorSettings
            {
                [field: SerializeField] public bool ShowLineCasts { get; set; }
                [field: SerializeField] public Color TrueColor { get; set; }
                [field: SerializeField] public Color FalseColor { get; set; }

                public readonly Color GetColor(bool value) => value ? TrueColor : FalseColor;
            }
        }
    }
}

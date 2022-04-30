using UnityEngine;

namespace Utils
{
    public class Highlighter : MonoBehaviour
    {
        public Color selectionColor;
        public bool targetChildren, isEnabled = true;

        private Renderer _parentRenderer;
        private Color _parentColour;
        
        private Renderer[] _childRenderers;
        private Color[] _childColours;
        
        private static readonly int Color1 = Shader.PropertyToID("_Color");
        
        private void Start()
        {
            _parentRenderer = GetComponent<Renderer>();

            if (_parentRenderer != null)
                _parentColour = _parentRenderer.material.GetColor(Color1);
            
            if (targetChildren)
            {
                _childRenderers = gameObject.GetComponentsInChildren<Renderer>();
                _childColours = new Color[_childRenderers.Length];
                var index = 0;

                foreach (var rend in _childRenderers)
                {
                    _childColours[index] = rend.material.GetColor(Color1);
                    index++;
                }
            }
        }

        private void OnMouseOver()
        {
            if (!isEnabled) return;
            
            if (_parentRenderer != null)
                _parentRenderer.material.color = selectionColor;
            
            if (targetChildren)
            {
                foreach (var rend in _childRenderers)
                {
                    rend.material.color = selectionColor;
                }
            }
        }

        private void OnMouseExit()
        {
            if (_parentRenderer != null)
                _parentRenderer.material.color = _parentColour;
            
            if (targetChildren)
            {
                var index = 0;
            
                foreach (var rend in _childRenderers)
                {
                    rend.material.color = _childColours[index];
                    index++;
                }
            }
        }
    }
}

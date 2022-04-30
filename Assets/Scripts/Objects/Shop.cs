using System;
using UnityEngine;

namespace Objects
{
    public class Shop : MonoBehaviour
    {
        public GameObject shopPanel;

        public void Start()
        {
            shopPanel.SetActive(false);
        }

        private void OnMouseDown()
        {
            shopPanel.SetActive(!shopPanel.activeSelf);
        }
    }
}

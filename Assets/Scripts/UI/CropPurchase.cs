using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class CropPurchase : MonoBehaviour, IPointerDownHandler
    {
        [Header("Crop Placement")]
        public GameObject cropPrefab;

        [Header("UI Properties")]
        public TMP_Text title;
        public Image icon;
        public bool isLocked = true;

        [Header("Enabled Parameters")] 
        public string enabledName;
        public Sprite enabledIcon;
        
        [Header("Locked Parameters")] 
        public string lockedName;
        public Sprite lockedIcon;
        
        public static bool DraggingCrop;
        private static GameObject _cropPrefab;

        public static GameObject GetCurrentCrop()
        {
            return _cropPrefab;
        }

        public void UnlockCrop()
        {
            isLocked = false;
            
            title.text = enabledName;
            icon.sprite = enabledIcon;
        }
        
        public void LockCrop()
        {
            isLocked = true;
            
            title.text = lockedName;
            icon.sprite = lockedIcon;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (isLocked) return;
            
            DraggingCrop = true;
            _cropPrefab = cropPrefab;
        }

        private void Start()
        {
            if (isLocked)
            {
                title.text = lockedName;
                icon.sprite = lockedIcon;
            }

            else
            {
                title.text = enabledName;
                icon.sprite = enabledIcon;
            }
        }

        private void Update()
        {
            if (isLocked) return;
            
            if (DraggingCrop && !Input.GetMouseButton(0))
            {
                DraggingCrop = false;
                _cropPrefab = null;
            }
        }
    }
}

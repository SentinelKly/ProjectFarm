using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

namespace Rendering
{
	public class ScaleAspect : MonoBehaviour
	{
		[Header("Render Target Scaling")]
		public RawImage renderImage;
		public float downScaler = 3f;

		private Camera _renderCamera;
		private RenderTexture _renderTex;

		public void UpdateScale()
		{
			System.Diagnostics.Debug.Assert(Camera.main != null, "Camera.main != null");

			Camera[] cams = Camera.allCameras;

			foreach (var cam in cams)
			{
				if (!cam.gameObject.CompareTag("RenderCamera")) continue;
			
				_renderCamera = cam;
				break;
			}

			var resolution = Screen.currentResolution;
			var renderX = resolution.width / downScaler;
			var renderY = resolution.height / downScaler;
			
			_renderTex = new RenderTexture(Mathf.RoundToInt(renderX), Mathf.RoundToInt(renderY), 32, GraphicsFormat.R8G8B8A8_UNorm)
			{
				antiAliasing = 1,
				filterMode = FilterMode.Point
			};
		
			if (_renderCamera.targetTexture != null)
				_renderCamera.targetTexture.Release();
		
			_renderCamera.targetTexture = _renderTex;
		
			renderImage.texture = _renderTex;
		}
		
		private void Start()
		{
			UpdateScale();
		}
	}
}

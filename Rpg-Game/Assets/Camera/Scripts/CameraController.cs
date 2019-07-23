using UnityEngine;
using System.Collections;

namespace GameCamera
{
	public class CameraController : MonoBehaviour
	{
		public Transform target;
		public float smoothing = 5f;

		public Vector3 offset = new Vector3(
			0,10,-5
		);

		void FixedUpdate ()
		{
			if(!target){
				target = GameObject.FindGameObjectWithTag("Player").transform;
			}
			transform.LookAt(target);
			Vector3 targetCamPos = target.position + offset;
			transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
		}
	}
}

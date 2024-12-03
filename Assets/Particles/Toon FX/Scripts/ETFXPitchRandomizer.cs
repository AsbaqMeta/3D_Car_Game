using UnityEngine;
using System.Collections;

namespace EpicToonFX
{

	public class ETFXPitchRandomizer : MonoBehaviour
	{
	
		public float randomPercent = 10;

        private void OnEnable()
        {            
            Invoke("SetFalse", 1.1f);
        }

        private void OnDisable()
        {
            CancelInvoke();
        }

        void SetFalse()
        {
            gameObject.SetActive(false);
        }

        void Start ()
		{
        transform.GetComponent<AudioSource>().pitch *= 1 + Random.Range(-randomPercent / 100, randomPercent / 100);
		}
	}
}
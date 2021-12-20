using Unity.Netcode;
using UnityEngine;

namespace PlayerActive
{
    public class PlayerActive : NetworkBehaviour
    {
        public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

        [SerializeField]
        Behaviour[] componentsToDisable;
        [SerializeField]
        Behaviour[] componentsToEnable;
        private Camera startcam;
        // Start is called before the first frame update
        private void Start()
        {
            Application.targetFrameRate = 60;
            //desactive les compo des autres

            Debug.Log("New player");
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }

            if (IsLocalPlayer)
            {

                Debug.Log("New player (me)");
                for (int i = 0; i < componentsToEnable.Length; i++)
                {//jaaj
                    componentsToEnable[i].enabled = true;
                }
                startcam = Camera.main;
                startcam.gameObject.SetActive(false);
            }
        }
        

        
       

        void Update()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
           // transform.position = Position.Value;
        }
        
        private void OnDisable()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (startcam != null)
            {
                startcam.gameObject.SetActive(true);
            }
        }

        
    }
}
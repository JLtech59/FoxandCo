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
            //desactive les compo des autres

            Debug.Log("New player");
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }

            if (IsOwner)
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
        public override void OnNetworkSpawn()
        {
            if (IsOwner)
            {
                Debug.Log("New player");
                for (int i = 0; i < componentsToDisable.Length; i++)
                {
                    componentsToDisable[i].enabled = false;
                }

                if (IsOwner)
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
        }

        public void Move()
        {
            if (NetworkManager.Singleton.IsServer)
            {

                //var randomPosition = GetRandomPositionOnPlane();
                //transform.position = randomPosition;
                transform.position = new Vector3(100, 5, 100) ;
                //Position.Value = randomPosition;
                Position.Value = new Vector3(100, 5, 100);
                //GetComponent<vThirdPersonController>.
            }
            else
            {
                SubmitPositionRequestServerRpc();
            }
        }

        [ServerRpc]
        void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default)
        {
            Position.Value = GetRandomPositionOnPlane();
        }

        static Vector3 GetRandomPositionOnPlane()
        {
            return new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 3f));
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
using Photon.Pun;
using UnityEngine;

namespace Game1.Scripts
{
    public class CameraController : MonoBehaviour
    {

        //void Start()
        //{
        //    GameObject[] cameras = GameObject.FindGameObjectsWithTag("MainCamera");
        //    foreach (GameObject player in cameras)
        //    {
        //        if (PhotonView.Get(player).IsMine == false)
        //        {
        //            Destroy(player.GetComponent<CameraController>().gameObject);
        //        }
        //    }
        //}

        void Start()
        {
            GameObject[] cameras = GameObject.FindGameObjectsWithTag("MainCamera");
            foreach (GameObject player in cameras)
            {
                if (PhotonView.Get(player).IsMine == false)
                {
                    Destroy(player.GetComponent<CameraController>().gameObject);
                }
            }
        }
    }
}

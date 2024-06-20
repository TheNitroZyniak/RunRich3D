using UnityEngine;
using DG.Tweening;

public class Checkpoint : MonoBehaviour{
    [SerializeField] private Transform[] flags;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            AudioManager.instance.PlaySound(4);
            RaiseFlags();
        }
    }

    void RaiseFlags() {
        for(int i = 0; i < flags.Length; i++) {
            Vector3 rot = flags[i].rotation.eulerAngles;
            rot.z = 0;
            flags[i].DORotate(rot, 0.5f);
        }
        
    }

}

using UnityEngine;

public class SwayPhysicsXAxisOnly : MonoBehaviour {
    
    private void Update() {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
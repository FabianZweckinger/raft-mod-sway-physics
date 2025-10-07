using UnityEngine;

public class SwayPhysicsBasic : MonoBehaviour {
    
    private void Update() {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
using UnityEngine;

public class SwayPhysicsYAxisOnly : MonoBehaviour {

    private void Update() {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
    }
}

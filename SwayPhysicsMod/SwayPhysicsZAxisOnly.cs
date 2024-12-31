using UnityEngine;

public class SwayPhysicsZAxisOnly : MonoBehaviour {

    private void Update() {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
    }
}

using UnityEngine;
using System.Collections;

public class BringToFront : MonoBehaviour {

	// Use this for initialization
    void OnEnable()
    {
        transform.SetAsLastSibling();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Apple"){
            Debug.Log("キャッチ！");
            this.aud.PlayOneShot(this.appleSE);
        }else{
            Debug.Log("アウト！");
            this.aud.PlayOneShot(this.bombSE);
        }
        Destroy(other.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x,0,z);
            }
        }

    }
}

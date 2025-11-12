using UnityEngine;

public class CollectAmmo : MonoBehaviour
{
    public int ammo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammo > 0) {
            ammo--;

            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit result;

            Physics.Raycast(ray, out result);

            GameObject g = result.collider.gameObject;
            Debug.Log(""+g.name);

            if (g.name == "Target") {
                Animation a = g.transform.parent.GetComponent<Animation>();
                a.Play("LowerBridge");
            }
        }

        else if (Input.GetButtonDown("Fire1") && ammo == 0) {
            AudioSource na = GetComponent<AudioSource>();
            na.Play();
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "AmmoBox") {
            ammo = 20;
            AudioSource rg = GetComponent<AudioSource>();
            rg.Play();
            other.gameObject.SetActive(false);
        }
    }
}

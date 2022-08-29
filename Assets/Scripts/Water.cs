using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<MainCube>().killHer();
        }
        else if (other.gameObject.CompareTag("Positive"))
        {
            Destroy(other.gameObject);
            GameObject.Find("Collector").transform.Translate(0, 1, 0);
        }
    }
}
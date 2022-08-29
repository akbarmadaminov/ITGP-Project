using UnityEngine;

public class BonusMult : MonoBehaviour
{
    public int multiplyBy;
    public bool OnlyOneDestroy;
    private bool isUsed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (OnlyOneDestroy && isUsed) return;

        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.GetComponent<MainCube>().youWinWithX(multiplyBy);
        }
        else if (other.gameObject.CompareTag("Positive"))
        {
            Destroy(other.gameObject);
            isUsed = true;
            GameObject.Find("Collector").transform.Translate(0, 1, 0);

            if (!OnlyOneDestroy)
            {
                GameObject.Find("MainCube").GetComponent<MainCubeMoving>().direction = 0;
                GameObject.Find("MainCube").GetComponent<MainCube>().youWinWithX(multiplyBy);
            }
        }
    }
}
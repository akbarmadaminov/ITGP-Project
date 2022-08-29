using UnityEngine;

public class WhenCollect : MonoBehaviour
{
    public GameObject mainCube;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gems"))
        {
            Destroy(other.gameObject);
            mainCube.GetComponent<MainCube>().addScore();
            return;
        }
        
        GameObject newCubeObj = other.gameObject;
        var newCube = newCubeObj.GetComponent<Cube>();
        
        if (newCube != null && newCubeObj.transform.parent == null)
        {
            mainCube.transform.Translate(0, newCube.height, 0);
            transform.Translate(0, -newCube.height, 0);
            
            Vector3 newCubePos = mainCube.transform.position;
            newCubePos.y = 1;
            newCubeObj.transform.position = newCubePos;
            
            while (newCubeObj.transform.childCount > 0)
            {
                newCubeObj.transform.GetChild(0).parent = mainCube.transform;
            }
            newCubeObj.transform.parent = mainCube.transform;
        }        
    }
}

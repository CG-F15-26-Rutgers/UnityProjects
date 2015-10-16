using UnityEngine;
using System.Collections;

public class CubesMoves : MonoBehaviour {

    public Vector3 pointB;

    IEnumerator Start()
    {
        Vector3 pointA = transform.position;
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 start, Vector3 end, float time)
    {
        float i = 0.0f;
        float rate = 3.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(start, end, i);
            yield return null;
        }
    }
}

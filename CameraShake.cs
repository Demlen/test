using UnityEngine;
using System.Collections;
//---------------------
public class CameraShake : MonoBehaviour
{
private Transform ThisTransform = null;
//Total time for shaking in seconds
public float ShakeTime = 2.0f;

//Shake amount - distance to offset in any direction
public float ShakeAmount = 3.0f;
//Speed of camera moving to shake points
public float ShakeSpeed = 2.0f;
//---------------------
// Use this for initialization
void Start ()
{
//Get transform component
ThisTransform = GetComponent<Transform>();
//Start shaking
StartCoroutine(Shake());
}
//---------------------
//Shake camera
public IEnumerator Shake()
{
//Store original camera position
Vector3 OrigPosition = ThisTransform.localPosition;
//Count elapsed time (in seconds)
float ElapsedTime = 0.0f;
//Repeat for total shake time
while(ElapsedTime < ShakeTime)
{
//Pick random point on unit sphere
Vector3 RandomPoint = OrigPosition +
Random.insideUnitSphere * ShakeAmount;
//Update Position
ThisTransform.localPosition =
Vector3.Lerp(ThisTransform.localPosition, RandomPoint,
Time.deltaTime * ShakeSpeed);
//Break for next frame
yield return null;
//Update time
ElapsedTime += Time.deltaTime;
}
//Restore camera position
ThisTransform.localPosition = OrigPosition;
}
//---------------------
}
//---------------------
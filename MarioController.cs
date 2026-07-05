using System;

public class MarioController : MonoBehaviour
{
    public GameObject Mario;
    public float moveSpeed;

    void Update()
    {
        float xDir = Input.GetAxisRaw("Horizontal");
        Mario.transform.position += new Vector3(xDir, 0, 0) * Time.deltaTime * moveSpeed;
    }
}

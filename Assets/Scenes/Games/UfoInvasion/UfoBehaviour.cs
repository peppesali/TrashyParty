using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoBehaviour : MonoBehaviour
{
    public GameObject LaserPrefab, UfoReleasePrefab;
    public float speed;
    public enum UfoType
    {
        Beige,
        Blue,
        Green,
        Pink,
        Yellow
    }
    public UfoType Type;

    // Start is called before the first frame update
    void Start()
    {
        if (this.Type == UfoType.Pink) StartCoroutine(UseLasers());
        if (this.Type == UfoType.Yellow) StartCoroutine(UseUfoRelease());
    }

    IEnumerator UseUfoRelease()
    {
        yield return new WaitForSeconds(3);
        Instantiate(UfoReleasePrefab, this.transform);
        StartCoroutine(UseUfoRelease());
    }
    IEnumerator UseLasers()
    {
        yield return new WaitForSeconds(5);
        float laserSpd = 0.05f;
        GameObject a = Instantiate(LaserPrefab, this.transform);
        GameObject b = Instantiate(LaserPrefab, this.transform);
        GameObject c = Instantiate(LaserPrefab, this.transform);
        GameObject d = Instantiate(LaserPrefab, this.transform);
        a.GetComponent<LaserUfoBehaviour>().Initialize(new Vector2(laserSpd, laserSpd));
        b.GetComponent<LaserUfoBehaviour>().Initialize(new Vector2(-laserSpd, laserSpd));
        c.GetComponent<LaserUfoBehaviour>().Initialize(new Vector2(laserSpd, -laserSpd));
        d.GetComponent<LaserUfoBehaviour>().Initialize(new Vector2(-laserSpd, -laserSpd));
        StartCoroutine(UseLasers());
    }

    // Update is called once per frame
    private bool hasSetMovement = false;
    void FixedUpdate()
    {
        if ((this.Type == UfoType.Beige || this.Type == UfoType.Pink || this.Type == UfoType.Yellow) && !hasSetMovement)
        {
            hasSetMovement = true;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -1, 0);
        }
    }
}

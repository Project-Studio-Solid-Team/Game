using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TardisController2D : MonoBehaviour
{
    float maxSpeed = 15.0f;
    float rotSpeed = 250f;
    private int cp = 0;
    private bool controllable = true;
    public LevelVariables lv;
    Vector3 origin;
    Vector4 dmgCol1 = new Vector4(0.7f, 0.0f, 0.0f, 0.9f);
    Vector4 dmgCol2 = new Vector4(0.0f, 0.0f, 0.0f, 0.1f);   

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        Debug.Log(origin);  
    }

    void Update()
    {
        if (controllable)
        {
            // Ship rotations
            Quaternion rot = transform.rotation;
            float z = rot.eulerAngles.z;
            z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
            rot = Quaternion.Euler(0, 0, z);
            transform.rotation = rot;

            // Ship movement
            Vector3 pos = transform.position;
            Vector3 vel = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
            pos += rot * vel;
            transform.position = pos;
        }
    }

    // Player Interaction check
    public void TakeDamage()
    {
        StartCoroutine(Reset());
        StartCoroutine(DmgAnim());
    }

    // Return to origin on hazard collision
    public IEnumerator Reset(){
        //Send player back to origin/checkpoint

        this.GetComponent<TrailRenderer>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        transform.position = origin;

        //Re-enable keyboard and trail renderer
        yield return new WaitForSeconds(1.5f);
        this.GetComponent<TrailRenderer>().enabled = true;
    }

    // Change sprite opacity to indicate damage taken
    public IEnumerator DmgAnim(){
        //Start color flash loop
        Vector4 baseCol = this.GetComponent<SpriteRenderer>().color;
        int count = 0;
        controllable = false;
        while (count < 5)
        {
            this.GetComponent<SpriteRenderer>().color = dmgCol1;
            yield return new WaitForSeconds(0.1f);
            this.GetComponent<SpriteRenderer>().color = dmgCol2;
            yield return new WaitForSeconds(0.1f);
            count++;
        }
        this.GetComponent<SpriteRenderer>().color = baseCol;
        controllable = true;
    }

    // Landing transformation
    public void Landing()
    {
        StartCoroutine(Shrink());
    }

    private IEnumerator Shrink()
    {
        float size = 1.0f;
        while (size >= 0.05f)
        {
            size -= 0.02f;
            this.transform.localScale = new Vector3(size, size, size);
            if (size <= 0.85f)
            {
                controllable = false;
            }
            yield return new WaitForSeconds(0.05f);
        }
        lv.LevelSuccess();
    }

    // Set CP value
    public void SetCp(int x)
    {
        cp = x;
    }

    // Set origin value
    public void SetOrigin(Vector3 x)
    {
        origin = x;
    }

    // Get CP value
    public int GetCp()
    {
        return cp;
    }

}

using UnityEngine;

public class ShrinkController : MonoBehaviour {

    private Vector3 targetScale;                //Target scale size for next shrinkage
    private float shrinkFactor = 0.75f;         //Shrink by this much
    private float shrinkSpeed = 3f;             //Shrink this fast
    private float timeBetweenShrinkage = 3;     //Time between each shrink
    private float nextShrinkageTime;            //Next shrink time
    private Vector3 minimumScale;               //Will not shrink below this point

    // Use this for initialization
    void Start() {
        this.minimumScale = this.getTargetScale(0.25f);
        this.nextShrinkageTime = this.getNextShrinkageTime();
        this.targetScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update () {

        if (!this.canShrink())
        {
            return;
        }

        if (Time.time > this.nextShrinkageTime)
        {
            this.setTargetScale();
            this.setNextShrinkageTime();
        }

        this.shrink();
    }

    private void shrink()
    {
        if (this.transform.localScale.magnitude - this.targetScale.magnitude > 0.1f)
        {
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, targetScale, shrinkSpeed * Time.deltaTime);
        }
    }

    private bool canShrink()
    {
        return this.transform.localScale.magnitude > this.minimumScale.magnitude;
    }

    private void setTargetScale()
    {
        this.targetScale = this.getTargetScale(this.shrinkFactor);
    }

    private void setNextShrinkageTime()
    {
        this.nextShrinkageTime = this.getNextShrinkageTime();
    }

    private Vector3 getTargetScale(float shrinkFactor)
    {
        return new Vector3(this.transform.localScale.x* shrinkFactor, this.transform.localScale.y, this.transform.localScale.z* shrinkFactor);
    }

    private float getNextShrinkageTime()
    {
        return Time.time + this.timeBetweenShrinkage;
    }
}

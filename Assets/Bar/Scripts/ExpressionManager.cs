using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class ExpressionManager : MonoBehaviour
{
    [SerializeField] Material baseMat;
    [SerializeField] Material baseEyesMat;
    [SerializeField] Material angryMat;
    [SerializeField] Material angryMouthMat;
    [SerializeField] Material angryEyesMat;
    [SerializeField] Material angryEyesMouthMat;
    [SerializeField] Material happyMat;
    [SerializeField] Material upsetMat;
    [SerializeField] Material upsetEyesMat;
    [SerializeField] Material talkMat;
    [SerializeField] Material talkEyesMat;

    [SerializeField] Material scarfMat;
    [SerializeField] Material bodyMat;
    [SerializeField] Material clothMat;
    [SerializeField] Material shirtMat;
    [SerializeField] Material hatMat;

    [SerializeField] Material[] mats;

    [SerializeField] bool isBase;
    [SerializeField] bool isBaseMouth;
    [SerializeField] bool isAngry;
    [SerializeField] bool isHappy;
    [SerializeField] bool isUpset;
    [SerializeField] bool isTalk;

    Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        InvokeRepeating("BlinkingMethod",1, 3);
    }

    private void Update()
    {
        mats = rend.materials;

        if (isBase)
        {
            isBase = false;
            mats[0] = clothMat;
            mats[1] = shirtMat;
            mats[2] = bodyMat;
            mats[3] = scarfMat;
            mats[4] = baseMat;
            mats[5] = hatMat;
            rend.materials = mats;
        }
        else if (isBaseMouth)
        {
            isBaseMouth = false;
            mats[0] = clothMat;
            mats[1] = shirtMat;
            mats[2] = bodyMat;
            mats[3] = scarfMat;
            mats[4] = baseEyesMat;
            mats[5] = hatMat;
            rend.materials = mats;
        }
        else if (isAngry)
        {
            isAngry = false;
            mats[0] = clothMat;
            mats[1] = shirtMat;
            mats[2] = bodyMat;
            mats[3] = scarfMat;
            mats[4] = angryMat;
            mats[5] = hatMat;
            rend.materials = mats;
        }
        else if (isHappy)
        {
            isHappy = false;
            mats[0] = clothMat;
            mats[1] = shirtMat;
            mats[2] = bodyMat;
            mats[3] = scarfMat;
            mats[4] = happyMat;
            mats[5] = hatMat;
            rend.materials = mats;
        }
        else if (isTalk)
        {
            isTalk = false;
            mats[0] = clothMat;
            mats[1] = shirtMat;
            mats[2] = bodyMat;
            mats[3] = scarfMat;
            mats[4] = talkMat;
            mats[5] = hatMat;
            rend.materials = mats;
        }
        else if (isUpset)
        {
            isUpset = false;
            mats[0] = clothMat;
            mats[1] = shirtMat;
            mats[2] = bodyMat;
            mats[3] = scarfMat;
            mats[4] = upsetMat;
            mats[5] = hatMat;
            rend.materials = mats;
        }
    }

    void BlinkingMethod()
    {
        isBase = true;
        if (isBase)
        {
            isBase = false;
            StartCoroutine(Blink());
        }
    }

    IEnumerator Blink()
    {
        isBaseMouth = true;
        yield return new WaitForSeconds(0.2f);
        isBase = true;
    }

    public bool SetBaseActive()
    {
        return isBase = true;
    }

    public bool SetAngryActive()
    {
        return isAngry = true;
    }

    public bool SetUpsetActive()
    {
        return isUpset = true;
    }

    public bool SetHappyActive()
    {
        return isHappy = true;
    }

    public bool SetTalkActive()
    {
        return isTalk = true;
    }


}

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
    [SerializeField] bool isBaseCheck;
    [SerializeField] bool isAngry;
    [SerializeField] bool isAngryCheck;
    [SerializeField] bool isHappy;
    [SerializeField] bool isUpset;
    [SerializeField] bool isUpsetCheck;
    [SerializeField] bool isTalk;
    [SerializeField] bool isTalkCheck;

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
            isBaseCheck = true;
            isTalkCheck = false;
            isUpsetCheck = false;
            isAngryCheck = false;
            isBase = false;
            mats[0] = clothMat;
            mats[1] = shirtMat;
            mats[2] = bodyMat;
            mats[3] = scarfMat;
            mats[4] = baseMat;
            mats[5] = hatMat;
            rend.materials = mats;
        }
        else if (isAngry)
        {
            isBaseCheck = false;
            isTalkCheck = false;
            isUpsetCheck = false;
            isAngryCheck = true;
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
            isBaseCheck = false;
            isTalkCheck = false;
            isUpsetCheck = false;
            isAngryCheck = false;
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
            isBaseCheck = false;
            isTalkCheck = true;
            isUpsetCheck = false;
            isAngryCheck = false;
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
            isBaseCheck = false;
            isTalkCheck = false;
            isUpsetCheck = true;
            isAngryCheck = false;
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
        Debug.Log("Parpadeo");
        if (isBaseCheck)
        {
            StartCoroutine(BlinkNormal());
        }
        else if (isUpsetCheck)
        {
            StartCoroutine(BlinkUpset());
        }
        else if (isTalkCheck)
        {
            StartCoroutine(BlinkTalk());
        }
        else if(isAngryCheck)
        {
            StartCoroutine(BlinkAngry());
        }
    }

    IEnumerator BlinkNormal()
    {
        mats[0] = clothMat;
        mats[1] = shirtMat;
        mats[2] = bodyMat;
        mats[3] = scarfMat;
        mats[4] = baseEyesMat;
        mats[5] = hatMat;
        rend.materials = mats;

        yield return new WaitForSeconds(0.2f);

        mats[0] = clothMat;
        mats[1] = shirtMat;
        mats[2] = bodyMat;
        mats[3] = scarfMat;
        mats[4] = baseMat;
        mats[5] = hatMat;
        rend.materials = mats;
    }

    IEnumerator BlinkAngry()
    {
        mats[0] = clothMat;
        mats[1] = shirtMat;
        mats[2] = bodyMat;
        mats[3] = scarfMat;
        mats[4] = angryEyesMat;
        mats[5] = hatMat;
        rend.materials = mats;

        yield return new WaitForSeconds(0.2f);

        mats[0] = clothMat;
        mats[1] = shirtMat;
        mats[2] = bodyMat;
        mats[3] = scarfMat;
        mats[4] = angryMat;
        mats[5] = hatMat;
        rend.materials = mats;
    }

    IEnumerator BlinkUpset()
    {
        Debug.Log("Eyes");
        mats[0] = clothMat;
        mats[1] = shirtMat;
        mats[2] = bodyMat;
        mats[3] = scarfMat;
        mats[4] = upsetEyesMat;
        mats[5] = hatMat;
        rend.materials = mats;

        yield return new WaitForSeconds(0.2f);

        Debug.Log("no");
        mats[0] = clothMat;
        mats[1] = shirtMat;
        mats[2] = bodyMat;
        mats[3] = scarfMat;
        mats[4] = upsetMat;
        mats[5] = hatMat;
        rend.materials = mats;
    }

    IEnumerator BlinkTalk()
    {
        mats[0] = clothMat;
        mats[1] = shirtMat;
        mats[2] = bodyMat;
        mats[3] = scarfMat;
        mats[4] = talkEyesMat;
        mats[5] = hatMat;
        rend.materials = mats;

        yield return new WaitForSeconds(0.2f);

        mats[0] = clothMat;
        mats[1] = shirtMat;
        mats[2] = bodyMat;
        mats[3] = scarfMat;
        mats[4] = talkMat;
        mats[5] = hatMat;
        rend.materials = mats;
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

using JetBrains.Annotations;
using UnityEngine;

public class ExpressionManager : MonoBehaviour
{
    [SerializeField] Material baseMat;
    [SerializeField] Material angryMat;
    [SerializeField] Material happyMat;
    [SerializeField] Material upsetMat;
    [SerializeField] Material talkMat;

    [SerializeField] Material scarfMat;
    [SerializeField] Material bodyMat;
    [SerializeField] Material clothMat;
    [SerializeField] Material shirtMat;
    [SerializeField] Material hatMat;

    [SerializeField] Material[] mats;

    [SerializeField] bool isBase;
    [SerializeField] bool isAngry;
    [SerializeField] bool isHappy;
    [SerializeField] bool isUpset;
    [SerializeField] bool isTalk;

    Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
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

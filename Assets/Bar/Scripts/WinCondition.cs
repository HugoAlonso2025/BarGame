using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    int good;
    int bad;
    public int GoodDeliver()
    {
        return good++;
    }

    public int BadDeliver()
    {
        return bad++;
    }

    public void CheckWinCondition()
    {
        if (good >= bad)
        {
            SceneManager.LoadScene("Win");
        }
        else
        {
            SceneManager.LoadScene("Loose");
        }
    }
}

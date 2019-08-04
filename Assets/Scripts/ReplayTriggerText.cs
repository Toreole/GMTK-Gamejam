using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ReplayTriggerText : MonoBehaviour
{
    [SerializeField]
    protected string[] normalTexts;

    [SerializeField]
    protected string[] replayTexts;

    [SerializeField]
    protected TextMeshPro textMesh;

    [SerializeField]
    protected UnityEvent onTextEndReplay;

    bool playedBefore;
    bool isPlaying = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("bruh");
        if (isPlaying)
            return;

        if(other.CompareTag("Player"))
        {
            playedBefore = ReplayCheck.HasPlayedBefore(true);
            StartCoroutine(DoDialogue());
            isPlaying = true;
        }
    }

    IEnumerator DoDialogue()
    {
        var wait = new WaitForSeconds(3.5f);
        for(int i = 0; i < (playedBefore? replayTexts.Length: normalTexts.Length); i++)
        {
            textMesh.text = (playedBefore ? replayTexts : normalTexts)[i];
            yield return wait;
        }
        yield return new WaitForSeconds(2f);
        if (!playedBefore)
        {
            Application.Quit();
        }
        else
        {
            onTextEndReplay?.Invoke();
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}

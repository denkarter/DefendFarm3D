using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public float fakeLoadDuration = 3.0f; 

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsyncronosly(sceneIndex));
    }

    IEnumerator LoadAsyncronosly(int sceneIndex)
    {
        loadingScreen.SetActive(true);

        // Simulate the loading progress.
        float startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < fakeLoadDuration)
        {
            float progress = Mathf.Clamp01(elapsedTime / fakeLoadDuration);
            slider.value = progress;

            // Update elapsed time.
            elapsedTime = Time.time - startTime;

            yield return null;
        }
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;

            yield return null;
        }
    }
}
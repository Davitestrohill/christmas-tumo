using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.IO;


public class Database_send : MonoBehaviour
{
    string url = "https://cat-fact.herokuapp.com/facts/";
    string filePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), "Data.json");
    private void Update()
    {
        StartCoroutine(Send_Request());
    }

    IEnumerator Send_Request()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            string jsonContent = File.ReadAllText(filePath);
            UnityWebRequest request = new UnityWebRequest(url, "GET");
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonContent);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Ошибка: " + request.error);
            }
            else
            {
                Debug.Log("Успешный запрос! Ответ: " + request.downloadHandler.text);
            }
        }
    }
}

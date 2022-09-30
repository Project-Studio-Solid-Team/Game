using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    //using static public strings so they can be change in the unity IDE
    //I will investigate a different way to do this 
    //TODO: ^
	static public string webserverIp = "localhost";
	static public string webserverPort = "9005";
	string url = string.Format("http://{0}:{1}/unity_", webserverIp, webserverPort);
	
    
    IEnumerator sendScore(string username, int score)
    {	
        string sendUrl = url + string.Format("submitscore?username={0}&score={1}", username, score);
    	UnityWebRequest www = UnityWebRequest.Get(sendUrl);
        yield return www.SendWebRequest();


        if(www.result == UnityWebRequest.Result.ConnectionError){
            Debug.Log(www.error);
        }else{
            Debug.Log(www.downloadHandler.text);
        }
    
    }

    IEnumerator getScores(string username, int scorecount){
        string sendUrl = url + string.Format("displayscore?username={0}&scorecount={1}", username,scorecount);
        UnityWebRequest www = UnityWebRequest.Get(sendUrl);
        yield return www.SendWebRequest();

        if(www.result == UnityWebRequest.Result.ConnectionError){
            Debug.Log(www.error);
        }else{
            byte[] results = www.downloadHandler.data;
            
            //this is a bit messy and i could do it over 2 steps but just converts the input byte array to a string
            //then uses the string split function with a , as the delimiter to make an array of strings
            string[] scores = System.Text.Encoding.Default.GetString(results).Split(",");

            //at present will be array 
            //userTopScore:VALUE
            //TopScore:VALUE
            // ^ repeated 3 times
        }
    }
}

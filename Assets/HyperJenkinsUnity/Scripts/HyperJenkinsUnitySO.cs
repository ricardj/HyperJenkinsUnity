using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using System.Text;
using System;

[CreateAssetMenu(menuName = "Hyper Scriptables/New Hyper JEnkins UNity")]
public class HyperJenkinsUnitySO : SingletonSO<HyperJenkinsUnitySO>
{
    // Replace these with your Jenkins server details
    [SerializeField] string jenkinsUrl = "http://jenkins.example.com";
    [SerializeField] string jobName = "MyJob";
    [SerializeField] string username = "yourusername";
    [SerializeField] string password = "yourpassword";

    public void StartBuild()
    {
        Debug.Log("Starting build");

        // Set up the HTTP request
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(jenkinsUrl + "/job/" + jobName + "/build");
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";

        // Add the authentication credentials to the request
        string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
        request.Headers.Add("Authorization", "Basic " + credentials);

        // Send the HTTP request
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Debug.Log("Jenkins build triggered. Response code: " + response.StatusCode);

        // Close the response
        response.Close();
    }
}

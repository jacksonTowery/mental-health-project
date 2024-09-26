using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using System.Threading.Tasks;

public class Activities : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {

        PermissionRequest request = new PermissionRequest();
        while (request.Status == PermissionStatus.RequestPending)
        {
            print("pending");
        }
        if (request.Status == PermissionStatus.Denied)
        {
            print("denied");
            SceneManager.LoadScene("MHStart");
        }
        else
        {
            //android notification channel
            AndroidNotificationChannelGroup channelgroup = new AndroidNotificationChannelGroup()
            {
                Id = "Main",
                Name = "MainNotifications"
            };
            AndroidNotificationCenter.RegisterNotificationChannelGroup(channelgroup);
            AndroidNotificationChannel channel = new AndroidNotificationChannel()
            {
                Id = "ChannelID",
                Name = "Channel",
                Importance = Importance.Default,
                Description = "Generic notifications"
            };
            AndroidNotificationCenter.RegisterNotificationChannel(channel);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void Walk()
    {

        AndroidNotification notif = new AndroidNotification();
        notif.Title = "Go on a walk:";
        notif.Text = "Go outside and start walking";
        AndroidNotificationCenter.SendNotification(notif, "ChannelID");

    }
    
    private void Exercise()
    {
        AndroidNotification notif = new AndroidNotification();
        notif.Title = "Go on a Exercise:";
        notif.Text = "Find a building";
        AndroidNotificationCenter.SendNotification(notif, "ChannelID");
    }

    private void Yoga()
    {
        AndroidNotification notif = new AndroidNotification();
        notif.Title = "Do some Yoga:";
        notif.Text = "Find a building";
        AndroidNotificationCenter.SendNotification(notif, "ChannelID");
    }
}

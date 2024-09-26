using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using System.Threading.Tasks;
using Unity.Mathematics;

public class Activities : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {

        //PermissionRequest request = new PermissionRequest();
        //while (request.Status == PermissionStatus.RequestPending)
        //{
        ///    print("pending");
       // }
//{
       //     print("denied");
       //   SceneManager.LoadScene("MHStart");
       // }
      // else
      //  {
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
   // }
    void Update()
    {

    }
    private void Walk()
    {
        AndroidNotification notif = new AndroidNotification();
        notif.Title = "Go on a walk:";
        notif.Text = "Go outside and start walking";
        AndroidNotificationCenter.SendNotification(notif, "ChannelID");

        int walktime = UnityEngine.Random.Range(0, 10);
        AndroidNotification StopNotif = new AndroidNotification();
        StopNotif.Title = "You Have Finished your walk";
        StopNotif.FireTime = System.DateTime.Now.AddSeconds(walktime);
        StopNotif.Text = "You have walked for:" + walktime + " Minutes";

        AndroidNotificationCenter.SendNotification(StopNotif, "ChannelID");
    }
    
    private void Exercise()
    {
        AndroidNotification notif = new AndroidNotification();
        notif.Title = "Go on a Exercise:";
        notif.Text = "";
        AndroidNotificationCenter.SendNotification(notif, "ChannelID");
    }

    private void Yoga()
    {
        AndroidNotification notif = new AndroidNotification();
        notif.Title = "Do some Yoga:";
        notif.Text = "";
        AndroidNotificationCenter.SendNotification(notif, "ChannelID");
    }
}

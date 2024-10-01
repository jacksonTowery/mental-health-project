using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class SubmitEntry : MonoBehaviour
{

    public InputField entry;
    public Text page;
    public InputField title;
    public Dropdown entries;
    List<Dropdown.OptionData> header=new List<Dropdown.OptionData>();
    Journal test = new Journal("a", "b");
    List<Journal> diary=new List<Journal>();
    List<string> prompts = new List<string>();
    

   
    // Start is called before the first frame update
    public void MyDemoButton()
    {
        if (title.text != "")
        {
            page.text = entry.text;
            // entry.text = "";
            Journal journal = new Journal(title.text, entry.text);
            if (!hasEntry(journal))
            {
                diary.Add(journal);
                addToEntries(diary);
            }
            else if (journal.getTitle() != "View Previous Entries")
            {
                diary.RemoveAt(findEntry(journal));
                diary.Add(journal);

            }
        }
    }
    public void showEntry()
    {
        string t = entries.options[entries.value].text;
        for (int i = 0; i < diary.Count; i++)
        {
            if (diary[i].getTitle() == t)
            {
                page.text = diary[i].getPage();
                title.text = diary[i].getTitle();
                entry.text = page.text;
                i = diary.Count;
            }
        }
        if(t.Equals("View Previous Entries"))
        {
            page.text = "";
            title.text = "";
            entry.text = "";
        }
    }

    public void addToEntries(List<Journal> journals)
    {
        List<string>entries2=new List<string>();
        entries2.Add("View Previous Entries");
        foreach(Journal journal in journals)
        {
            entries2.Add(journal.getTitle());
        }
        entries.ClearOptions();
        entries.AddOptions(entries2);
        entries.RefreshShownValue();
    }

    public bool hasEntry(Journal journal)
    {
        foreach(Journal have in diary)
        {
            if(have.getTitle().Equals(journal.getTitle()))
            {
                return true;
            }
        }
        return false;
    }
    public int findEntry(Journal journal)
    {
        for (int i = 0;i < diary.Count;i++)
        {
            if ((diary[i].getTitle().Equals(journal.getTitle())))
            {
                return i;
            }
        }
        return 0;
    }
    public void updated()
    {
        page.text = entry.text;
    }

    public void addPrompts()
    {
        prompts.Add("What makes you feel the most inspired?");
        prompts.Add("What can you do today to take better care of yourself?");
        prompts.Add("How would you spend your perfect day off? What makes that perfect for you?");
    }

    public void givePrompt()
    {
        if (prompts.Count <= 0)
        {
            addPrompts();
        }
        int rand=Random.Range(0,prompts.Count);
        //  Random rand = new Random();
        //int pos=rand.Next(prompts.Count);
         string prompt = prompts[rand];
        //string prompt = "" + prompts.Count;

        EditorUtility.DisplayDialog("", "" + prompt, "Okay", "Another Time");
    }


}
public class Journal
{
    public string title;
    public string page;

    public Journal(string t, string p) { 
        title = t;
        page = p;
    }
    public string getPage() { return page; }

    public string getTitle() { return title; }
}

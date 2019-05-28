using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class CommandRecognizer
{

    private string[] command;
    Boolean commandhere; 

    private KeywordRecognizer commandRecognizer;

    public void startCommandRecognition()
    {
        commandhere = false;
        command = new string[1];
        command[0] = Commandstrings.COMMANDWURFTRAINING;
        commandRecognizer = new KeywordRecognizer(command);
        commandRecognizer.OnPhraseRecognized += OnPhraseRecognized;
        commandRecognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text);
        setCommandHere(true);
        switch (args.text)
        {
            case Commandstrings.COMMANDROUTETRAINING:
                break;
            case Commandstrings.COMMANDWURFTRAINING:
                break;      
        }  
    }

    public void stopCommandRecognizer()
    {
        commandRecognizer.Stop();
        commandRecognizer.Dispose();
    }

    public Boolean getCommandHere()
    {
        return commandhere;
    }

    private void setCommandHere(Boolean commandhere)
    {
        this.commandhere = commandhere;
    }
}
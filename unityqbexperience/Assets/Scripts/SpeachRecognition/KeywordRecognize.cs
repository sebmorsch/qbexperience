using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections;

public class KeywordRecognize : MonoBehaviour
{
    private string[] keywords;
    private KeywordRecognizer keywordrecognizer;
    CommandRecognizer commandRecognizer;

    void Start()
    {
        commandRecognizer = new CommandRecognizer();
        keywords = new string[3];
        keywords[0] = Commandstrings.KEYWORDCOACH;
        keywords[1] = Commandstrings.KEYWORDTRAINER;
        keywords[2] = Commandstrings.KEYWORDPLAYER;
        keywordrecognizer = new KeywordRecognizer(keywords);
        keywordrecognizer.OnPhraseRecognized += OnPhraseRecognized;
        keywordrecognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        if (args.text.ToString().Equals(Commandstrings.KEYWORDCOACH) || args.text.ToString().Equals(Commandstrings.KEYWORDTRAINER))
        {
            Debug.Log(args.text);
            keywordrecognizer.Stop();
            StartCoroutine(WaitForCommand());
            commandRecognizer.startCommandRecognition();
        }else if (args.text.ToString().Equals(Commandstrings.KEYWORDPLAYER))
        {
            Debug.Log(args.text);
            keywordrecognizer.Stop();
            StartCoroutine(WaitForCommand());
            commandRecognizer.startCommandRecognition();
        }      
       
    }

    private IEnumerator WaitForCommand()
    {
        yield return new WaitForSeconds(5);
        if (commandRecognizer.getCommandHere() == false)
        {
            keywordrecognizer.Start();
            commandRecognizer.stopCommandRecognizer();
        }
        else
        {
            keywordrecognizer.Start();
            commandRecognizer.stopCommandRecognizer();
        }
    }
}
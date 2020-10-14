using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using TMPro;

public class SpeechRecognition : MonoBehaviour
{

    public TextMeshProUGUI myTMP;

    private KeywordRecognizer reconocePalabras;
    private ConfidenceLevel confidencialidad = ConfidenceLevel.Low;
    private Dictionary<string, Accion> palabrasAccion = new Dictionary<string, Accion>();
    private SimpleCarController myCarController;

    //crear Delegado para la acción a ejecutar
    private delegate void Accion();

    // Start is called before the first frame update
    void Start()
    {
        myCarController = GetComponent<SimpleCarController>();

        palabrasAccion.Add("adelante", myCarController.MoveForward);
        palabrasAccion.Add("atras", myCarController.MoveBackward);
        palabrasAccion.Add("izquierda", myCarController.SteerLeft);
        palabrasAccion.Add("derecha", myCarController.SteerRight);
        palabrasAccion.Add("giro izquierda", myCarController.SteerAllLeft);
        palabrasAccion.Add("giro derecha", myCarController.SteerAllRight);
        palabrasAccion.Add("stop", myCarController.StopCar);
        palabrasAccion.Add("defrente", myCarController.SteerStraightAhead);
        palabrasAccion.Add("turbo", myCarController.MaxSpeed);
        palabrasAccion.Add("inicio", myCarController.ResetCar);

        reconocePalabras = new KeywordRecognizer(palabrasAccion.Keys.ToArray(), confidencialidad);
        reconocePalabras.OnPhraseRecognized += OnKeywordsRecognized;
        reconocePalabras.Start();
    }

    void OnDestroy()
    {
        if (reconocePalabras != null && reconocePalabras.IsRunning)
        {
            reconocePalabras.Stop();
            reconocePalabras.Dispose();
        }
    }

    private void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        myTMP.text = args.text;
        palabrasAccion[args.text].Invoke();
    }
}

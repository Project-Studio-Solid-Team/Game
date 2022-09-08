using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizQuestions : MonoBehaviour
{

    public List<List<string>> quizOptions;
    public List<string> quizQuestions;
    public List<string> quizAnswers;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate potential level 1 quiz answers
        quizAnswers = new List<string>() {
            "Displacement", "Distance", "Velocity", "Time", "Speed", "v = d / t", "d = v * t", "3.6", "Direction", "Direction", "Displacement"
        };

        // Instantiate potential level 1 quiz questions
        quizQuestions = new List<string>() {
            "What word defines how far away from its original position an object is:",
            "What word would describe the measurement of an actual path travelled by an object:",
            "Which of the following is not a scalar quantity:", "Which of the following is not a vector quantity:",
            "What is the measure of how fast something move:", 
            "Where v represents average speed, d represents distance travelled, and t represents time taken, what is the correct equation for calculating average speed:",
            "Where v represents average speed, d represents distance travelled, and t represents time taken, what is the correct equation for calculating distance travelled:",
            "To convert speed from m/s to kilometers per hour, what value would you multiply the original number in m/s with:",
            "A scalar quantity has a magnitude but no _________:", "A vector quantity has a magnitude and a ________:",
            "Velocity is a measure of the rate at which ____ changes:"
        };
        
        var q1 = new List<string>() { "Displacement", "Discord", "Distance", "Diameter" }; quizOptions.Add(q1);
        var q2 = new List<string>() { "Displacement", "Discord", "Distance", "Diameter" }; quizOptions.Add(q2);
        var q3 = new List<string>() { "Speed", "Time", "Energy", "Velocity" }; quizOptions.Add(q3);
        var q4 = new List<string>() { "Velocity", "Acceleration", "Momentum", "Time" }; quizOptions.Add(q4);
        var q5 = new List<string>() { "Time", "Weight", "Length", "Speed" }; quizOptions.Add(q5);
        var q6 = new List<string>() { "d = v * f", "2d = v + t", "v = d / t", "None of the above" }; quizOptions.Add(q6);
        var q7 = new List<string>() { "d = v * t", "t = v + d", "d = v2 / t2", "None of the above" }; quizOptions.Add(q7);
        var q8 = new List<string>() { "36", "60", "6", "3.6" }; quizOptions.Add(q8);
        var q9 = new List<string>() { "Direction", "Detachment", "Diameter", "Dental Records" }; quizOptions.Add(q9);
        var q10 = new List<string>() { "Definition", "Detachment", "Diameter", "Direction" }; quizOptions.Add(q10);
        var q11 = new List<string>() { "Direction", "Weight", "Distance", "Displacement" }; quizOptions.Add(q11);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

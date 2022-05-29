using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;


public class writeToFile : MonoBehaviour
{
    private string epochTime;
    private string milliseconds;
    private string dataFile;
    public trialSetup Trials;
    // Slider
    public Slider trial_slider_up_left;
    public Slider trial_slider_up_right;
    public Slider trial_slider_down_left;
    public Slider trial_slider_down_right;
    // Images
    public RawImage trial_image_up_left_first;
    public RawImage trial_image_up_left_second;
    public RawImage trial_image_up_right_first;
    public RawImage trial_image_up_right_second;
    public RawImage trial_image_down_left_first;
    public RawImage trial_image_down_left_second;
    public RawImage trial_image_down_right_first;
    public RawImage trial_image_down_right_second;

    void Start()
    {
        //System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        //int epoch = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;
        //milliseconds = DateTime.UtcNow.Millisecond.ToString("000");
        //epochTime = epoch.ToString() + milliseconds;
        //File.Create(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/ColorDimensionality" + System.DateTime.Now.ToString().Replace("/", "-").Replace(" ", "").Replace(":", "") + ".txt");
        CreateText();
    }

    void CreateText()
    {
        //+System.DateTime.Now.ToString().Replace("/", "-").Replace(" ", "").Replace(":", "") + ".txt"
        dataFile = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/ColorDimensionality.txt";
        if (!File.Exists(dataFile))
        {
            File.AppendAllText(dataFile, "No_trial, ColourRight, ColourLeft, Value\n");
        }
    }

    public void WriteValueSlider(float up_left_value, float up_right_value, float down_left_value, float down_right_value)
    {
        if (Trials.trials_counter < Trials.trials_max_counter)
        {
            string allData = trial_image_up_left_first.texture.name + "," + trial_image_up_left_second.texture.name + "," + up_left_value + "\n" + 
                             trial_image_up_right_first.texture.name + "," + trial_image_up_right_second.texture.name + "," + up_right_value + "\n" + 
                             trial_image_down_left_first.texture.name + "," + trial_image_down_left_second.texture.name + "," + down_left_value + "\n" + 
                             trial_image_down_right_first.texture.name + "," + trial_image_down_right_second.texture.name + "," + down_right_value;
            File.AppendAllText(dataFile, (allData + "\n"));
        }
        else {
            string allData = trial_image_up_left_first.texture.name + "," + trial_image_up_left_second.texture.name + "," + up_left_value + "\n" + 
                             trial_image_up_right_first.texture.name + "," + trial_image_up_right_second.texture.name + "," + up_right_value;
            File.AppendAllText(dataFile, (allData + "\n"));
        }
        trial_slider_up_left.value = 5;
        trial_slider_up_right.value = 5;
        trial_slider_down_left.value = 5;
        trial_slider_down_right.value = 5;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

public class trialSetup : MonoBehaviour
{
    public int trials_counter = 0;
    public int trials_max_counter;
    //public object[] allTextures;
    public Texture2D[] allTextures;
    public List<string> lines = new List<string>();
    public continueActive continueActive;
    public Slider upLeftSlider;
    public Slider downLeftSlider;
    public Slider upRightSlider;
    public Slider downRightSlider;
    public Text textTrials;

    List<Texture> right_img = new List<Texture>();
    List<Texture> left_img = new List<Texture>();

    //Texture2D myTexture;

    public GameObject button_continue_trial;
    public GameObject button_end_trial;
    public GameObject text_end_trial;
    public GameObject writer;

    void Start()
    {
        button_end_trial.SetActive(false);
        text_end_trial.SetActive(false);
        //allTextures = Resources.LoadAll("Colors", typeof(Texture2D));

        // Read CSV
        {
            lines.Add("0,1");
            lines.Add("0,2");
            lines.Add("0,3");
            lines.Add("0,4");
            lines.Add("0,5");
            lines.Add("0,6");
            lines.Add("0,7");
            lines.Add("0,8");
            lines.Add("0,9");
            lines.Add("0,10");
            lines.Add("0,11");
            lines.Add("0,12");
            lines.Add("0,13");
            lines.Add("0,14");
            lines.Add("0,15");
            lines.Add("0,16");
            lines.Add("0,17");
            lines.Add("0,18");
            lines.Add("0,19");
            lines.Add("1,2");
            lines.Add("1,3");
            lines.Add("1,4");
            lines.Add("1,5");
            lines.Add("1,6");
            lines.Add("1,7");
            lines.Add("1,8");
            lines.Add("1,9");
            lines.Add("1,10");
            lines.Add("1,11");
            lines.Add("1,12");
            lines.Add("1,13");
            lines.Add("1,14");
            lines.Add("1,15");
            lines.Add("1,16");
            lines.Add("1,17");
            lines.Add("1,18");
            lines.Add("1,19");
            lines.Add("2,3");
            lines.Add("2,4");
            lines.Add("2,5");
            lines.Add("2,6");
            lines.Add("2,7");
            lines.Add("2,8");
            lines.Add("2,9");
            lines.Add("2,10");
            lines.Add("2,11");
            lines.Add("2,12");
            lines.Add("2,13");
            lines.Add("2,14");
            lines.Add("2,15");
            lines.Add("2,16");
            lines.Add("2,17");
            lines.Add("2,18");
            lines.Add("2,19");
            lines.Add("3,4");
            lines.Add("3,5");
            lines.Add("3,6");
            lines.Add("3,7");
            lines.Add("3,8");
            lines.Add("3,9");
            lines.Add("3,10");
            lines.Add("3,11");
            lines.Add("3,12");
            lines.Add("3,13");
            lines.Add("3,14");
            lines.Add("3,15");
            lines.Add("3,16");
            lines.Add("3,17");
            lines.Add("3,18");
            lines.Add("3,19");
            lines.Add("4,5");
            lines.Add("4,6");
            lines.Add("4,7");
            lines.Add("4,8");
            lines.Add("4,9");
            lines.Add("4,10");
            lines.Add("4,11");
            lines.Add("4,12");
            lines.Add("4,13");
            lines.Add("4,14");
            lines.Add("4,15");
            lines.Add("4,16");
            lines.Add("4,17");
            lines.Add("4,18");
            lines.Add("4,19");
            lines.Add("5,6");
            lines.Add("5,7");
            lines.Add("5,8");
            lines.Add("5,9");
            lines.Add("5,10");
            lines.Add("5,11");
            lines.Add("5,12");
            lines.Add("5,13");
            lines.Add("5,14");
            lines.Add("5,15");
            lines.Add("5,16");
            lines.Add("5,17");
            lines.Add("5,18");
            lines.Add("5,19");
            lines.Add("6,7");
            lines.Add("6,8");
            lines.Add("6,9");
            lines.Add("6,10");
            lines.Add("6,11");
            lines.Add("6,12");
            lines.Add("6,13");
            lines.Add("6,14");
            lines.Add("6,15");
            lines.Add("6,16");
            lines.Add("6,17");
            lines.Add("6,18");
            lines.Add("6,19");
            lines.Add("7,8");
            lines.Add("7,9");
            lines.Add("7,10");
            lines.Add("7,11");
            lines.Add("7,12");
            lines.Add("7,13");
            lines.Add("7,14");
            lines.Add("7,15");
            lines.Add("7,16");
            lines.Add("7,17");
            lines.Add("7,18");
            lines.Add("7,19");
            lines.Add("8,9");
            lines.Add("8,10");
            lines.Add("8,11");
            lines.Add("8,12");
            lines.Add("8,13");
            lines.Add("8,14");
            lines.Add("8,15");
            lines.Add("8,16");
            lines.Add("8,17");
            lines.Add("8,18");
            lines.Add("8,19");
            lines.Add("9,10");
            lines.Add("9,11");
            lines.Add("9,12");
            lines.Add("9,13");
            lines.Add("9,14");
            lines.Add("9,15");
            lines.Add("9,16");
            lines.Add("9,17");
            lines.Add("9,18");
            lines.Add("9,19");
            lines.Add("10,11");
            lines.Add("10,12");
            lines.Add("10,13");
            lines.Add("10,14");
            lines.Add("10,15");
            lines.Add("10,16");
            lines.Add("10,17");
            lines.Add("10,18");
            lines.Add("10,19");
            lines.Add("11,12");
            lines.Add("11,13");
            lines.Add("11,14");
            lines.Add("11,15");
            lines.Add("11,16");
            lines.Add("11,17");
            lines.Add("11,18");
            lines.Add("11,19");
            lines.Add("12,13");
            lines.Add("12,14");
            lines.Add("12,15");
            lines.Add("12,16");
            lines.Add("12,17");
            lines.Add("12,18");
            lines.Add("12,19");
            lines.Add("13,14");
            lines.Add("13,15");
            lines.Add("13,16");
            lines.Add("13,17");
            lines.Add("13,18");
            lines.Add("13,19");
            lines.Add("14,15");
            lines.Add("14,16");
            lines.Add("14,17");
            lines.Add("14,18");
            lines.Add("14,19");
            lines.Add("15,16");
            lines.Add("15,17");
            lines.Add("15,18");
            lines.Add("15,19");
            lines.Add("16,17");
            lines.Add("16,18");
            lines.Add("16,19");
            lines.Add("17,18");
            lines.Add("17,19");
            lines.Add("18,19");
        }
        int number;
        lines = lines.OrderBy(i => Guid.NewGuid()).ToList();
        int line_no = 0;

        while (line_no < 190)
        {
            var splits = lines[line_no].Split(',');

            System.Random ran = new System.Random((line_no + 1) * Convert.ToInt32(DateTime.UtcNow.Millisecond.ToString("000")));
            splits = splits.OrderBy(x => ran.Next()).ToArray();

            print(splits[0] + ' ' + splits[1]);
            number = Convert.ToInt32(splits[0]);
            right_img.Add((Texture2D)allTextures[number]);
            number = Convert.ToInt32(splits[1]);
            left_img.Add((Texture2D)allTextures[number]);
            line_no += 1;
        }

        trials_max_counter = (int)System.Math.Ceiling((double)right_img.Count / 4);
        double last_no_trials = right_img.Count % 4;

        PlotTrials();
        trials_counter += 1;

        GameObject temp = GameObject.Find("TextTrials");
        temp.GetComponent<Text>().text = "Position the four sliders. No " + (int)(trials_counter) + "/" + (int)trials_max_counter;
    }

    public void PlotImage(int pos, List<Texture> img_s, GameObject name_object)
    {
        if (trials_counter < trials_max_counter)
        {
            name_object.GetComponent<RawImage>().texture = img_s[pos];
        }
    }

    public void PlotTrials()
    {
        GameObject name_object;
        int pos_no;

        // Up left
        pos_no = trials_counter * 4;
        name_object = GameObject.Find("UpLeftFirstImage");
        PlotImage(pos_no, right_img, name_object);
        name_object = GameObject.Find("UpLeftSecondImage");
        PlotImage(pos_no, left_img, name_object);

        // Up right
        pos_no = trials_counter * 4 + 1;
        name_object = GameObject.Find("UpRightFirstImage");
        PlotImage(pos_no, right_img, name_object);
        name_object = GameObject.Find("UpRightSecondImage");
        PlotImage(pos_no, left_img, name_object);

        // Down left
        pos_no = trials_counter * 4 + 2;
        name_object = GameObject.Find("DownLeftFirstImage");
        PlotImage(pos_no, right_img, name_object);
        name_object = GameObject.Find("DownLeftSecondImage");
        PlotImage(pos_no, left_img, name_object);

        // Down right
        pos_no = trials_counter * 4 + 3;
        name_object = GameObject.Find("DownRightFirstImage");
        PlotImage(pos_no, right_img, name_object);
        name_object = GameObject.Find("DownRightSecondImage");
        PlotImage(pos_no, left_img, name_object);
    }

    void DestroyGameObject(GameObject gameObject) { Destroy(gameObject); }

    public void ContinuePressed()
    {
        GameObject name_object;
        continueActive.tl = false;
        continueActive.tr = false;
        continueActive.ll = false;
        continueActive.lr = false;

        if (trials_counter < trials_max_counter - 1)
        {
            GameObject temp = GameObject.Find("TextTrials");
            temp.GetComponent<Text>().text = "Position the four sliders. No " + (int)(trials_counter + 1) + "/" + (int)trials_max_counter;

            //temp = GameObject.Find("UpLeftSlider");
            //float up_left_value = temp.GetComponent<Slider>().value;

            //temp = GameObject.Find("UpRightSlider");
            //float up_right_value = temp.GetComponent<Slider>().value;

            //temp = GameObject.Find("DownLeftSlider");
            //float down_left_value = temp.GetComponent<Slider>().value;

            //temp = GameObject.Find("DownRightSlider");
            //float down_right_value = temp.GetComponent<Slider>().value;
            float up_left_value = upLeftSlider.value;
            float up_right_value = upRightSlider.value;
            float down_left_value = downLeftSlider.value;
            float down_right_value = downRightSlider.value;


            writer.GetComponent<writeToFile>().WriteValueSlider(up_left_value, up_right_value, down_left_value, down_right_value);

            PlotTrials();
            trials_counter += 1;
        }
        else if (trials_counter == trials_max_counter - 1)
        {
            //GameObject temp = GameObject.Find("UpLeftSlider");
            //float up_left_value = temp.GetComponent<Slider>().value;

            //temp = GameObject.Find("UpRightSlider");
            //float up_right_value = temp.GetComponent<Slider>().value;

            //temp = GameObject.Find("DownLeftSlider");
            //float down_left_value = temp.GetComponent<Slider>().value;

            //temp = GameObject.Find("DownRightSlider");
            //float down_right_value = temp.GetComponent<Slider>().value;
            float up_left_value = upLeftSlider.value;
            float up_right_value = upRightSlider.value;
            float down_left_value = downLeftSlider.value;
            float down_right_value = downRightSlider.value;

            writer.GetComponent<writeToFile>().WriteValueSlider(up_left_value, up_right_value, down_left_value, down_right_value);

            double last_no_trials = right_img.Count % 4;
            int pos_no;

            if (last_no_trials == 4) { PlotTrials(); }
            else
            {
                // Down right
                name_object = GameObject.Find("DownRightFirstImage");
                DestroyGameObject(name_object);
                name_object = GameObject.Find("DownRightSecondImage");
                DestroyGameObject(name_object);
                name_object = GameObject.Find("DownRightSlider");
                DestroyGameObject(name_object);
                name_object = GameObject.Find("DownRightSimilarText");
                DestroyGameObject(name_object);
                name_object = GameObject.Find("DownRightDissimilarText");
                DestroyGameObject(name_object);

                // Down left
                name_object = GameObject.Find("DownLeftFirstImage");
                DestroyGameObject(name_object);
                name_object = GameObject.Find("DownLeftSecondImage");
                DestroyGameObject(name_object);
                name_object = GameObject.Find("DownLeftSlider");
                DestroyGameObject(name_object);
                name_object = GameObject.Find("DownLeftSimilarText");
                DestroyGameObject(name_object);
                name_object = GameObject.Find("DownLeftDissimilarText");
                DestroyGameObject(name_object);

                // Up left
                pos_no = trials_counter * 4;
                name_object = GameObject.Find("UpLeftFirstImage");
                PlotImage(pos_no, right_img, name_object);
                name_object = GameObject.Find("UpLeftSecondImage");
                PlotImage(pos_no, left_img, name_object);

                // Up right
                pos_no = trials_counter * 4 + 1;
                name_object = GameObject.Find("UpRightFirstImage");
                PlotImage(pos_no, right_img, name_object);
                name_object = GameObject.Find("UpRightSecondImage");
                PlotImage(pos_no, left_img, name_object);

                //temp = GameObject.Find("TextTrials");
                //temp.GetComponent<Text>().text = "Position the four sliders. No " + (int)(trials_counter) + "/" + (int)trials_max_counter;

                trials_counter += 1;

                continueActive.ll = true;
                continueActive.lr = true;
            }
        }
        else if (trials_counter == trials_max_counter)
        {
            button_end_trial.SetActive(true);

            GameObject temp = GameObject.Find("UpLeftSlider");
            float up_left_value = temp.GetComponent<Slider>().value;

            temp = GameObject.Find("UpRightSlider");
            float up_right_value = temp.GetComponent<Slider>().value;

            writer.GetComponent<writeToFile>().WriteValueSlider(up_left_value, up_right_value, -1, -1);

            name_object = GameObject.Find("UpLeftFirstImage");
            DestroyGameObject(name_object);
            name_object = GameObject.Find("UpLeftSecondImage");
            DestroyGameObject(name_object);
            name_object = GameObject.Find("UpLeftSlider");
            DestroyGameObject(name_object);
            name_object = GameObject.Find("UpLeftSimilarText");
            DestroyGameObject(name_object);
            name_object = GameObject.Find("UpLeftDissimilarText");
            DestroyGameObject(name_object);

            name_object = GameObject.Find("UpRightFirstImage");
            DestroyGameObject(name_object);
            name_object = GameObject.Find("UpRightSecondImage");
            DestroyGameObject(name_object);
            name_object = GameObject.Find("UpRightSlider");
            DestroyGameObject(name_object);
            name_object = GameObject.Find("UpRightSimilarText");
            DestroyGameObject(name_object);
            name_object = GameObject.Find("UpRightDissimilarText");
            DestroyGameObject(name_object);

            textTrials.text = "You finished all the trials.";
            //temp.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        }
    }
}
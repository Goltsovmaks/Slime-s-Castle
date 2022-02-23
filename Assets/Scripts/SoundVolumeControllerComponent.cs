﻿using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeControllerComponent : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AudioSource audio;
    [SerializeField] private Slider slider;
    [SerializeField] private Text text;

    [Header("Keys")]
    [SerializeField] private string saveVolumeKey;

    [Header("Tags")]
    [SerializeField] private string sliderTag;
    [SerializeField] private string textVolumeTag;

    [Header ("Parameters")]
    [SerializeField] private float volume;

    //private void Awake()
    //{
    //    if (PlayerPrefs.HasKey(this.saveVolumeKey)){
    //        this.volume = PlayerPrefs.GetFloat(this.saveVolumeKey);
    //        this.audio.volume = this.volume;

    //        GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
    //        if (sliderObj != null){
    //            this.slider = sliderObj.GetComponent<Slider>();
    //            this.slider.value = this.volume;
    //        }
    //        else{
    //            this.volume = 0.50f;
    //            PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
    //            this.audio.volume = this.volume;
    //        }
    //    }
    //}
    //private void LateUpdate()
    //{
    //    GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
    //    if (sliderObj != null){
    //        this.slider = sliderObj.GetComponent<Slider>();
    //        this.volume = slider.value;

    //        if (this.audio.volume != this.volume){
    //            PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
    //        }
    //        GameObject  textObj = GameObject.FindWithTag(this.textVolumeTag);
    //        if (textObj != null){
    //            this.text = textObj.GetComponent<Text>();

    //            this.text.text = Mathf.Round(f: this.volume * 100) + "%";

    //        }
    //    }
    //    this.audio.volume = this.volume;
    //}
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private Text textHolder;

        [Header("Text Options")]
        [SerializeField]
        private string input;

        [SerializeField]
        private Color textColor;

        [SerializeField]
        private Font textFont;

        [SerializeField]
        private float delay;

        [Header("Audio Options")]
        [SerializeField]
        private AudioClip sound;

        [Header("Character Stage")]
        [SerializeField]
        private Sprite leftCharacterSprite;

        [SerializeField]
        private Image leftImageHolder;

        [SerializeField]
        private Sprite rightCharacterSprite;

        [SerializeField]
        private Image rightImageHolder;

        [SerializeField]
        private string talking;

        private Color talkingColor = new Color32(255, 255, 255, 255);

        private Color notTalkingColor = new Color32(90, 90, 90, 255);

        private void Awake()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";

            leftImageHolder.sprite = leftCharacterSprite;
            rightImageHolder.sprite = rightCharacterSprite;
            leftImageHolder.preserveAspect = true;
            rightImageHolder.preserveAspect = true;
        }

        private void Start()
        {
            if (talking == "L")
            {
                rightImageHolder.GetComponent<Image>().color = notTalkingColor;
                leftImageHolder.GetComponent<Image>().color = talkingColor;
            }
            else
            {
                leftImageHolder.GetComponent<Image>().color = notTalkingColor;
                rightImageHolder.GetComponent<Image>().color = talkingColor;
            }

            StartCoroutine(WriteText(input,
            textHolder,
            textColor,
            textFont,
            delay,
            sound));

            // rightImageHolder.GetComponent<Image>().color = notTalkingColor;
        }
    }
}
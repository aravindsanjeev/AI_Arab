
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using Meta.WitAi.TTS.Utilities;
using Meta.Voice.Audio;

    public class AI_VoiceManager : MonoBehaviour
    {
        [TextArea]
        public string voiceText;
        public AudioSource CharacterAudioSource;
        public TTSSpeaker voiceInput;

        public Text input_Field;

        #region singleton
        public static AI_VoiceManager Instance;

        private void Awake()
        {
            Instance = this;
        }
        #endregion
        public void DummyButtonAction()
        {

            //TextToSpeech_AI("This is a test message and I want you to enact to this");
            TextToSpeech_AI(input_Field.text);
        }

        void TextToSpeech_AI(string str)
        {
            voiceInput.AudioSource = CharacterAudioSource;
        voiceInput.GetComponent<UnityAudioPlayer>().AudioSource = CharacterAudioSource;
            //voiceInput.p
            //voiceInput.SpeakClickFromOutside(str);
            StartCoroutine(SpeakAsync(str, false));
        }

        private IEnumerator SpeakAsync(string phrase, bool queued)
        {
            // Queue
            if (queued)
            {
                yield return voiceInput.SpeakQueuedAsync(new string[] { phrase });
            }
            // Default
            else
            {
                yield return voiceInput.SpeakAsync(phrase);
            }

            /*// Play complete clip
            if (_asyncClip != null)
            {
                voiceInput.AudioSource.PlayOneShot(_asyncClip);
            }*/
        }
    }
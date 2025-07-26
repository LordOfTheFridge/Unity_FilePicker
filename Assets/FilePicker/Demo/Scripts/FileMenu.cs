using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Utilities.FileControl;

namespace DemoFilePicker
{
    public class FileMenu : MonoBehaviour
    {
        [SerializeField] private string[] Data;

        [Header("UI")]
        [SerializeField] private Button ButtonLoad;
        [SerializeField] private Button ButtonUpload;

        [Header("FileControl")]
        [SerializeField] private FilePicker FilePicker;
        [SerializeField] private FileHandler FileHandler;

        void Start()
        {
            ButtonLoad.onClick.AddListener(OnClickButtonLoad);
            ButtonUpload.onClick.AddListener(OnClickButtonUpload);
        }

        private void OnClickButtonUpload()
        {
            var path = Path.Combine(Application.temporaryCachePath, "Test.txt");
            CreateFile(path, Data);
            FilePicker.ExportFile(path);
        }

        private void OnClickButtonLoad()
        {
            FilePicker.PickFile("txt", PickFileCallback);
        }

        private void PickFileCallback(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) {
                Debug.Log("Operation cancelled.");
            } else {
                Debug.Log("Picked file: " + path);
                var data = FileHandler.ReadDataFromFile(path);
                foreach(var value in data) {
                    Debug.Log(value);
                }
            }
        }

        private void CreateFile(string path, string[] data)
        {
            if(data == null || data.Length < 1) {
                return;
            }

            FileHandler.DeleteFileIfExist(path);
            FileHandler.WriteTextToFile(path, data);
        }

        void OnDestroy()
        {
            ButtonLoad.onClick.RemoveListener(OnClickButtonLoad);
            ButtonUpload.onClick.RemoveListener(OnClickButtonUpload);
        }
    }
}

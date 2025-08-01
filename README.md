# Unity_FilePicker

This is just convenient wrapper for [UnityNativeFilePicker](https://github.com/yasirkula/UnityNativeFilePicker) plugin and example of working with this plugin.

It allows user to select file and export the file to the device storage.

The author of this plugin claims that it only works for Android and iOS. I tested it on Windows and it works.


## Demo
You can run apk on Android or run project on Unity version 2022.3.61f1.

## Installation
Import UnityNativeFilePicker from [GitHub](https://github.com/yasirkula/UnityNativeFilePicker) or [AssetStore](https://assetstore.unity.com/packages/tools/integration/native-file-picker-for-android-ios-173238).

Import unity package from this repository.


## Usage
### PickFile
This method will open file manager window for user. Window will show files of specified type.

This method will pass path (string) to file selected by user.

```csharp
FilePicker.PickFile("txt", PickFileCallback);

private void PickFileCallback(string path)
{
  if (string.IsNullOrWhiteSpace(path)) {
      Debug.Log("Operation cancelled.");
  } else {
      Debug.Log("Picked file: " + path);
  }
}
```

### ExportFile
This method will open file manager window for user to save file.

You first create file in temporary storage.

```csharp
var path = Path.Combine(Application.temporaryCachePath, "Test.txt");
CreateFile(path, someData);
FilePicker.ExportFile(path);
```

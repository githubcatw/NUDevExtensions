using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//NUDev Extensions v1.4
//2018 NUDev

/// <summary>
/// C# extensions to simplify working with Unity.
/// </summary>
namespace NUDev.Extensions
{
    /// <summary>
    /// The logging component, which is used to log different things.
    /// </summary>
    public class Logging : Component
    {
        /// <summary>
        /// Gets a component on all objects in a specified array.
        /// </summary>
        /// <typeparam name="T">The component itself.</typeparam>
        /// <param name="objects">The array of GameObjects to search in.</param>
        /// <returns>The component array.
        /// </returns>
        public T[] GetCompOnAllObjects<T>(GameObject[] objects)
        {
            // create new list
            List<T> ts = new List<T>();
            // loop through objects
            for (int i = 0; i < objects.Length; i++)
            {
                // add T of objects to list
                ts.Add(objects[i].GetComponent<T>());
            }
            // return array of list
            return ts.ToArray();
        }

        /// <summary>
        /// Logs all currently loaded scenes as an array of type Scene.
        /// </summary>
        /// <returns>The scene array.</returns>
        public Scene[] LogAllLoadedScenes()
        {
            List<Scene> scenes = new List<Scene>();
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                scenes.Add(SceneManager.GetSceneAt(i));
            }
            return scenes.ToArray();
        }

        /// <summary>
        /// Logs every camera device currently connected.
        /// </summary>
        /// <see cref="External.SaveWebcamAsPNG(string, string, int)"/> to capture an image from one of the webcams.
        public void LogAllCameraDevices()
        {
            WebCamDevice[] devices = WebCamTexture.devices;

            for (int i = 0; i < devices.Length; i++)
            {
                Debug.Log("Number " + i + " - " + devices[i].name);
            }
        }
    }

    /// <summary>
    /// The external component, which is used to simplify the work with external devices.
    /// </summary>
    public class External : Component
    {
        /// <summary>
        /// Saves the webcam output as a PNG file.
        /// </summary>
        /// <param name="filename">The PNG file's name, without the .png extension.</param>
        /// <param name="output">The output path.</param>
        /// <param name="number">The number of the device.</param>
        /// <see cref="Logging.LogAllCameraDevices"/> to log all device numbers.
        public void SaveWebcamAsPNG(string filename, string output, int number)
        {
            WebCamDevice[] devices = WebCamTexture.devices;
            if (WebCamTexture.devices.Length == 0)
            {
                Debug.LogError("No webcam detected!");
                //dataEngine.isError = true;
            }
            else
            {
                if (filename == null)
                {
                    filename = "NE_picture_" + Random.Range(1, 9) + Random.Range(1, 9) + Random.Range(1, 9);
                    Debug.LogWarning("Filename string = null, using default filename");
                }
                else
                {
                    Debug.Log("Capturing from device " + number + ": " + devices[number].name);
                    Debug.Log("Capturing to file: " + filename);
                    WebCamTexture wt = new WebCamTexture(devices[number].name);
                    Texture2D w2 = new Texture2D(wt.width, wt.height);
                    wt.Play();
                    w2.SetPixels(wt.GetPixels());
                    w2.Apply();
                    byte[] wcbytes = w2.EncodeToPNG();
                    string bytepath = output + "/../" + filename + ".png";
                    System.IO.File.WriteAllBytes(bytepath, wcbytes);
                    wt.Stop();
                    Object.Destroy(w2);
                    Debug.Log("Saved camera output to: " + Application.dataPath + "/" + filename + ".png");
                }
            }
        }
    }
    /// <summary>
    /// The conversion component, which is used to convert different things.
    /// </summary>
    public class Conversion : Component
    {
        // dependencies for elements
        string cvalue;
        /// <summary>
        /// Converts a boolean into a string.
        /// </summary>
        /// <param name="toConvert">The boolean to convert.</param>
        public string FromBool(bool toConvert)
        {
            if (toConvert == true)
            {
                cvalue = "true";
            }

            if (toConvert == false)
            {
                cvalue = "false";
            }

            return cvalue;
        }

        /// <summary>
        /// Converts a vector into a quaternion.
        /// </summary>
        /// <param name="input">The vector to convert.</param>
        public Quaternion VectorToQuat(Vector3 input)
        {
            Quaternion qoutput = new Quaternion(input.x, input.y, input.z, 0);
            return qoutput;
        }
    }
    /// <summary>
    /// The testing component, which is used to test the installation of NUDevExtensions.
    /// Now call the Test() function.
    /// </summary>
    public class Testing : Component
    {
        /// <summary>
        /// Tests the installation of NUDevExtensions.
        /// </summary>
        public void Test()
        {
            Debug.Log("Hello!\nNUDev Extensions version 1.4 is working!");
        }
    }

    /// <summary>
    /// The math component, which is used to do different math tasks.
    /// </summary>
    public class Math : Component
    {
        /// <summary>
        /// Returns an average of 2 numbers.
        /// </summary>
        /// <param name="num1">Number 1.</param>
        /// <param name="num2">Number 2.</param>
        /// <param name="reverse">Reverses the operation if set to <c>true</c>.</param>
        public int Average(int num1, int num2, bool reverse)
        {
            if (reverse == false)
            {
                return num1 - num2;
            }
            else
            {
                return num2 - num1;
            }
        }
    }
}

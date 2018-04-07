using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NUDev Extensions v1.3.1
//C 2018 NUDev inc.
/// <summary>
/// C# extensions to simplify Unity.
/// </summary>
namespace NUDev.Extensions
{
    /// <summary>
    /// The external engine, which is used to simplify the work with external devices.
    /// </summary>
    public class ExternalEngine : Component
    {
        /// <summary>
        /// Saves the webcam output as a PNG file.
        /// </summary>
        /// <param name="filename">The PNG file's name, without the .png extension.</param>
        /// <param name="number">The number of the device. Use http://bit.ly/newbcvl to find out the number.</param>
        public void SaveWebcamAsPNG(string filename, int number)
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
                    Debug.LogWarning("Filename = null, using default filename");
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
                    string bytepath = Application.dataPath + "/../" + filename + ".png";
                    System.IO.File.WriteAllBytes(bytepath, wcbytes);
                    wt.Stop();
                    Object.Destroy(w2);
                    Debug.Log("Saved camera output to: " + Application.dataPath + "/" + filename + ".png");
                }
            }
        }
    }
    /// <summary>
    /// The conversion engine, which is used to convert different things.
    /// </summary>
    public class ConversionEngine : Component
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
    /// The test engine, which is used to test the installation of NUDevExtensions.
    /// Now call the Test() function.
    /// </summary>
    public class TestEngine : Component
    {
        /// <summary>
        /// Tests the installation of NUDevExtensions.
        /// </summary>
        public void Test()
        {
            Debug.Log("Hello!\nWelcome to NUDev Extensions version 1.4!");
        }
    }

    /// <summary>
    /// The math engine, which is used to do different math tasks.
    /// </summary>
    public class MathEngine : Component
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

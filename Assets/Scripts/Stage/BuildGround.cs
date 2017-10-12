using UnityEngine;
using System.Collections;
using System.Threading;

public class BuildGround : MonoBehaviour
{
    public GameObject point_prefab; // Contains the bar prefab. Will rename to bar_prefab eventually
    static public GameObject[] bar_array; // Array containing the front row of bar prefabs. Once a row is created and the height of each bar is reflective of the audio spectrum, they get removed from the array and moved by another script until recycled
    public GameObject[] point_array; // Was created when I thought the ground was going to be 1 solid mesh. Will remove later

    private int number_of_points; // Specifies how many bars in a row. Will heavily affect performance
    private int time_delay = 2; // Probably was used in a previous version of the game. Will remove later
    private int count = 0; // Probably used for some debugging. Will probably remove later
    static public int count2 = 0; // Counter used to stop the spawning of new bars to recycle them for performance improvements (when a row gets to the end of the stage it gets moved back to the front and treated as a new row)

    public float[] spectrum; // An array containing the amplitude at discrete frequencies of the audio spectrum
    public float[] volume = new float[64]; // Not really sure what this is supposed to be. Added while drunk lol 
    static public float average; // Average of the overall audio spectrum per frame
    static public float average_low; // Average of the low frequency range of the spectrum per frame
    static public float average_mid; // Average of the mid frequency range of the spectrum per frame
    static public float average_high; // Average of the high frequency range of the spectrum per frame

    void Start()
    {
        count = 0;
        count2 = 0;
        number_of_points = Initilize.number_of_blocks;
    }

    void Update()
    {
        //count++;

        if (count2 < Initilize.cave_depth + 1) { count2++; createBars(); }
        else { count2 = Initilize.cave_depth + 2; }

        bar_array = GameObject.FindGameObjectsWithTag("Bar");

        spectrum = AudioListener.GetSpectrumData(1024, 0, FFTWindow.Hamming);

        for (int i = 0; i < bar_array.Length; i++)
        {

            average += spectrum[i];
            
            if (i < number_of_points/3)
            {
                average_low += spectrum[i];
            }
            else if (i >= number_of_points / 3 && i < number_of_points * 2 / 3)
            {
                average_mid += spectrum[i];
            }
            else
            {
                average_high += spectrum[i];
            }

            Vector3 point_amplitude = bar_array[i].transform.localScale;
            point_amplitude.y = spectrum[i] * Mathf.Pow(i + 1, 0.7f) * Initilize.cave_intensity;
            point_amplitude.x = Initilize.block_width;
            bar_array[i].transform.localScale = point_amplitude;
            bar_array[i].transform.tag = "Point";
        }

        average = average / number_of_points;
        average_low = average_low / number_of_points / 3;
        average_mid = average_mid / number_of_points / 3;
        average_high = average_high / number_of_points / 3;
    }

    void createBars()
    {
        average = 0;

        AudioListener.GetOutputData(volume, 0);
        for (int i = 0; i < number_of_points / 2; i++)
        {
            Vector3 point_position = new Vector3(i * Initilize.cave_width, 0, 0);
            Instantiate(point_prefab, point_position, Quaternion.identity);
        }
        for (int i = number_of_points / 2; i < number_of_points; i++)
        {
            Vector3 point_position = new Vector3((i - number_of_points / 2) * Initilize.cave_width, Initilize.cave_height, 0);
            Instantiate(point_prefab, point_position, Quaternion.identity);
        }

        //count = 0;
    }
}

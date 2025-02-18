using System.ComponentModel.DataAnnotations;
using System.Numerics;

public class Earth
{
    static int surfaceResolution;
    static int atmosphereResolution;

    Cube top;
    Cube bottom;
    Cube front;
    Cube back;
    Cube left;
    Cube right;

    public Earth(int _surfaceResolution, int _atmosphereResolution)
    {
        surfaceResolution = _surfaceResolution;
        atmosphereResolution = _atmosphereResolution;

        top = new(surfaceResolution, atmosphereResolution);
        bottom = new(surfaceResolution, atmosphereResolution);
        front = new(surfaceResolution, atmosphereResolution);
        back = new(surfaceResolution, atmosphereResolution);
        left = new(surfaceResolution, atmosphereResolution);
        right = new(surfaceResolution, atmosphereResolution);
    }
}

public class Cube
{
    private int surfaceResolution;
    private int atmosphereResolution;

    public Cell[,] cells;

    public Cube(int _surfaceResolution, int _atmosphereResolution)
    {
        surfaceResolution = _surfaceResolution;
        atmosphereResolution = _atmosphereResolution;

        cells = new Cell[surfaceResolution, surfaceResolution];
        for (int i = 0; i < surfaceResolution; i++)
        {
            for (int j = 0; j < surfaceResolution; j++)
            {
                cells[i, j] = new Cell(atmosphereResolution, new Vector2(i, j));
            }
        }
    }
}


//just a test
public struct Cell(int _atmosphereResolution, Vector2 _localCoordinates)
{
    // public Surface Surface = Surface.Land;
    // public Atmosphere[] Atmospheres = new Atmosphere[_atmosphereResolution];
    // public Vector2 GeoCoordinates;
    static Random random = new Random();
    public float temperature = random.Next(0, 100);
    public Vector2 LocalCoordinates = _localCoordinates;


}


public class Surface
{
    public int height;
    public int temperature;
    [Range(-1, 1)]
    public float surfaceMoisture;


    public Surface(int _height = 0, int _temperature = 20, float _surfaceMoisture = 0)
    {
        height = _height;
        temperature = _temperature;
        surfaceMoisture = _surfaceMoisture;
    }

    public static readonly Surface Water = new(0, 20, -1);
    public static readonly Surface Land = new(0, 20, 0);

}


public struct Atmosphere
{
    public int temperature;
    public int pressure;

    public Atmosphere(int _temperature = 10, int _pressure = 1000)
    {
        temperature = _temperature;
        pressure = _pressure;
    }
}

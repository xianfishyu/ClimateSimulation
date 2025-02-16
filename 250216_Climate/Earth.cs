using System.ComponentModel.DataAnnotations;

public class Earth
{
    static int surfaceResolution = 10000;
    static int atmosphereResolution = 2;

    Cube top = new Cube(
        surfaceResolution, atmosphereResolution);
    Cube bottom = new Cube(
        surfaceResolution, atmosphereResolution);
    Cube front = new Cube(
        surfaceResolution, atmosphereResolution);
    Cube back = new Cube(
        surfaceResolution, atmosphereResolution);
    Cube left = new Cube(
        surfaceResolution, atmosphereResolution);
    Cube right = new Cube(
        surfaceResolution, atmosphereResolution);

}

public class Cube
{
    private int surfaceResolution;
    private int atmosphereResolution;

    public Cube(int _surfaceResolution, int _atmosphereResolution)
    {
        surfaceResolution = _surfaceResolution;
        atmosphereResolution = _atmosphereResolution;
    }
}

public struct Cell(int _atmosphereResolution)
{
    public Surface surface = Surface.Land;
    public Atmosphere[] atmospheres = new Atmosphere[_atmosphereResolution];
}


public class Surface
{
    public int height;
    public int temperature;

    [Range(-1, 1)]
    public float surfaceMoisture;

    public static readonly Surface Water = new(0, 20, -1);
    public static readonly Surface Land = new(0, 20, 0);

    public Surface(int _height = 0, int _temperature = 20, float _surfaceMoisture = 0)
    {
        height = _height;
        temperature = _temperature;
        surfaceMoisture = _surfaceMoisture;
    }
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

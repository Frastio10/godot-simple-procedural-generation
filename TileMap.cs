using Godot;
using System;

public class TileMap : Godot.TileMap
{
    // Declare member variables here. Examples:
    public int max_x = 200;
    public int max_y = 200;

    private OpenSimplexNoise noise = new OpenSimplexNoise();
    private int snap_size_x = 8;
    private int snap_size_y = 8;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("test?");
        GD.Randomize();
        noise.Seed = Convert.ToInt32(GD.Randi());
        noise.Octaves = 0;
        noise.Period = 5;
        noise.Persistence = 0.588f;
        noise.Lacunarity = 2.43f;
    }

    public void GenerateLevel()
    {
        for (int x = 0; x < max_x; x++)
        {
            for (int y = 0; y < max_y; y++)
            {
                int tile_id = GenerateID(noise.GetNoise2d(x, y));
                if(tile_id != -1)
                {
                    SetCell(x, y, tile_id);
                }
            }
        }
    }

    public int GenerateID(float noise_level)
    {
        if(noise_level <= 0)
        {
            return -1;
        } else
        {
            return 0;
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}

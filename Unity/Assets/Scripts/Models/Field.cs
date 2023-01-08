namespace LD52.Models
{
    public class Field
    {
        public CropInstance[,] Crops = new CropInstance[4, 3];
        
        public Field(Crop crop)
        {
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    Crops[i, j] = new CropInstance(crop.Id);
                }
            }
        }
    }
}
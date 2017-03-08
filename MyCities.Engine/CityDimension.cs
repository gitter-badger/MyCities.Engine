namespace MyCities.Engine
{
    public class CityDimension
    {
        public int width;
        public int height;

        public CityDimension(int w, int h)
        {
            width = w;
            height = h;
        }


        public override int GetHashCode()
        {
            return width * 33 + height;
        }


        public override bool Equals(object obj)
        {
            if (obj is CityDimension cityDim)
                return width == cityDim.width && height == cityDim.height;
            else
                return false;
        }


        public override string ToString()
        {
            return $"{width}x{height}";
        }
    }
}

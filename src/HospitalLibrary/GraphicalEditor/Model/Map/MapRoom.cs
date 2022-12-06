namespace HospitalLibrary.GraphicalEditor.Model.Map
{
    public class MapRoom : ValueObject<MapRoom>
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string Color { get; private set; }

        public MapRoom(int x, int y, int width, int height, string color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Color = color;
        }

        protected override bool EqualsCore(MapRoom room)
        {
            return X == room.X &&
                   Y == room.Y &&
                   Width == room.Width &&
                   Height == room.Height &&
                   Color == room.Color;
        }

        protected override int GetHashCodeCore()
        {
            return HashCode.Combine(base.GetHashCode(), X, Y, Width, Height, Color);
        }
    }
}

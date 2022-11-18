namespace ProductsApi.Dto
{
    public class CursorParams
    {
        public int Count { get; set; } = 50;
        public int Cursor { get; set; } = 0;
    }
}

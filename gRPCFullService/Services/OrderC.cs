namespace gRPCFullService.Services
{
    public class OrderC
    {
        public int Id{ get; set; }
        public string Name { get; set; }
    }
    public class OrderItem 
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public int OrderCId { get; set; }
        public int Count { get; set; }
    }
}
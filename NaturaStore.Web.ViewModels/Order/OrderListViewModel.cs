namespace NaturaStore.Web.ViewModels.Order
{
    public class OrderListViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Status { get; set; } = null!;
        public decimal Total { get; set; }
    }
}

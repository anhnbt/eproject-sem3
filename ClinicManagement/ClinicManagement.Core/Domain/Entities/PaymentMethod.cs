namespace ClinicManagement.Core.Domain.Entities
{
  public class PaymentMethod
  {
    public int PaymentMethodId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
  }
}

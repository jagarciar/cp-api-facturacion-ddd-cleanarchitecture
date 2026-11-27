

namespace InvoiceManagement.Domain.Entities
{
    public abstract class Base
    {
        public Guid Id { get; private set; }

        public Base()
        {
            this.Id = Guid.CreateVersion7();
        }
    }
}

using System;

namespace OrderSystem.Models
{
    public struct NewOrder
    {
        public readonly Guid CustomerUid;
        public readonly DateTime OrderCreateRequestDate;
        public readonly Guid OrderUid;

        public NewOrder(Guid customerUid, DateTime createRequestDate) : this()
        {
            CustomerUid = customerUid;
            OrderCreateRequestDate = createRequestDate;
            OrderUid = Guid.NewGuid();
        }
    }
}

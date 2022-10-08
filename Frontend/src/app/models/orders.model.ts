export class Orders {
    constructor(
        public OrderId?: number, 
        public UserId?: number,
        public BookId?: number,
        public Quantity?: number,
        public AddressId?: number,
        public Date?: string
    ){}
}

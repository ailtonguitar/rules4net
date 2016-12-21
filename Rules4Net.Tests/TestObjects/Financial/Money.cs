namespace Rules4Net.Tests.TestObjects.Financial {
    public class Money {
        public decimal Amount { get; }
        public Currency Currency { get; }
        public Money(decimal amount, Currency currency) {
            Amount = amount;
            Currency = currency;
        }

        public override bool Equals(object obj) {
            var that = obj as Money;
            if (that == null)
                return false;

            return that.Amount == this.Amount 
                        && that.Currency == this.Currency;
        }

        public override int GetHashCode() {
            return Amount.GetHashCode() ^ Currency.GetHashCode();
        }
    } //class
}

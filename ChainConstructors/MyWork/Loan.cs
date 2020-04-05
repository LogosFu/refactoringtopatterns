using System;

namespace ChainConstructors.MyWork
{
    public class Loan
    {
        private CapitalStrategy _strategy;
        private float _notional;
        private float _outstanding;
        private int _rating;
        private DateTime _expiry;
        private DateTime _maturity;

        public Loan()
        {
        }

        public static Loan CreateTermLoan(float notional, float outstanding, int rating, DateTime expiry)
        {
            var capitalStrategy = new TermROC();
            return new Loan(capitalStrategy, notional, outstanding, rating, expiry, null);
        }

        public static Loan CreateTermLoan(float notional, float outstanding, int rating, DateTime expiry,
            DateTime maturity)
        {
            var revolvingTermRoc = new RevolvingTermROC();
            return new Loan(revolvingTermRoc, notional, outstanding, rating, expiry, maturity);
        }

        private Loan(CapitalStrategy strategy, float notional, float outstanding,
            int rating, DateTime expiry, DateTime? maturity)
        {
            this._strategy = strategy;
            this._notional = notional;
            this._outstanding = outstanding;
            this._rating = rating;
            this._expiry = expiry;
            if (maturity != null) this._maturity = (DateTime) maturity;
        }

        public CapitalStrategy CapitalStrategy
        {
            get { return _strategy; }
        }
    }
}
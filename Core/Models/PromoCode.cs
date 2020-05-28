using System;
namespace Core.Models
{
    public class PromoCode
    {
        public Guid PromoCodeId { get; private set; }

        public DateTime PromoStart { get; private set; }

        public DateTime PromoEnd { get; private set; }

        public int Percentage { get; set; }

        private PromoCode() { }

        public PromoCode Create(DateTime promoStart, DateTime promoEnd, int percentage)
        {
            if (promoStart < DateTime.Now)
                throw new ArgumentOutOfRangeException(nameof(promoStart), "Promo Start should be today's date or later.");

            if (promoEnd < promoStart)
                throw new ArgumentOutOfRangeException(nameof(promoEnd), "Promo End should be later than promo start.");

            if (percentage < 0 || percentage > 100)
                throw new ArgumentOutOfRangeException(nameof(percentage), "Percentage should be between 0 and 100");

            return new PromoCode() { PromoStart = promoStart, PromoEnd = promoEnd, Percentage = percentage };
        }
    }
}


namespace PVT.Q1._2017.Shop.Areas.Payment.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using global::Shop.Common.Models;
    using global::Shop.Common.ViewModels;
    using global::Shop.Infrastructure.Models;

    public class PaymentMapper
    {

        /// <summary>
        ///     The mapper for models with detailed information.
        /// </summary>
        private static readonly IMapper _paymentModelsMapper;

        /// <summary>
        ///     Initializes static members of the <see cref="PaymentMapper" /> class.
        /// </summary>
        static PaymentMapper()
        {
            _paymentModelsMapper = CreatePaymentMapper();
        }

        /// <summary>
        /// New instance of Payment transaction view model
        /// </summary>
        /// <param name="paymentTransaction">source payment transaction</param>
        /// <returns></returns>
        public static PaymentTransactionViewModel GetPaymentTransactionViewModel(PaymentTransaction paymentTransaction)
        {
            return _paymentModelsMapper.Map<PaymentTransactionViewModel>(paymentTransaction);
        }

        /// <summary>
        /// New instance of Payment transaction view models in IEnamerable collection
        /// </summary>
        /// <param name="paymentTransaction">source payment transaction</param>
        /// <returns></returns>
        public static IEnumerable<PaymentTransactionViewModel> GetPaymentTransactionViewModels(IEnumerable<PaymentTransaction> paymentTransactions)
        {
            var result = new List<PaymentTransactionViewModel>();
            if (paymentTransactions != null)
            {
                foreach (var transaction in paymentTransactions)
                {
                    result.Add(_paymentModelsMapper.Map<PaymentTransactionViewModel>(transaction));
                }
            }
            return result;
        }

        public static PagedResult<PaymentTransactionViewModel> GetPaymentTransactionsToEdit(PagedResult<PaymentTransaction> paymentTransactions)
        {
            return new PagedResult<PaymentTransactionViewModel>(_paymentModelsMapper.Map<ICollection<PaymentTransactionViewModel>>(paymentTransactions.Items),
                                                 paymentTransactions.PageSize, paymentTransactions.CurrentPage, paymentTransactions.TotalItemsCount);
        }

        /// <summary>
        ///     Configures and returns a new instance of the mapper for models which have a list of other models.
        /// </summary>
        /// <returns>
        ///     A new instance of the mapper for models which have a list of other models.
        /// </returns>
        private static IMapper CreatePaymentMapper()
        {
            var managementConfiguration = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<PaymentTransaction, PaymentTransactionViewModel>()
                        .ForMember(dest => dest.UserName,
                                    opt => opt.MapFrom(src => src.User.User.Login))
                        .ForMember(dest => dest.CurrencyShortName,
                                    opt => opt.MapFrom(src => src.Currency.ShortName))
                        ;
                });

            return managementConfiguration.CreateMapper();
        }
    }
}
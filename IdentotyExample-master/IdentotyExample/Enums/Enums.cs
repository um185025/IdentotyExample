
namespace IdentotyExample.Enums
{
    public class Enums
    {
        [Flags]
        public enum OrderModeType
        {
            Pickup = 1,
            Delivery = 2,
            CurbSide = 4,
            SVCDeposit = 8,
            DineIn = 16,
            DriveThru = 64,
            Undefined = 128,
            WalkIn = 512
        }

        public enum CreditProcessingMode
        {
            NotSupported = 0,
            Integrated = 1,
            HostedAuthorizeDotNet = 2,
            HostedElavonInternetSecure = 3,
            HostedVantiv = 6,
            CreditCall = 7,
            ConnectedPayments = 8,
            Braintree = 9,
            FreedomPay = 10
        }

        public enum ItemOrderingMode
        {
            Normal = 0,
            Pizza = 1,
            QtyModifierItem = 2,
            BuildYourOwn = 3,
            ModifierDeterminesQty = 4
        }

        public enum SectionType
        {
            Unassigned = 0,
            Half = 1,
            Third = 3,
            Quarter = 4,
            Left = 11,
            Right = 12
        }
        [Flags]
        public enum ModifierAction
        {
            Default = 0,
            Add = 1,
            No = 2,
            Extra = 4,
            Side = 8,
            Light = 16,
            Everything = 32,
            Plain = 64
        }

        public enum PromoType
        {
            Unknown = 0,
            BOGO = 1,
            Combo = 2,
            Coupon = 3,
            NewPrice = 4,
            CheckReduction = 5,
            QuickCombo = 6,
            PackagePromo = 7
        }

        public enum PaymentMode
        {
            Unknown = 0,
            ProvidedToSite = 1,
            PaymentDeferred = 2,
            PaidOnline = 3
        }

        public enum OrderSourceType
        {
            Web = 0,
            Mobile = 1,
            MobileWeb = 2,
            None = 3,
            Online = 4,
            Counter = 5
        }

        public enum DestinationType
        {
            DestinationNull = 0,
            MobileDineIn = 1,
            MobileCarryOut = 2,
            MobileCurbSide = 3,
            MobileDriveThru = 4,
            CateringPickUp = 5,
            CateringDelivery = 6
        }

        public enum AddressType
        {
            Billing = 1,
            NonBilling = 2
        }

        public enum OrderResultCodes
        {
            Success = 0,
            GeneralFailure = 1,
            SiteCommunicationFailure = 2,
            ItemFailures = 3,
            PromiseTimeChanged = 4,
            OrderMinimumNotMet = 5,
            FailedToStartOrder = 6,
            FailedToUpdateOrder = 7,
            InvalidSiteOrder = 11,
            SiteNotAcceptingOrders = 12,
            CapacityExceeded = 13,
            InvalidPaymentInformation = 14,
            FailedToSubmitOrder = 15,
            UnsupportedOrderMode = 16
        }

        public enum OrderStatus
        {
            Invalid = 0,
            Unordered = 1,
            Validated = 2,
            Submitted = 3,
            PendingOperation = 4,
            Deleted = 5,
            CreditProcessed = 6,
            SubmittedAndCanceled = 7,
            SubmittedWithDepositFailure = 8,
            Combined = 9,
            Closed = 10
        }

        public enum OrderLineItemStatus
        {
            Normal = 0,
            UnknownError = 1
        }

        public enum AlohaRewardType
        {
            Comp = 0,
            Promo = 1,
            Other = 2
        }

        public enum PaymentType
        {
            PayAtSite = 0,
            CreditCard = 1,
            GiftCard = 2,
            SavedCreditCard = 3
        }

        public enum PaymentCardType
        {
            Unknown = 0,
            Visa = 1,
            Mastercard = 2,
            Amex = 3,
            Discover = 4,
            DinersClub = 5,
            JCB = 6,
            Paypal = 7,
            GlobalBlue = 8,
            Worldpay = 9
        }

        public enum PaymentStatus
        {
            Pending = 0,
            Applied = 1,
            Cancelled = 2
        }

        public enum ProcessingType
        {
            CreditCard = 0,
            Token = 1,
            Braintree = 2,
            FreedomPay = 3
        }

        public enum P2PEComboType
        {
            NonP2PETransaction = 0,
            VoltageIPP350_VisaNet = 1,
            TransArmorVX820_CES = 2,
            VoltageIPP330_HeartLand = 3,
            TransArmorVX820_WorldPay = 4,
            VoltageIPP330_Vantiv = 5
        }
        
        public enum ClientPlatformType
        {
            Unknown = 0,
            DesktopWeb = 1,
            MobileWeb = 2,
            WindowsPhone = 3,
            Ios = 4,
            Android = 5,
            ThirdParty = 6
        }

        public enum OrderDiscountType
        {
            AlohaLoyaltyComp = 0,
            AlohaLoyaltyPromo = 1,
            AlohaLoyaltyOther = 2,
            None = 3,
            Promo = 4,
            Comp = 5,
            Other = 6,
            PesRewardDollars = 7,
            PesRewardOffers = 8
        }

        public enum DiscountStatus
        {
            None = 0,
            Accepted = 1,
            Rejected = 2
        }

        public enum OrderDiscountSource
        {
            OnlineOrdering = 0,
            AlohaLoyalty = 1
        }

        public enum PesStatus
        {
            ACTIVE = 0,
            INACTIVE = 1
        }

        public enum PesProgramType
        {
            POINTS = 0,
            STORED_VALUE = 1,
            VISITS = 2
        }
    }
}

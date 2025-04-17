


namespace GDFFoundation
{
    public enum GDFAccountServiceStatus
    {
        /// <summary>
        /// Represents the inactive status of an account service.
        /// </summary>
        IsInactive = 0,

        /// <summary>
        /// Represents the status of an account service.
        /// </summary>
        IsActive = 1,

        //waiting activation and then add duration to now
        /// <summary>
        /// Represents the status of an account service when it is waiting for activation.
        /// </summary>
        IsWaitingActivation = 3,

        // Alert user ... 
        /// <summary>
        /// Represents the status of a GDFAccountService indicating whether it is banned.
        /// </summary>
        IsBan = 9,

        // copy this service as subservice and stay as subservice ( to reatribue later)
        /// <summary>
        /// Represents the sub-serviced status of an account service.
        /// </summary>
        IsSubServiced = 88,

        // copy as original and desactive this service 
        /// <summary>
        /// Enum member for GDFAccountServiceStatus indicating that the account is waiting for transfer.
        /// </summary>
        IsToTranfert = 99,

    }
}


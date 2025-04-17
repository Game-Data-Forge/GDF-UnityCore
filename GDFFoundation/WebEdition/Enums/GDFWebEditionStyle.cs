

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Enum defining the styles for GDFWebEdition.
    /// </summary>
    [Serializable]
    public enum GDFWebEditionStyle
    {
        Text,
        TextArea,
        Password,
        PasswordWithAnalyze,
        Email,
        Checkbox,
        CheckboxLeft,
        CheckboxWithLabel,
        CheckboxLeftWithLabel,
        Switch,
        SwitchLeft,
        SwitchWithLabel,
        SwitchLeftWithLabel,
        Captcha,
        CaptchaImage,
        Slider,
        Token,
        Date,
        DateTime,
        Time,
        Month,

        Numeric,
        
        EnumDropdown,
        EnumRadio,
        
        FlagDropdown,
        FlagCheckbox,
        
        


        /// <summary>
        /// Enumeration for GDFWebEditionStyle.
        /// </summary>
        Enum,

        /// Flag
        /// An enum member of the GDFWebEditionStyle enum.
        /// /
        Flag,

        /// Dropdown
        /// <summary>
        /// Represents a dropdown style for web edition.
        /// </summary>
        Dropdown,

        /// <summary>
        /// Defines the color property for the GDFWebEditionStyle enum.
        /// </summary>
        Color,

        /// <summary>
        /// Represents an Object style for GDFWebEditionStyle.
        /// </summary>
        Object,

        /// <summary>
        /// Represents a hidden web edition style.
        /// </summary>
        Hidden,

        /// <summary>
        /// Enumeration for specifying the status of a show part.
        /// </summary>
        ShowPartStatus,

        /// <summary>
        /// Represents a reference array edition style for web edition properties.
        /// </summary>
        ReferenceArray,

        /// <summary>
        /// Represents the GDFWebEditionStyle enum member ShowTextOnly.
        /// </summary>
        ShowTextOnly,

        /// <summary>
        /// Represents the ShowIntOnly member of the GDFWebEditionStyle enum.
        /// </summary>
        ShowIntOnly,

        /// <summary>
        /// Indicates that the web edition style of the property is to show long only.
        /// </summary>
        ShowLongOnly,

        /// <summary>
        /// Enumeration representing the style of web edition for a property.
        /// </summary>
        List,
        Country,

        /// <summary>
        /// Represents the track of a web edition style.
        /// </summary>
        Track,

        /// *Namespace**: GDFFoundation
        /// *Usage**:
        Language,

        /// <summary>
        /// Represents the available languages for the web edition style.
        /// </summary>
        Languages,
    }
}




using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a class for the web edition of a class description.
    /// </summary>
    [Serializable]
    public class GDFWebEditionClassDescription
    {
        /// <summary>
        /// Represents the title of a web edition class description.
        /// </summary>
        public string Title = "Item";

        /// <summary>
        /// Represents a Bootstrap icon.
        /// </summary>
        public string Icon = "bi-gear";

        /// <summary>
        /// Represents the description of a web edition class.
        /// </summary>
        public string Description = "Item management system.";

        /// <summary>
        /// Represents the options for the number of items per page in pagination.
        /// </summary>
        public int[] ItemsPerPageOption = new int[] { 5, 10, 15 };
        public bool JsonClipboard = false;

        /// <summary>
        /// Gets or sets a value indicating whether the reference should be shown.
        /// </summary>
        public bool ShowReference = false;

        /// <summary>
        /// Represents the ShowButton variable.
        /// </summary>
        public bool ShowButton = false;
        public bool ShowBlankButton = false;
        public string NewItemString = "Add new Item";
        public string RefreshString = "Refresh";

        public string ItemsPerPageString = "{0} Items per page";
        public string DeleteString = "Delete this item";
        public string CancelString = "Cancel";
        public string ReferenceString = "Reference";
        public string YouWillDeleteThisItemString = "You will delete this item!";

        /// <summary>
        /// Represents a class that provides description for the web edition of a class.
        /// </summary>
        public GDFWebEditionClassDescription()
        {
        }

        /// Represents a class description for the GDFWebEditionClass.
        /// /
        public GDFWebEditionClassDescription(string title, string icon, string description, int[] itemsPerPageOption, bool jsonClipboard, bool showReference, bool showButton, bool showBlankButton, string newItemString = "Add new Item", string refreshString = "Refresh")
        {
            Title = title;
            Icon = icon;
            Description = description;
            ItemsPerPageOption = itemsPerPageOption;
            JsonClipboard = jsonClipboard;
            ShowReference = showReference;
            ShowButton = showButton;
            ShowBlankButton = showBlankButton;
            NewItemString = newItemString;
            RefreshString = refreshString;
        }
    }
}


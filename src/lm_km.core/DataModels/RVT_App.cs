using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;

namespace lm_km.core
{
    public static class RVT_App
    {
        #region public properties
        /// <summary>
        /// Gets or sets the <see cref="UIControlledApplication"/>
        /// </summary>
        /// <value>
        /// The Revit UIControlledApplication.
        /// </value>
        public static UIControlledApplication RVT_UIControlledApp  { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Autodesk.Revit.UI.UIApplication"/>
        /// </summary>
        /// <value>
        /// The Revit UIApplication.
        /// </value>
        public static UIApplication RVT_UIApp  { get; set; }
        /// <summary>
        /// Container for pairing <see cref="Document"/> and <see cref="MainPageContainerViewModel.CurrentPage"/>
        /// </summary>
        public static Dictionary<Document, ViewModelBase> RVTDocDictContainer = new Dictionary<Document, ViewModelBase>();
        #endregion
    }
}

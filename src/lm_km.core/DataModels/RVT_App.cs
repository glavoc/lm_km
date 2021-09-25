using Autodesk.Revit.UI;

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
        #endregion
    }
}

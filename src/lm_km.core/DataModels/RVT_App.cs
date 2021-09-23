using Autodesk.Revit.ApplicationServices;
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
        public static UIControlledApplication RVT_ControlledApp { get; set; }
        #endregion
    }
}

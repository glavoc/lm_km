using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lm_km.core
{
    public class Keynote
    {
        #region public properties
        /// <summary>
        /// Gets or sets the category number of Keynote
        /// </summary>
        /// <value>
        /// The Keynote Category Number.
        /// </value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the text of the keynote
        /// </summary>
        /// <value>
        /// The Keynote Text.
        /// </value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the Parent category of Keynote
        /// </summary>
        /// <value>
        /// The Keynote Parent Category Number.
        /// </value>
        public string Parent { get; set; }
        #endregion
    }
}

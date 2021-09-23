using System;
using System.IO;
using System.Reflection;

namespace lm_km.core
{
    public class PaneIdentifiers
    {
        #region public methods

        /// <summary>
        /// The family manager dockable pane identifier.
        /// </summary>
        /// <returns></returns>
        public static Guid GetManagerPaneIdentifier()
        {
            return new Guid("6B91BD5C-783F-4274-A4A8-6E2E9A09B2A6") ;
        }

        public static string AssemblyPath()
        {
            return Assembly.GetExecutingAssembly().Location;
        }

        public static string BitmapsFolder()
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "SMG_Keynote_Manager_rsc");
        }
        #endregion
    }
}

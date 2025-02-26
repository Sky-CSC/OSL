using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSL_CDragon.Schema
{
    /// <summary>
    /// List of assets for epics monsters
    /// </summary>
    internal class EpicMonster
    {
        /// <summary>
        /// Assets for dragons
        /// </summary>
        public Dragon Dragons { get; set; }
        /// <summary>
        /// List of assets for the Baron
        /// </summary>
        public List<Asset> Barons { get; set; }
        /// <summary>
        /// List of assets for the Herald
        /// </summary>
        public List<Asset> Heralds { get; set; }
        /// <summary>
        /// List of assets for the Void Grubs
        /// </summary>
        public List<Asset> VoidGrubs { get; set; }
        /// <summary>
        /// List of assets for the Atakhans
        /// </summary>
        public List<Asset> Atakhans { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EpicMonster"/> struct.
        /// </summary>
        public EpicMonster() {
            Dragons = new Dragon();
            Barons = [];
            Heralds = [];
            VoidGrubs = [];
            Atakhans = [];
        }
    }
}

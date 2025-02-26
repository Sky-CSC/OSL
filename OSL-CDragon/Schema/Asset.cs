using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSL_CDragon.Schema
{
    /// <summary>
    /// Data structure for assets
    /// </summary>
    internal class Asset
    {
        /// <summary>
        /// Unique identifier for the asset
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Name of the asset
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description of the asset
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Path to the asset
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// List of types of the asset
        /// </summary>
        public List<AssetType> Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PositionInfo"/> struct.
        /// </summary>
        public Asset()
        {
            Id = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Path = string.Empty;
            Type = [AssetType.NotSet];

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PositionInfo"/> struct.
        /// </summary>
        /// <param name="id">Id of asset</param>
        public Asset(string id)
        {
            Id = id;
            Name = string.Empty;
            Description = string.Empty;
            Path = string.Empty;
            Type = [AssetType.NotSet];

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PositionInfo"/> struct. 
        /// </summary>
        /// <param name="id">Id of asset</param>
        /// <param name="name">Name of asset</param>
        /// <param name="description">Description of asset</param>
        /// <param name="path">Path of asset</param>
        public Asset(string id, string name, string description, string path)
        {
            Id = id;
            Name = name;
            Description = description;
            Path = path;
            Type = [AssetType.NotSet];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PositionInfo"/> struct. 
        /// </summary>
        /// <param name="id">Id of asset</param>
        /// <param name="name">Name of asset</param>
        /// <param name="description">Description of asset</param>
        /// <param name="path">Path of asset</param>
        /// <param name="type">List of type of asset</param>
        public Asset(string id, string name, string description, string path, List<AssetType> type)
        {
            Id = id;
            Name = name;
            Description = description;
            Path = path;
            Type = type;
        }

        /// <summary>
        /// Asset types
        /// </summary>
        public enum AssetType
        {
            NotSet,
            Default,
            ChampSelect,
            InGame,
            InGameAnnoucement,
            InGameScoreBoard,
            EndGame,
        }
    }
}

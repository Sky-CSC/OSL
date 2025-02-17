namespace OSL_CDragon.Schema
{
    /// <summary>
    /// Data composed of an item's id, name, icon path, and lists of items it can be built from and into.
    /// </summary>
    internal class Item
    {
        /// <summary>
        /// The item's unique identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The item's name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The path to the item's icon.
        /// </summary>
        public string IconPath { get; set; }
        /// <summary>
        /// The list of items that this item can be built from.
        /// </summary>
        public List<int> From { get; set; }
        /// <summary>
        /// The list of items that this item can be built into.
        /// </summary>
        public List<int> To { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> struct.
        /// </summary>
        public Item()
        {
            Id = -42;
            Name = string.Empty;
            IconPath = string.Empty;
            From = [];
            To = [];
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> struct with item id.
        /// </summary>
        /// <param name="id"></param>
        public Item(int id, string name, string iconPath, List<int> from, List<int> to)
        {
            Id = id;
            Name = name;
            IconPath = iconPath;
            From = from;
            To = to;
        }

    }
}

namespace IoTBackend.Interfaces
{
    /// <summary>
    /// Common Framework to Get Data from Blob Storage
    /// </summary>
    public interface IBlobFramework
    {
        /// <summary>
        /// Get Content from blob on Url
        /// </summary>
        /// <param name="url">url for the blob</param>
        /// <returns></returns>
        string GetBlobContent(string url);
    }
}

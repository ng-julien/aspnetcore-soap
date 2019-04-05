namespace Roi.Client.Soap
{
    using Newtonsoft.Json.Linq;

    internal partial class UserInformation
    {
        public override string ToString()
        {
            return JObject.FromObject(this).ToString();
        }
    }
}
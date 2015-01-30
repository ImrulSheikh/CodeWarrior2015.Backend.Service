using System;
using System.Collections.Generic;
using DalBase = CW.Backend.DAL.Base;
using System.Linq;
using System.Web;

namespace EShopper.Helpers
{
    public static class ImagePathHelpers
    {
        private static string _folderLocation = "Content//uploads//";
        public static List<string> GetSeverRelativeImagePaths(string joinedNames)
        {
            return joinedNames
                .Split(new[] {DalBase.Constants.ObjectSeperator}, StringSplitOptions.None)
                .Select(n => string.Format("{0}//{1}", _folderLocation.TrimEnd('/'), n))
                .ToList();
        }
    }
}
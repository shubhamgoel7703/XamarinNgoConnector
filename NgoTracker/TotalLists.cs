using System;
using System.Collections.Generic;

namespace iConnect
{
    public class TotalLists
    {
		public static List<NGOObject> ngoNamesList = new List<NGOObject>();
		public static List<NGODescription> ngoDescriptionList = new List<NGODescription>();
        public static NGODescription SelectedNGO = new NGODescription();
        public static List<String> filteredList = new List<string>();

        public static String Location = null;

        public TotalLists()
        {
        }
    }
}

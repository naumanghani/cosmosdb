using CoreIMS.Application.Common.ExtensionMethods;
using CoreIMS.Domain.EnumsIMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreIMS.Application.Common.Models
{
    /// <summary>
    /// Represents the list of enums available to the UI
    /// </summary>
    public enum EnumModelName
    {
        ItemGroupTypes ,
        WeightUnitTypes,
        DimentionUnitTypes,
        GstTypes,
        AddressTypes,
        StoreTypes,
        TransBASETypes,
        TransStatusTypes,
    }

    /// <summary>
    /// Represents an enum for the front end (Value + Name)
    /// </summary>
    public class EnumModel
    {
        public int id { get; set; }
        public string name { get; set; }

        /// <summary>
        /// Factory method to return a dictionary of all public facing enum types
        /// </summary>
        /// <returns></returns>
        public static Dictionary<EnumModelName, IEnumerable<EnumModel>> CreateEnumDictionary()
        {
            Dictionary<EnumModelName, IEnumerable<EnumModel>> result = new Dictionary<EnumModelName, IEnumerable<EnumModel>>();

            result.Add(EnumModelName.ItemGroupTypes, CreateModelFromEnum<ItemGroupType>());
            result.Add(EnumModelName.WeightUnitTypes, CreateModelFromEnum<WeightUnitType>());
            result.Add(EnumModelName.DimentionUnitTypes, CreateModelFromEnum<DimentionUnitType>());
            result.Add(EnumModelName.GstTypes, CreateModelFromEnum<ItemGstType>());
            result.Add(EnumModelName.AddressTypes, CreateModelFromEnum<AddressType>());
            result.Add(EnumModelName.StoreTypes, CreateModelFromEnum<StoreType>());
            result.Add(EnumModelName.TransBASETypes, CreateModelFromEnum<TransBASEType>());
            result.Add(EnumModelName.TransStatusTypes, CreateModelFromEnum<TransStatusType>());



            return result;
        }


        /// <summary>
        /// Factory method to convert a generic enum into a UI Enum Model
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static IEnumerable<EnumModel> CreateModelFromEnum<TEnum>() where TEnum : Enum
        {
            Type enumType = typeof(TEnum);

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("TEnum must be of type System.Enum");

            Array enumValueArray = Enum.GetValues(enumType);
            List<EnumModel> enumValueList = new List<EnumModel>();

            foreach (int val in enumValueArray)
            {
                TEnum myType = (TEnum)Enum.ToObject(typeof(TEnum), val);
                var newItem = new EnumModel { id = val, name = myType.GetDisplayName(), };
                enumValueList.Add(newItem);
            }

            return enumValueList;
        }
    }
}

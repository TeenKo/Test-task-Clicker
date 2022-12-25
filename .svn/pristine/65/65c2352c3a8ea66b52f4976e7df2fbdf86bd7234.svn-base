// using System;
// using Core.DataStorage;
// using Entitas;
// using Entitas.CodeGeneration.Attributes;
//
// namespace Deprecated.GameStore
// {
//     //STORE COMPONENTS
//
//
//     //CATALOG
//     [Game, Unique, FlagPrefix("isStatic")]
//     public class StoreSimpleCatalogComponent : IComponent
//     { }
//
//     [Game, Unique, FlagPrefix("isStatic")]
//     public class StorePremiumCatalogComponent : IComponent
//     { }
//
//     [Game, Event(EventTarget.Self)]
//     public class StoreCatalogPrice : IComponent, ISavableData
//     {    
//         public int value;
//
//         public object GetValue => value;
//         public void SetValue(object value) { this.value = Convert.ToInt32(value); }
//     }
//
//     [Game, FlagPrefix("request"), Cleanup(CleanupMode.RemoveComponent)]
//     public class StoreTryPurchaseRandomStoreItemComponent : IComponent
//     { }
//
//     [Game]
//     public class StoreItemRouleteVisualComponent : IComponent
//     {
//         
//     }
//
//
//     //ITEM
//     [Game]
//     public class StoreSimpleItemComponent : IComponent
//     {
//         public SimpleStoreItem value;
//     }
//
//     [Game]
//     public class StorePremiumItemComponent : IComponent
//     {
//         public PremiumStoreItem value;
//     }
//
//     [Game, Event(EventTarget.Self)]
//     public class StoreItemPriceComponent : IComponent
//     {
//         public int value;
//     }
//
//     [Game, Event(EventTarget.Self)]
//     public class StoreTryUnlockItemComponent : IComponent
//     {
//         public bool value;
//     }
//
//     [Game, Event(EventTarget.Self)]
//     public class StoreUnlockItemComponent : IComponent
//     { }
//
//     [Game, FlagPrefix("request"), Cleanup(CleanupMode.RemoveComponent)]
//     public class StoreTrySelectStoreItemComponent : IComponent
//     { }
//
//     [Game, Event(EventTarget.Self)]
//     public class StorePremiumItemTotalPartsComponent : IComponent
//     {
//         public int value;
//     }
//
//     [Game, Event(EventTarget.Self)]
//     public class StorePremiumItemOpenPartsComponent : IComponent, ISavableData
//     {
//         public int value;
//
//         public object GetValue => value;
//         public void SetValue(object value) { this.value = Convert.ToInt32(value); }
//     }
//
//     [Game, Event(EventTarget.Self)]
//     public class StoreItemSoldComponent : IComponent, ISavableData
//     {
//         public bool value;
//
//         public object GetValue => value;
//         public void SetValue(object value) { this.value = Convert.ToBoolean(value); }
//     }
//
//     [Game, Event(EventTarget.Self)]
//     public class StoreItemSelectedComponent : IComponent, ISavableData
//     {
//         public bool value;
//
//         public object GetValue => value;
//         public void SetValue(object value) { this.value = Convert.ToBoolean(value); }
//     }
// }
// using Core.Extension;
// using Entitas.Unity;
// using UnityEngine;
// using UnityEngine.EventSystems;
// using UnityEngine.UI;
//
// namespace Core.UI
// {
//     public class UISimpleStoreItemView : MonoBehAdvUi, IStoreItemSelectedListener, IStoreUnlockItemListener, IStoreTryUnlockItemListener, IPointerClickHandler
//     {
//         [SerializeField] private Image icon;
//         [SerializeField] GameObject selectedSubstrate;
//         [SerializeField] GameObject closeSubstrate;
//         [SerializeField] GameObject openningSubstrate;
//
//         //public override void Link(IEntity entity)
//         //{
//         //    GameEntity gameEntity = (GameEntity)entity;
//         //    gameObject.Link(entity);
//         //    gameEntity.AddStoreItemSelectedListener(this);
//         //    gameEntity.AddStoreTryUnlockItemListener(this);
//         //    gameEntity.AddStoreUnlockItemListener(this);
//
//
//         //    icon.sprite = gameEntity.storeSimpleItem.value.IconImage;
//         //}
//
//         public void OnPointerClick(PointerEventData eventData)
//         {
//             GameEntity gameEntity = gameObject.GetEntityLink().entity as GameEntity;
//             gameEntity.requestStoreTrySelectStoreItem = true;
//         }
//
//         public void OnStoreItemSelected(GameEntity entity, bool value)
//         {
//             selectedSubstrate.SetActive(value);
//         }       
//
//         public void OnStoreTryUnlockItem(GameEntity entity, bool value)
//         {
//             openningSubstrate.SetActive(value);
//         }
//
//         public void OnStoreUnlockItem(GameEntity entity)
//         {
//             closeSubstrate.SetActive(false);
//         }
//     }
// }
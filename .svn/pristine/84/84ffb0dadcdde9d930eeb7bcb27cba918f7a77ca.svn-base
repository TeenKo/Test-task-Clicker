// using Core.Extension;
// using Entitas.Unity;
// using TMPro;
// using UnityEngine;
// using UnityEngine.EventSystems;
// using UnityEngine.UI;
//
// namespace Core.UI
// {
//     public class UIPremiumStoreItemView : MonoBehAdvUi, IStoreItemSelectedListener, IStoreUnlockItemListener, IStoreTryUnlockItemListener, IPointerClickHandler, IStorePremiumItemOpenPartsListener
//     {
//         [SerializeField] private Image icon;
//         [SerializeField] GameObject selectedSubstrate;
//         [SerializeField] GameObject closeSubstrate;
//         [SerializeField] GameObject openningSubstrate;
//         [SerializeField] private TextMeshProUGUI partsTextField;
//
//         private int totalParts;
//
//         //public override void Link(IEntity entity)
//         //{
//         //    GameEntity gameEntity = (GameEntity)entity;
//         //    gameObject.Link(entity);
//         //    icon.sprite = gameEntity.storePremiumItem.value.IconImage;
//         //    totalParts = gameEntity.storePremiumItem.value.price;
//
//         //    gameEntity.AddStoreItemSelectedListener(this);
//         //    gameEntity.AddStoreUnlockItemListener(this);
//         //    gameEntity.AddStoreTryUnlockItemListener(this);
//         //    gameEntity.AddStorePremiumItemOpenPartsListener(this);
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
//         public void OnStorePremiumItemOpenParts(GameEntity entity, int value)
//         {
//             partsTextField.text = $"{value}/{totalParts} ";
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
//             partsTextField.gameObject.SetActive(false);
//         }
//     }
// }
//

// using Core.Input;
// using Core.UI;
// using UnityEngine;
//
// namespace UI
// {
//     public class UiStoreScreen : UIScreen, IAnyStoreListener, ITouchSwipeDirectionListener
//     {
//         [SerializeField] private Camera _camera;
//         [SerializeField] private Transform screenOneTransform;
//         [SerializeField] private Transform screenTwoTransform;
//         [SerializeField] private GameObject dotObject1;
//         [SerializeField] private GameObject dotObject2;
//         private SwipeDirection swipeDirection;
//
//         Vector3 targetPostition;
//         Vector3 startMousePositon;
//         Vector3 endMousePoisition;
//         Vector3 currentMousePoition;
//
//         //private new void Start()
//         //{
//         //    base.Start();
//         //    targetPostition = screenOneTransform.transform.position;
//         //    swipeDirection = SwipeDirection.Left;
//         //}
//
//     
//
//
//         private void Update()
//         {
//          //   SwipeSystem1();
//             //SwipeSystem2();
//         }
//       
//
//         private void SwipeSystem1()
//         {
//             if (UnityEngine.Input.GetMouseButtonDown(0))
//             {
//                 startMousePositon = _camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
//             }
//
//             if (UnityEngine.Input.GetMouseButton(0))
//             {
//
//                 currentMousePoition = _camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
//                 float deltaX = startMousePositon.x - currentMousePoition.x;
//                 _camera.transform.position = Vector3.Slerp(_camera.transform.position, new Vector3(_camera.transform.position.x + deltaX, _camera.transform.position.y, _camera.transform.position.z), 10f);
//                 //Dbg.LogCyan(deltaX.ToString());
//             }
//
//
//             if (UnityEngine.Input.GetMouseButtonUp(0))
//             {
//                 endMousePoisition = _camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
//                 if (Mathf.Abs(startMousePositon.x - endMousePoisition.x) > 0.1f && (startMousePositon.x - endMousePoisition.x) > 0) //свайп вправо
//                 {
//      
//                     targetPostition = screenTwoTransform.transform.position;
//                     dotObject1.SetActive(false);
//                     dotObject2.SetActive(true);
//
//                 }
//
//                 if (Mathf.Abs(startMousePositon.x - endMousePoisition.x) > 0.1f && (startMousePositon.x - endMousePoisition.x) < 0) //свайп влево
//                 {
//                     targetPostition = screenOneTransform.transform.position;
//                     dotObject1.SetActive(true);
//                     dotObject2.SetActive(false);
//                 }
//                 if (_camera.transform.position != targetPostition)
//                     _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, targetPostition, Time.deltaTime * Mathf.Abs(_camera.transform.position.x - targetPostition.x) * 10);
//             }
//         }
//
//         private void SwipeSystem2()
//         {
//             if (swipeDirection == SwipeDirection.Left)
//             {
//                 targetPostition = new Vector3(screenOneTransform.transform.position.x, screenOneTransform.transform.position.y, _camera.transform.position.z);
//                 dotObject1.SetActive(true);
//                 dotObject2.SetActive(false);
//             }
//             else if (swipeDirection == SwipeDirection.Right)
//             {
//                 targetPostition = new Vector3(screenTwoTransform.transform.position.x, screenTwoTransform.transform.position.y, _camera.transform.position.z);
//                 dotObject1.SetActive(false);
//                 dotObject2.SetActive(true);
//             }
//
//             if (_camera.transform.position != targetPostition)
//                 _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, targetPostition, Time.deltaTime * Mathf.Abs(_camera.transform.position.x - targetPostition.x) * 10);
//         }
//
//    
//
//         public void OnTouchSwipeDirection(InputEntity entity, SwipeDirection value)
//         {
//             swipeDirection = value;
//         }
//
//         public void OnAnyStore(StateEntity entity)
//         {
//             Open();
//         }
//     }
// }
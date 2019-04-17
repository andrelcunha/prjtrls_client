using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Trilhas.JsonFormat;
using UnityEngine;
using UnityEngine.UI;

namespace Trilhas.Components.Shop
{
    public class ShelfController : MonoBehaviour
    {
        [SerializeField] CanvasGroup _leftButton;
        [SerializeField] CanvasGroup _rightButton;
        [SerializeField] List <Transform> _items;
        [SerializeField] GameObject _itemsHolder;

        public HorizontalLayoutGroup horizontalLG
        {
            get 
            {
                
                return _itemsHolder.GetComponent<HorizontalLayoutGroup>();
            }
        }


        [SerializeField] RectTransform maskTransform;
        [SerializeField] float _duration;
        [SerializeField] int maxVisibleItems;

        
        float _itemWidth = -1;
        float _offset;

        [SerializeField] Ease ease;
        

        #region Properties
               
        public int MaxVisibleItems
        {
            get
            {
                //var total = (ItemWidth) * (Items.Count) + horizontalLG.spacing * (Items.Count - 1);
                //Debug.Log("total: " + total);
                maxVisibleItems = Mathf.RoundToInt (maskTransform.rect.width / (ItemWidth + horizontalLG.spacing));
                return maxVisibleItems;
            }
        }

        public float ItemWidth
        {
            get
            {
                if (_itemWidth < 0)
                {
                    _itemWidth = Items[0].GetComponentInChildren<RectTransform>().rect.width;
                }
                return _itemWidth;
            }
        }
        
        public float Offset
        {
            get
            {
                return ItemWidth + (horizontalLG.spacing / 2);
            }
        }

        public List<Transform> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new List<Transform>(_itemsHolder.GetComponentsInChildren<Transform>()
                                         .Where((arg) => arg.GetComponent<ShelfItem>() != null));    
                }
                return _items;
            }
        }

        public int Last
        {
            get
            {
                return Items.Count - 1;
            }
        }

        public int First
        {
            get
            {
                return 0; 
            }
        }
        #endregion

        void Start()
        {
           // SetSpaceBetweenItems();
        }
                
        public void Left()
        {         
            SetInteractivity(false);
            if (!NecessaryAnimation())
            {
                return;
            }
            Items[First].SetAsLastSibling();
            Transform item = Items[First];
            Items.RemoveAt (First);
            Items.Insert(Last, item);
            DisplaceItemsHolder(Offset);
            TweenMoveItemHolder();
        }

        public void Right()
        {         
            SetInteractivity(false);
            if (!NecessaryAnimation())
            {
                return;
            }
            Items[Last].SetAsFirstSibling();
            Transform item = Items[Last];
            Items.RemoveAt(Last);
            Items.Insert(First, item); 
            DisplaceItemsHolder(-Offset);
            TweenMoveItemHolder();
        }
        
        public void SetInteractivity(bool isEnable)
        {
            _leftButton.blocksRaycasts = isEnable;
            _leftButton.interactable = isEnable;
            _rightButton.blocksRaycasts = isEnable;
            _rightButton.interactable = isEnable;
        }

        public void TweenMoveItemHolder()
        {
            var seq = DOTween.Sequence();
            var tween = _itemsHolder.transform.DOLocalMoveX(0, _duration)
                                    .SetEase(ease);
            tween.OnComplete(delegate
            {
                SetInteractivity(true);
            });
            seq.Append(tween); 
        }

        public void InsertItem(GameObject item)
        {
           
            item.transform.SetParent(_itemsHolder.transform, false);
            Items.Add(item.transform);

        }
        
        public void RemoveItem(string itemName) 
        {
            
            //TODO: Implement removal method
            //item.transform.SetParent(_itemsHolder.transform, false);

            var indexOfItem = Items
                .FindIndex((go) => go.GetComponent<ShelfItem>().Nome == itemName);
            var item = Items[indexOfItem];
            Items.RemoveAt(indexOfItem);
            item.gameObject.SetActive(false);         
        }

        private void SetButton(CanvasGroup button,bool isEnable)
        {
            button.alpha = isEnable ? 1 : 0;
            button.interactable = isEnable;
            button.blocksRaycasts = isEnable;
        }
        
              
        private void DisplaceItemsHolder(float offset)
        {
            Vector3 newPos = _itemsHolder.transform.localPosition;
            newPos.x = newPos.x + offset;
            Debug.Log("Offset: " + offset);
            Debug.LogFormat("New Pos x: {0}, y:{1} z:{2}  ", newPos.x, newPos.y, newPos.z);
            _itemsHolder.transform.localPosition = newPos;           
        }            
        
        private bool NecessaryAnimation()
        {
            //bool test = !(maxVisibleItems > Items.Count);
            //Debug.LogFormat("Max:{0}, amount:{1}, test: {2}",maxVisibleItems,Items.Count, test.ToString());
            //SetInteractivity(test);
            bool test = Items.Count > MaxVisibleItems;
            return test;
        }
        
        private void SetSpaceBetweenItems()
        {
            float val =  maskTransform.rect.width / MaxVisibleItems;
            horizontalLG.spacing = val;
        }
    }
}

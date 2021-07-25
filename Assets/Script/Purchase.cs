using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Purchase : MonoBehaviour
{
    private class Item
    {
        public string title;
        public string description;
        public string price;
    };

    private void Start()
    {
        IStoreController controller = CodelessIAPStoreListener.Instance.StoreController;
        List<Item> items = new List<Item>();
        foreach(Product product in controller.products.all)
        {
            items.Add(new Item
            {
                title = product.metadata.localizedTitle,
                description = product.metadata.localizedDescription,
                price = product.metadata.localizedPriceString
            });
        }
    }

    private void Update()
    {
    }

    // 購入成功
    public void OnPurchaseComplete(Product product)
    {
#if UNITY_EDITOR
        UnityEditor.EditorUtility.DisplayDialog("Purchase complete", product.definition.id, "OK");
#endif
    }

    // 購入失敗
    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
#if UNITY_EDITOR
        UnityEditor.EditorUtility.DisplayDialog("Purchase failed", product.definition.id, "OK");
#endif
    }
}

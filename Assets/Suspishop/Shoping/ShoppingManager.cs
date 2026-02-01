using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShoppingManager : MonoBehaviour
{
    public static ShoppingManager Instance { get; set; }

    public List<int> playerSubmit = new();
    public List<int> monsterRequest = new();

    public int[] potions = { 1, 2, 3, 4, 5, 6 };

    int submittedItemCount;
    int requestedItemCount;

    public UnityEvent submitPotion;

    #region Initialization

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //StartCoroutine(GetCurrentMonster());
    }

    #endregion

    #region Order Management

    public IEnumerator GetCurrentMonster()
    {
        yield return new WaitUntil(() => MonsterController.Instance.currentMonster != null);
        requestedItemCount = MonsterController.Instance.currentMonster.monsterLevel;
        RandomMonsterReq();
    }

    public void RandomMonsterReq()
    {
        monsterRequest.Clear();

        // make pool items temporary
        List<int> availablePotions = new List<int>(potions);

        // Safety check
        int count = Mathf.Min(requestedItemCount, availablePotions.Count);

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, availablePotions.Count);
            int selectedItem = availablePotions[randomIndex];

            monsterRequest.Add(selectedItem);
            availablePotions.RemoveAt(randomIndex); // Remove to avoid duplicates
        }

        RequestUI.Instance.RefreshUI(monsterRequest);
    }

    #endregion

    #region Submit Management

    public void SetPlayerSubmit(int potionId)
    {
        playerSubmit.Add(potionId);
    }

    public void CompareSubmit()
    {
        if (playerSubmit.Count == 0)
            return;

        if (playerSubmit.Count != monsterRequest.Count)
        {
            Debug.Log("Submitted item count doesn't match request.");
            Lose();
            return;
        }

        var needed = new Dictionary<int, int>();
        foreach (var item in monsterRequest)
        {
            if (needed.ContainsKey(item)) needed[item]++;
            else needed[item] = 1;
        }

        foreach (var item in playerSubmit)
        {
            if (!needed.ContainsKey(item))
            {
                Debug.Log("Submitted items do not match request.");
                Lose();
                return;
            }
            needed[item]--;
        }

        Win();
    }

    #endregion

    public enum ShoppingResult
    {
        Success,
        Fail
    }

    void Win()
    {
        Debug.Log("Players wins!");
        ResolveTransaction(ShoppingResult.Success);

        submitPotion?.Invoke();
    }

    void Lose()
    {
        Debug.Log("Players lose!");
        ResolveTransaction(ShoppingResult.Fail);

        submitPotion?.Invoke();
    }

    void ResolveTransaction(ShoppingResult shoppingResult)
    {
        GameResolver.Resolve(shoppingResult);
    }

    #region Clearing Orders

    public void ClearSubmission()
    {
        playerSubmit.Clear();

        PotionManager.Instance.CancelSubmission();
    }

    public void ClearOrders()
    {
        playerSubmit.Clear();
        monsterRequest.Clear();

        PotionManager.Instance.CancelSubmission();
    }

    #endregion
}

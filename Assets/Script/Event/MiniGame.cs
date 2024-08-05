using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGame : MonoBehaviour
{
    public GameObject coinPrefab;

    public int totalCoins; // Tổng số coin cần thu thập
    private int collectedCoins = 0; // Số coin đã thu thập
    public string nameScene; // Tên của cảnh tiếp theo
    private bool hasTriggeredDialog = false; // Đảm bảo hộp thoại chỉ xuất hiện một lần
    private bool statePlay = false; // Trạng thái của trò chơi

    // Phương thức này được gọi khi người chơi nhặt được coin
    public void CollectCoin()
    {
        collectedCoins++;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (collectedCoins >= totalCoins)
            {
                SceneManager.LoadScene(nameScene); // Chuyển sang cảnh mới nếu đủ coin
            }
            else if (!hasTriggeredDialog)
            {
                ShowDialog();
            }
        }
    }

    private void ShowDialog()
    {
        // Hủy đối tượng Menu hiện tại (nếu có)
        Destroy(GameObject.Find("Menu"));

        // Hiển thị hộp thoại mới từ tài nguyên
        GameObject dialogBox = Instantiate(Resources.Load<GameObject>("Prefab/UI/Dialog/DialogBox"));
        dialogBox.transform.SetParent(GameObject.Find("UI").transform, false);

        // Đặt cờ để đảm bảo hộp thoại chỉ xuất hiện một lần
        hasTriggeredDialog = true;

        // Đặt trạng thái chơi là true (hoặc bạn có thể thay đổi logic của cờ này tùy theo nhu cầu)
        statePlay = true;

        // Bắt đầu Coroutine để ẩn hộp thoại sau một khoảng thời gian
        StartCoroutine(HideDialogAfterDelay());
    }

    private IEnumerator HideDialogAfterDelay()
    {
        yield return new WaitForSeconds(3f); // Đợi 3 giây trước khi ẩn hộp thoại
        Destroy(GameObject.Find("DialogBox(Clone)")); // Hủy hộp thoại
        hasTriggeredDialog = false; // Đặt lại cờ cho phép hiển thị hộp thoại trong tương lai
    }
}

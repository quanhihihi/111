using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleStart : MonoBehaviour
{
    public Transform boss; // Tham chiếu đến đối tượng Boss
    public float zoomDuration = 5f; // Thời gian zoom vào boss

    private float originalCameraSize;
    private Vector3 originalCameraPosition;
    private bool isDialogPlaying = false;
    private GameObject dialogBox; // Tham chiếu đến đối tượng DialogBox
    private List<EnemyController> enemies; // Danh sách các kẻ địch
    private Transform playerTransform; // Tham chiếu đến Transform của Player

    void Awake()
    {
        originalCameraSize = Camera.main.orthographicSize;
        originalCameraPosition = Camera.main.transform.position;
        enemies = new List<EnemyController>(FindObjectsOfType<EnemyController>());
        playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform; // Tìm Transform của Player
    }

    void Start()
    {
        // Bắt đầu màn đấu boss
        StartBossBattle();
    }

    void StartBossBattle()
    {
        if (boss == null)
        {
            Debug.LogError("Boss is not assigned.");
            return;
        }

        // Hiển thị dialog và bắt đầu zoom vào boss
        StartCoroutine(BossBattleRoutine());
    }

    IEnumerator BossBattleRoutine()
    {
        // Ẩn menu nếu có
        GameObject menu = GameObject.Find("Menu");
        if (menu != null)
        {
            Destroy(menu);
        }

        // Hiển thị dialog box
        dialogBox = Instantiate(Resources.Load<GameObject>("Prefab/UI/Dialog/DialogBox"));
        dialogBox.transform.SetParent(GameObject.Find("UI").transform, false);
        DisableEnemies(true);

        // Đợi để đảm bảo dialog box đã được tạo và hiển thị
        yield return new WaitForSeconds(0.1f);

        isDialogPlaying = true;

        // Zoom vào boss
        yield return StartCoroutine(ZoomToBoss());

        // Chờ cho dialog kết thúc
        while (!IsDialogBoxClosed())
        {
            yield return null;
        }

        // Kết thúc zoom và khôi phục lại camera về vị trí của player
        if (playerTransform != null)
        {
            StartCoroutine(ZoomBackToPlayer());
        }
        else
        {
            // Nếu không tìm thấy player, khôi phục kích thước camera ban đầu
            Camera.main.orthographicSize = originalCameraSize;
            Camera.main.transform.position = originalCameraPosition;
        }

        // Bật lại hành vi tấn công của tất cả kẻ địch
        DisableEnemies(false);
    }

    IEnumerator ZoomToBoss()
    {
        float elapsed = 0f;
        Vector3 targetPosition = new Vector3(boss.position.x, boss.position.y, Camera.main.transform.position.z);

        // Zoom vào boss
        while (elapsed < zoomDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / zoomDuration;
            Camera.main.orthographicSize = Mathf.Lerp(originalCameraSize, 5f, t); // Thay đổi kích thước camera để zoom
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition, t);
            yield return null;
        }

        Camera.main.orthographicSize = 5f;
        Camera.main.transform.position = targetPosition;
    }

    IEnumerator ZoomBackToPlayer()
    {
        float elapsed = 0f;
        Vector3 targetPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, Camera.main.transform.position.z);

        // Zoom lại về vị trí của player
        while (elapsed < zoomDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / zoomDuration;
            Camera.main.orthographicSize = Mathf.Lerp(5f, originalCameraSize, t); // Thay đổi kích thước camera để zoom lại
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition, t);
            yield return null;
        }

        Camera.main.orthographicSize = originalCameraSize;
        Camera.main.transform.position = targetPosition;
    }

    void Update()
    {
        // Cập nhật trạng thái hội thoại nếu dialog box tồn tại
        if (isDialogPlaying && IsDialogBoxClosed())
        {
            isDialogPlaying = false;
        }
    }

    void DisableEnemies(bool disable)
    {
        foreach (var enemy in enemies)
        {
            if (enemy != null)
            {
                // Tạm thời vô hiệu hóa hành vi tấn công và di chuyển của kẻ địch
                enemy.StateAttack(disable ? 1 : 0); // Thay đổi trạng thái tấn công của kẻ địch
                enemy.GetComponent<Patrol>().enabled = !disable; // Tắt hay bật hành vi tuần tra của kẻ địch
            }
        }
    }

    bool IsDialogBoxClosed()
    {
        return dialogBox == null;
    }
}
